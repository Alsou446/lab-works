using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Server : Form
    {
        private struct DiffieHellmanKeys
        {
            public BigInteger A;
            public BigInteger a;
            public BigInteger p;
            public BigInteger g;
            public BigInteger K;
        };
        private DiffieHellmanKeys DH;

        private struct RSAKeys
        {
            public BigInteger e;
            public BigInteger n;
        }
        private RSAKeys RSA;

        private DES Des = new DES();

        private BigInteger SessionKey = -1;
        private bool active = false;
        private Thread listener = null;
        private long id = 0;
        private ConcurrentDictionary<long, MyClient> clients = new ConcurrentDictionary<long, MyClient>();
        private Task send = null;
        private Thread disconnect = null;
        private bool exit = false;
        private struct MyClient
        {
            public long id;
            public TcpClient client;
            public NetworkStream stream;
            public byte[] buffer;
            public StringBuilder data;
            public EventWaitHandle handle;
        };

        private SQLiteWorker SqlWorker;

        public Server()
        {
            DH.A = -1;
            DH.a = -1;
            DH.p = -1;
            DH.g = -1;
            DH.K = -1;
            InitializeComponent();

            SqlWorker = new SQLiteWorker();

            if (active)
            {
                active = false;
            }
            else if (listener == null || !listener.IsAlive)
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
                    listener = new Thread(() => Listener(ip, port), 1024 * 1024 * 1024)
                    {
                        IsBackground = true
                    };
                    listener.Start();
                }
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (active)
            {
                active = false;
            }
            else if (listener == null || !listener.IsAlive)
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
                    listener = new Thread(() => Listener(ip, port), 1024 * 1024 * 1024)
                    {
                        IsBackground = true
                    };
                    listener.Start();
                }
            }
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
            if (!exit)
            {
                chat_rtb.Invoke((MethodInvoker)delegate
                {
                    chat_rtb.AppendText(sender + " | " + decrypted + " (" + crypted + ")" + "\n");
                });
            }
        }

        private void Active(bool status)
        {
            if (!exit)
            {
                startButton.Invoke((MethodInvoker)delegate
                {
                    active = status;
                    if (status)
                    {
                        addrTextBox.Enabled = false;
                        portTextBox.Enabled = false;
                        startButton.Text = "Stop";
                    }
                    else
                    {
                        addrTextBox.Enabled = true;
                        portTextBox.Enabled = true;
                        startButton.Text = "Start";
                    }
                });
            }
        }

        private void Read(IAsyncResult result)
        {
            MyClient obj = (MyClient)result.AsyncState;
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
                        obj.stream.BeginRead(obj.buffer, 0, obj.buffer.Length, new AsyncCallback(Read), obj);
                    }
                    else
                    {
                        string msg = obj.data.ToString();
                        Log("Запрос от клиента: " + msg);

                        if (msg.Split('~').Length < 2)
                        {
                            Log("Ошибка, невалидный запрос от пользователя");
                            Log("Отправляем клиенту: " + "[RESPONSE]~ERROR~Невалидный запрос");
                            Send("[RESPONSE]~ERROR~Невалидный запрос");
                        }
                        else
                        {
                            if (msg.StartsWith("[TIMEMARK_REQUEST]"))
                            {
                                TimemarkRequest(msg);
                            }
                            else if (msg.StartsWith("[AUTH_REQUEST]"))
                            {
                                AuthRequest(msg);
                            }
                            else if (msg.StartsWith("[DH_REQUEST]"))
                            {
                                DiffieHellmanRequest(msg);
                            }
                            else if (msg.StartsWith("[RSA_REQUEST]"))
                            {
                                RSARequest(msg);
                            }
                            else if (msg.StartsWith("[DOC_REQUEST]"))
                            {
                                DocRequest(msg);
                            }
                            else if (msg.StartsWith("[MSG_FROM_CLIENT]"))
                            {
                                MessageReceived(msg);
                            }
                        }

                        obj.data.Clear();
                        obj.handle.Set();
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

        private void TimemarkRequest(string msg)
        {
            logsRtb.Invoke((MethodInvoker)delegate
            {
                logsRtb.Clear();
            });

            string username = msg.Split('~')[1];
            Log("Проверяем наличие пользователя '" + username + "' в базе");

            if (!SqlWorker.UserExist(username))
            {
                Log("Пользователь '" + username + "' не найден");
                Log("Отправляем клиенту: " + "[TIMEMARK_RESPONSE]~ERROR~Пользователь '" + username + "' не найден");
                Send("[TIMEMARK_RESPONSE]~ERROR~Пользователь '" + username + "' не найден");
            }
            else
            {
                System.DateTime timemark = SqlWorker.GetTimemark(username);
                Log("Временная метка: '" + timemark.ToString(SqlWorker.DatetimeFormat) + "' из базы");

                if ((timemark - System.DateTime.Now).Duration().Hours > 0)
                {
                    Log("Обновляем временную метку в базе");
                    SqlWorker.UpdateTimemark(username);
                    timemark = SqlWorker.GetTimemark(username);
                    Log("Новая временная метка: '" + timemark.ToString(SqlWorker.DatetimeFormat) + "' из базы");
                }
                string timemarkMd5 = GenerateMD5(timemark.ToString(SqlWorker.DatetimeFormat));
                Log("Отправляем клиенту: " + "[TIMEMARK_RESPONSE]~GOOD~" + timemarkMd5);
                Send("[TIMEMARK_RESPONSE]~GOOD~" + timemarkMd5);
            }
        }

        private void AuthRequest(string msg)
        {
            string username = msg.Split('~')[1];
            if (!SqlWorker.UserExist(username))
            {
                Log("Пользователь '" + username + "' не найден");
                Log("Отправляем клиенту: " + "[AUTH_RESPONSE]~ERROR~Пользователь '" + username + "' не найден");
                Send("[AUTH_RESPONSE]~ERROR~Пользователь '" + username + "' не найден");
            }
            else
            {
                Log("Проверяем соответствие имени пользователя и хеша хешей...");
                string timemarkMd5 = GenerateMD5(SqlWorker.GetTimemark(username).ToString(SqlWorker.DatetimeFormat));
                string passwordMd5 = SqlWorker.GetPassword(username);
                string calcTotalHash = GenerateMD5(timemarkMd5 + passwordMd5);

                Log("Полученный хэш:  '" + msg.Split('~')[2] + "'");
                Log("Вычисленный хэш: '" + calcTotalHash + "'");

                if (msg.Split('~')[2] == calcTotalHash)
                {
                    Log("Авторизация пройдена");
                    Log("Герерируем 'p' для протокола Диффи-Хеллмана");
                    DH.p = AllMath.GenerateRandomSimpleBigInt(32); // 128, для взлома 32
                    Log("   p = " + DH.p.ToString());

                    Log("Герерируем 'g' для протокола Диффи-Хеллмана");
                    DH.g = AllMath.GetPrimitive(DH.p); // 64, для взлома поменять на 16
                    Log("   g = " + DH.g.ToString());

                    Log("Герерируем 'a' для протокола Диффи-Хеллмана");

                    while (true)
                    {
                        DH.a = AllMath.GenerateRandomBigInt(32); //64, для взлома 32

                        if (DH.a > DH.p - 1)
                        {
                            DH.a /= 2;
                        }
                        if (DH.a >= 2)
                        {
                            break;
                        }
                    }
                    Log("   a = " + DH.a.ToString());

                    Log("Герерируем 'A' для протокола Диффи-Хеллмана");
                    DH.A = AllMath.FastExponentiation(DH.g, DH.a, DH.p);
                    Log("   A = " + DH.A.ToString());

                    string data = "[AUTH_RESPONSE]~GOOD~" + DH.p + "~" + DH.g + "~" + DH.A;
                    Send(data);
                    Log("Ключи (p, g, A) отправлены клиенту");
                }
                else
                {
                    Log("Авторизация не пройдена");
                    Log("Отправляем клиенту: " + "[AUTH_RESPONSE]~ERROR~Неверный логин и/или пароль");
                    Send("[AUTH_RESPONSE]~ERROR~Неверный логин и/или пароль");
                }
            }
        }

        private void DiffieHellmanRequest(string msg)
        {
            Log("Получен ключ 'B' для создания сессионного ключа...");

            Log("Генерируем сессионный ключ 'K' Диффи-Хеллмана");
            BigInteger B = BigInteger.Parse(msg.Split('~')[1]);
            SessionKey = AllMath.FastExponentiation(B, DH.a, DH.p);
            Log("   K = " + SessionKey.ToString());

            Send("[DH_RESPONSE]~GOOD~" + B.ToString());
        }

        private void RSARequest(string msg)
        {
            Log("Получены ключи RSA (e, n)...");
            RSA.e = BigInteger.Parse(msg.Split('~')[1].ToString());
            RSA.n = BigInteger.Parse(msg.Split('~')[2].ToString());
            Log("    e = " + RSA.e.ToString());
            Log("    n = " + RSA.n.ToString());
            Send("[RSA_RESPONSE]~GOOD");
        }

        private void DocRequest(string msg)
        {
            string filename = msg.Split('~')[1];
            string rsaSign = msg.Split('~')[2];
            string file = msg.Split('~')[3];

            Log("Получены подпись и файл от клиента");
            Log("    Файл:    " + filename);
            Log("    Подпись: " + rsaSign);

            BigInteger rsaSigNum = BigInteger.Parse(rsaSign);
            BigInteger hashNum = AllMath.FastExponentiation(rsaSigNum, RSA.e, RSA.n);
            string hashStr = hashNum.ToString("X").Remove(0, 1);
            string fileHash = GenerateMD5(file);

            // запись в файл
            using (FileStream fstream = new FileStream(filename, FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] buffer = Encoding.Default.GetBytes(file);
                // запись массива байтов в файл
                fstream.Write(buffer, 0, buffer.Length);
                Console.WriteLine("Текст записан в файл");
            }

            Log("Расшифрованный хеш: " + hashStr);
            Log("Хеш данных файла:   " + fileHash);

            if (hashStr == fileHash)
            {
                Send("[DOC_RESPONSE]~GOOD");
            }
            else
            {
                Send("[DOC_RESPONSE]~ERROR~ЭЦП не подтверждена");
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
                AddMessage(crypted, decrypted, "Клиент");
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

                AddMessage("Файл", filename, "Клиент");
            }
        }
       
        private void Connection(MyClient obj)
        {
            clients.TryAdd(obj.id, obj);
            string msg = string.Format("{0} has connected", obj.id);

            while (obj.client.Connected)
            {
                try
                {
                    obj.stream.BeginRead(obj.buffer, 0, obj.buffer.Length, new AsyncCallback(Read), obj);
                    obj.handle.WaitOne();
                }
                catch (Exception ex)
                {
                    Log(ex.ToString());
                }
            }
            obj.client.Close();
            clients.TryRemove(obj.id, out MyClient tmp);
            msg = string.Format("{0} has disconnected", tmp.id);

            Log(msg);
        }

        private void Listener(IPAddress ip, int port)
        {
            TcpListener listener = null;
            try
            {
                listener = new TcpListener(ip, port);
                listener.Start();
                Active(true);
                while (active)
                {
                    if (listener.Pending())
                    {
                        try
                        {
                            MyClient obj = new MyClient();
                            obj.id = id;
                            obj.client = listener.AcceptTcpClient();
                            obj.stream = obj.client.GetStream();
                            obj.buffer = new byte[obj.client.ReceiveBufferSize];
                            obj.data = new StringBuilder();
                            obj.handle = new EventWaitHandle(false, EventResetMode.AutoReset);
                            Thread th = new Thread(() => Connection(obj), 1024 * 1024 * 1024)
                            {
                                IsBackground = true
                            };
                            th.Start();
                            Log("Новый клиент подключился");
                            id++;
                        }
                        catch (Exception ex)
                        {
                            Log(ex.ToString());
                        }
                    }
                    else
                    {
                        Thread.Sleep(500);
                    }
                }
                Active(false);
            }
            catch (Exception ex)
            {
                Log(ex.ToString());
            }
            finally
            {
                if (listener != null)
                {
                    listener.Server.Close();
                }
            }
        }

        private void Send(string msg, long id = -1)
        {
            if (send == null || send.IsCompleted)
            {
                send = Task.Factory.StartNew(() => BeginWrite(msg, id));
            }
            else
            {
                send.ContinueWith(antecendent => BeginWrite(msg, id));
            }
        }

        private void Disconnect(long id = -1) // disconnect everyone if ID is not supplied or is lesser than zero
        {
            if (disconnect == null || !disconnect.IsAlive)
            {
                disconnect = new Thread(() =>
                {
                    if (id >= 0)
                    {
                        clients.TryGetValue(id, out MyClient obj);
                        obj.client.Close();
                    }
                    else
                    {
                        foreach (KeyValuePair<long, MyClient> obj in clients)
                        {
                            obj.Value.client.Close();
                        }
                    }
                }, 1024 * 1024 * 1024)
                {
                    IsBackground = true
                };
                disconnect.Start();
            }
        }

        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            exit = true;
            active = false;
            Disconnect();
        }

        private void Write(IAsyncResult result)
        {
            MyClient obj = (MyClient)result.AsyncState;
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

        private void BeginWrite(string msg, MyClient obj) // send the message to a specific client
        {
            byte[] buffer = Encoding.UTF8.GetBytes(msg);
            if (obj.client.Connected)
            {
                try
                {
                    obj.stream.BeginWrite(buffer, 0, buffer.Length, new AsyncCallback(Write), obj);
                }
                catch (Exception ex)
                {
                    Log(ex.ToString());
                }
            }
        }

        private void BeginWrite(string msg, long id = -1)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(msg);
            foreach (KeyValuePair<long, MyClient> obj in clients)
            {
                if (id != obj.Value.id && obj.Value.client.Connected)
                {
                    try
                    {
                        obj.Value.stream.BeginWrite(buffer, 0, buffer.Length, new AsyncCallback(Write), obj.Value);
                    }
                    catch (Exception ex)
                    {
                        Log(ex.ToString());
                    }
                }
            }
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

        private void registerButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (usernameTextbox.Text.Length == 0)
                {
                    labelRegisterResult.Text = "Введите имя пользователя";
                    labelRegisterResult.ForeColor = System.Drawing.Color.DarkRed;
                }
                else if (passwordTextbox.Text.Length == 0)
                {
                    labelRegisterResult.Text = "Введите пароль";
                    labelRegisterResult.ForeColor = System.Drawing.Color.DarkRed;
                }
                else if (passwordTextbox.Text != confirmPasswordTextbot.Text)
                {
                    labelRegisterResult.Text = "Пароли не совпадают";
                    labelRegisterResult.ForeColor = System.Drawing.Color.DarkRed;
                }
                else
                {
                    if (SqlWorker.UserExist(usernameTextbox.Text))
                    {
                        labelRegisterResult.Text = "Пользователь с таким именем уже существует";
                        labelRegisterResult.ForeColor = System.Drawing.Color.DarkRed;
                    }
                    else
                    {
                        SqlWorker.AddUser(usernameTextbox.Text, GenerateMD5(passwordTextbox.Text));
                        labelRegisterResult.Text = "Пользователь зарегистрирован успешно";
                        labelRegisterResult.ForeColor = System.Drawing.Color.DarkGreen;
                    }
                }
            }
            catch (Exception ex)
            {
                labelRegisterResult.Text = ex.ToString();
            }
        }

        private void input_tb_TextChanged(object sender, EventArgs e)
        {
            send_button.Enabled = (input_tb.Text.Length != 0);
        }

        private void send_button_Click(object sender, EventArgs e)
        {
            Des.SetKey(SessionKey);

            string text = input_tb.Text;
            input_tb.Clear();
            string cryptedText = Des.CryptString(text);            
            AddMessage(text, cryptedText, "Вы");

            Send("[MSG_FROM_SERVER]~TEXT~" + cryptedText);
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
            Send("[MSG_FROM_SERVER]~FILE~" + filename + "~" + Des.CryptString(fileContent));
            AddMessage("Файл", filePath, "Вы");
        }
    }
}
