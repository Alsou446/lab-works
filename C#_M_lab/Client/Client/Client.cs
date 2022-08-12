using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Reflection;
using System.IO;
using System.Globalization;

namespace Client
{
    public partial class Client : Form
    {
        private BigInteger SessionKey = -1;
        private struct TcpClient
        {
            public string key;
            public System.Net.Sockets.TcpClient client;
            public NetworkStream stream;
            public byte[] buffer;
            public StringBuilder data;
            public EventWaitHandle handle;
        };

        private struct DiffieHellmanKeys
        {
            public BigInteger B;
            public BigInteger b;
            public BigInteger p;
            public BigInteger g;
            public BigInteger K;
        };

        private DiffieHellmanKeys DHKeys;

        private TcpClient obj;

        private struct RSAKeys
        {
            public BigInteger n;
            public BigInteger e;
            public BigInteger d;
        }
        RSAKeys RSA;

        private DES Des = new DES();

        private bool connected = false;
        private Thread client = null;       

        private Task send = null;
        private bool exit = false;

        public Client()
        {            
            RSA.n = -1;
            RSA.e = -1;
            RSA.d = -1;

            InitializeComponent();            
        }

        private void Log(string msg = "") // clear the log if message is not supplied or is empty
        {
            if (!exit)
            {
                logsRtb.Invoke((MethodInvoker)delegate
                {
                    if (msg.Length > 0)
                    {
                        logsRtb.AppendText(string.Format("[ {0} ] {1}{2}", DateTime.Now.ToString("HH:mm"), msg, Environment.NewLine));
                    }
                    else
                    {
                        logsRtb.Clear();
                    }
                });
            }
        }
       
        private void AddMessage(string crypted, string decrypted, string sender)
        {            
            chat_rtb.Invoke((MethodInvoker)delegate
            {
                chat_rtb.AppendText(sender + " | " + decrypted + " (" + crypted + ")" + "\n");
            });
        }

        private void SetAuthRes(string msg = "") // clear the log if message is not supplied or is empty
        {
            if (!exit)
            {
                authResLabel.Invoke((MethodInvoker)delegate
                {
                    if (msg.Length > 0)
                    {
                        authResLabel.Text = msg;
                    }
                    else
                    {
                        
                    }
                });
            }
        }

        private void Connected(bool status)
        {
            if (!exit)
            {
                connectButton.Invoke((MethodInvoker)delegate
                {
                    connected = status;
                    if (status)
                    {
                        addrTextBox.Enabled = false;
                        portTextBox.Enabled = false;
                        connectButton.Text = "Disconnect";
                    }
                    else
                    {
                        addrTextBox.Enabled = true;
                        portTextBox.Enabled = true;
                        connectButton.Text = "Connect";
                    }
                });
            }
        }

        private void Read(IAsyncResult result)
        {
            int bytes = 0;
            if (obj.client.Connected)
            {
                try
                {
                    bytes = obj.stream.EndRead(result);
                }
                catch (Exception ex)
                {
                    Log(ex.ToString());
                }
            }
            if (bytes > 0)
            {
                obj.data.AppendFormat("{0}", Encoding.UTF8.GetString(obj.buffer, 0, bytes));
                try
                {
                    if (obj.stream.DataAvailable)
                    {
                        obj.stream.BeginRead(obj.buffer, 0, obj.buffer.Length, new AsyncCallback(Read), null);
                    }
                    else
                    {
                        string msg = obj.data.ToString();
                        Log("Ответ сервера: " + msg);

                        if (msg.Split('~').Length < 2)
                        {
                            Log("Невалидный ответ от сервера");
                        }
                        else
                        {
                            if (msg.StartsWith("[TIMEMARK_RESPONSE]"))
                            {
                                TimemarkResponse(msg);
                            }
                            else if (msg.StartsWith("[AUTH_RESPONSE]"))
                            {
                                AuthResponse(msg);
                            }
                            else if (msg.StartsWith("[DH_RESPONSE]"))
                            {
                                DiffieHellmanResponse(msg);
                            }
                            else if (msg.StartsWith("[RSA_RESPONSE]"))
                            {
                                RSAResponse(msg);
                            }
                            else if (msg.StartsWith("[DOC_RESPONSE]"))
                            {
                                DocResponse(msg);
                            }
                            else if (msg.StartsWith("[MSG_FROM_SERVER]"))
                            {
                                MessageReceived(msg);
                            }

                            obj.data.Clear();
                            obj.handle.Set();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log(ex.ToString());
                    obj.data.Clear();
                    obj.handle.Set();
                }
            }
            else
            {
                obj.client.Close();
                obj.handle.Set();
            }
        }       
       
        private void TimemarkResponse(string msg)
        {
            if (msg.Split('~')[1] != "GOOD")
            {
                Log("Запрос временной метки не удался: " + msg.Split('~')[2]);
                SetAuthRes(msg.Split('~')[2]);
                authResLabel.ForeColor = System.Drawing.Color.DarkRed;
                return;
            }

            string timemarkMd5 = msg.Split('~')[2];
            Log("Получен MD5 временной метки от сервера: '" + timemarkMd5 + "'");
            Log("Хешируем пароль, собираем общий хеш, отправляем серверу...");
            string passMd5 = GenerateMD5(passwordTextbox.Text);

            string totalHash = GenerateMD5(timemarkMd5 + passMd5);
            Log("Общий MD5: '" + totalHash + "'");

            Send("[AUTH_REQUEST]~" + usernameTextbox.Text + "~" + totalHash);
            Log("Отправляем серверу: " + "[AUTH_REQUEST]~" + usernameTextbox.Text + "~" + totalHash);
        }

        private void AuthResponse(string msg)
        {
            if (msg.Split('~')[1] != "GOOD")
            {               
                Log("Авторизация не удалась: " + msg.Split('~')[2]);
                SetAuthRes(msg.Split('~')[2]);
                authResLabel.ForeColor = System.Drawing.Color.DarkRed;
                usernameTextbox.Enabled = passwordTextbox.Enabled = true;
                return;
            }

            Log("Авторизация успешно пройдена. \nНачинаем процедуру создания сессионного ключа...");
            SetAuthRes("Авторизация успешно пройдена. \nНачинаем процедуру создания сессионного ключа...");

            authResLabel.ForeColor = System.Drawing.Color.DarkGreen;

            BigInteger p = BigInteger.Parse(msg.Split('~')[2]);
            BigInteger g = BigInteger.Parse(msg.Split('~')[3]);
            BigInteger A = BigInteger.Parse(msg.Split('~')[4]);

            DHKeys.p = p;
            DHKeys.g = g;

            Log("Герерируем 'b' для протокола Диффи-Хеллмана");
            BigInteger b;
            while (true)
            {
                b = AllMath.GenerateRandomBigInt(128);

                if (b > p - 1)
                {
                    b /= 2;
                }
                if (b >= 2)
                {
                    break;
                }
            }
            Log("   b = " + b.ToString());
            DHKeys.b = b; ;
            Log("Герерируем 'B' для протокола Диффи-Хеллмана");
            BigInteger B = AllMath.FastExponentiation(g, b, p);
            Log("   B = " + B.ToString());

            Log("Генерируем сессионный ключ 'K' Диффи-Хеллмана");
            SessionKey = AllMath.FastExponentiation(A, b, p);
            Log("   K = " + SessionKey.ToString());

            Log("Отправляем 'B' серверу...");
            string data = "[DH_REQUEST]~" + B.ToString();
            Send(data);
        }

        private void DiffieHellmanResponse(string msg)
        {
            if (msg.Split('~')[1] != "GOOD")
            {
                Log("Создание сессионного ключа не удалось: " + msg.Split('~')[2]);
                SetAuthRes(msg.Split('~')[2]);
                authResLabel.ForeColor = System.Drawing.Color.DarkRed;
                usernameTextbox.Enabled = passwordTextbox.Enabled = true;
                return;
            }

            SetAuthRes("Сессионный ключ сгенерирован успешно. \nНачинаем процедуру генерации ключей RSA и отправки документа...");
            Log("Сессионный ключ сгенерирован на стороне сервера. Начинаем генерацию ключей RSA");

            (RSA.n, RSA.e, RSA.d) = AllMath.RSA_generate(32); // 128, 32 для взлома
            Log("   e = " + RSA.e.ToString());
            Log("   d = " + RSA.d.ToString());
            Log("   n = " + RSA.n.ToString());

            string data = "[RSA_REQUEST]~" + RSA.e.ToString() + "~" + RSA.n.ToString();
            Send(data);
            Log("Ключи (e,n) отправлены серверу");
        }

        private void RSAResponse(string msg)
        {
            if (msg.Split('~')[1] != "GOOD")
            { 
                Log("Отправка ключей RSA не удалась: " + msg.Split('~')[2]);
                SetAuthRes(msg.Split('~')[2]);
                authResLabel.ForeColor = System.Drawing.Color.DarkRed;
                usernameTextbox.Enabled = passwordTextbox.Enabled = true;
                return;
            }

            Log("(n, e) получены сервером");
            Log("Начинаем отправку документа");

            string path = "file.txt";
            string textFromFile;
                 
            using (FileStream fstream = File.OpenRead(path))
            {
                // выделяем массив для считывания данных из файла
                byte[] buffer = new byte[fstream.Length];
                // считываем данные
                fstream.Read(buffer, 0, buffer.Length);
                // декодируем байты в строку
                textFromFile = Encoding.Default.GetString(buffer);
            }
            //                                      0  + AB01F2587F123D7E...
            
            string fileHash = GenerateMD5(textFromFile);
            Log("Хеш файла: " + fileHash);
            BigInteger hashNum = BigInteger.Parse("0" + fileHash, NumberStyles.AllowHexSpecifier);
            BigInteger rsaSign = AllMath.FastExponentiation(hashNum, RSA.d, RSA.n);
            Log("Подпись: " + rsaSign);
            Log("Подпись и файл отправлены на сервер"); 
            Send("[DOC_REQUEST]~" + path + "~" + rsaSign + "~" + textFromFile);
        }

        private void DocResponse(string msg)
        {
            if (msg.Split('~')[1] != "GOOD")
            {
                Log("Отправка документа не удалась: " + msg.Split('~')[2]);
                SetAuthRes(msg.Split('~')[2]);
                authResLabel.ForeColor = System.Drawing.Color.DarkRed;
                usernameTextbox.Enabled = passwordTextbox.Enabled = true;
            }
            else
            {
                Log("ЭЦП подтверждена сервером");
                SetAuthRes("ЭЦП подтверждена сервером");
                authResLabel.ForeColor = System.Drawing.Color.DarkGreen;
                usernameTextbox.Enabled = passwordTextbox.Enabled = true;
            }
        }
        
        private void Connection(IPAddress ip, int port)
        {
            try
            {
                obj = new TcpClient();
                obj.client = new System.Net.Sockets.TcpClient();
                obj.client.Connect(ip, port);
                obj.stream = obj.client.GetStream();
                obj.buffer = new byte[obj.client.ReceiveBufferSize];
                obj.data = new StringBuilder();
                obj.handle = new EventWaitHandle(false, EventResetMode.AutoReset);

                while (obj.client.Connected)
                {
                    try
                    {
                        obj.stream.BeginRead(obj.buffer, 0, obj.buffer.Length, new AsyncCallback(Read), null);
                        obj.handle.WaitOne();
                    }
                    catch (Exception ex)
                    {
                        Log(ex.ToString());
                    }
                }
                obj.client.Close();
                Connected(false);

            }
            catch (Exception ex)
            {
                Log(ex.ToString());
            }
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                obj.client.Close();
            }
            else if (client == null || !client.IsAlive)
            {
                string address = addrTextBox.Text.Trim();
                string number = portTextBox.Text.Trim();
                bool error = false;
                IPAddress ip = null;
                if (address.Length < 1)
                {
                    error = true;
                }
                else
                {
                    try
                    {
                        ip = Dns.Resolve(address).AddressList[0];
                    }
                    catch
                    {
                        error = true;
                    }
                }
                int port = -1;
                if (number.Length < 1)
                {
                    error = true;
                }
                else if (!int.TryParse(number, out port))
                {
                    error = true;
                }
                else if (port < 0 || port > 65535)
                {
                    error = true;
                }                
                if (!error)
                {
                    // encryption key is optional
                    client = new Thread(() => Connection(ip, port))
                    {
                        IsBackground = true
                    };
                    client.Start();                    
                }
            }
            Log("Подключено к серверу");
        }

        private void Write(IAsyncResult result)
        {
            if (obj.client.Connected)
            {
                try
                {
                    obj.stream.EndWrite(result);
                }
                catch (Exception ex)
                {
                    Log(ex.ToString());
                }
            }
        }

        private void BeginWrite(string msg)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(msg);
            if (obj.client.Connected)
            {
                try
                {
                    obj.stream.BeginWrite(buffer, 0, buffer.Length, new AsyncCallback(Write), null);
                }
                catch (Exception ex)
                {
                    Log(ex.ToString());
                }
            }
        }

        private void Send(string msg)
        {
            if (send == null || send.IsCompleted)
            {
                send = Task.Factory.StartNew(() => BeginWrite(msg));
            }
            else
            {
                send.ContinueWith(antecendent => BeginWrite(msg));
            }
        }

        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            exit = true;
            if (connected)
            {
                obj.client.Close();
            }
        }

        private void authButton_Click(object sender, EventArgs e)
        {
            if (obj.client == null || !obj.client.Connected)
            {
                authResLabel.Text = "Подключитесь к серверу";
                authResLabel.ForeColor = System.Drawing.Color.DarkRed;

                return;
            }
            if (usernameTextbox.Text.Length == 0 || passwordTextbox.Text.Length == 0)
            {
                authResLabel.Text = "Введите логин и пароль";
                authResLabel.ForeColor = System.Drawing.Color.DarkRed;
                return;
            }

            Send("[TIMEMARK_REQUEST]~" + usernameTextbox.Text);
            // usernameTextbox.Enabled = passwordTextbox.Enabled = false;
            Log("Запрос временной метки отправлен на сервер: " + "[TIMEMARK_REQUEST]~" + usernameTextbox.Text);
            authResLabel.Text = "Подождите...";
            authResLabel.ForeColor = System.Drawing.Color.Black;
        }

        private string GenerateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        private void MessageReceived(string msg)
        {
            Des.SetKey(SessionKey);

            var list = msg.Split('~');
            if (list[1] == "TEXT") // Если нам отправили текстовое сообщение
            {
                string crypted = list[2];
                string decrypted = Des.DecryptString(crypted);                              
                
                AddMessage(crypted, decrypted, "Сервер");
            }
            else if (list[1] == "FILE") // Если нам отправили файл
            {
                string filename = list[2];
                string crypted = list[3];
                string decrypted = Des.DecryptString(crypted);

                // Пишем зашифрованный файл
                using (FileStream fstream = new FileStream("cr_" + filename, FileMode.OpenOrCreate))
                {
                    // преобразуем строку в байты
                    byte[] buffer = Encoding.Default.GetBytes(crypted);
                    // запись массива байтов в файл
                    fstream.Write(buffer, 0, buffer.Length);
                }

                // Пишем расшифрованный файл
                using (FileStream fstream = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    // преобразуем строку в байты
                    byte[] buffer = Encoding.Default.GetBytes(decrypted);
                    // запись массива байтов в файл
                    fstream.Write(buffer, 0, buffer.Length);
                }

                AddMessage("Файл", filename, "Сервер");
            }
        }

        private void send_button_Click(object sender, EventArgs e)
        {
            Des.SetKey(SessionKey);

            string text = input_tb.Text;
            input_tb.Clear();
            string cryptedText = Des.CryptString(text);
            AddMessage(text, cryptedText, "Вы");

            Send("[MSG_FROM_CLIENT]~TEXT~" + cryptedText);
        }

        private void input_tb_TextChanged(object sender, EventArgs e)
        {
            send_button.Enabled = (input_tb.Text.Length != 0);
        }

        private void file_button_Click(object sender, EventArgs e)
        {
            string filePath = "";
            string fileContent = "";

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    var fileStream = openFileDialog.OpenFile();
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
            string filename = filePath.Split('\\')[filePath.Split('\\').Length - 1];
            Des.SetKey(SessionKey);
            Send("[MSG_FROM_CLIENT]~FILE~" + filename + "~" + Des.CryptString(fileContent));
            AddMessage("Файл", filePath, "Вы");
        }
    }
}
