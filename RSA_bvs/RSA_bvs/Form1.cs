using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Numerics;

namespace RSA_bvs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_genKeys_Click(object sender, EventArgs e_)
        {
            richTextBoxP.Text = richTextBoxQ.Text = richTextBoxN.Text = richTextBoxFi.Text = richTextBoxE.Text = richTextBoxD.Text = "";
            if (!MyMath.IsNumberValid(textBox_bits.Text))
            {
                MessageBox.Show("Неверный формат битности");
                return;
            }

            if(Convert.ToInt32(textBox_bits.Text) < 32)
            {
                MessageBox.Show("Введите битность не мение 32");
                return;
            }

            int bits = Convert.ToInt32(textBox_bits.Text);

            BigInteger p = MyMath.GenerateRandomBigInt(bits);
            richTextBoxP.Text = p.ToString();

            BigInteger q = MyMath.GenerateRandomBigInt(bits);
            richTextBoxQ.Text = q.ToString();

            BigInteger n = p * q;
            richTextBoxN.Text = n.ToString();

            // Ф-ия Эйлера
            BigInteger fi = (p - 1) * (q - 1);
            richTextBoxFi.Text = fi.ToString();

            BigInteger e = 0;

            BigInteger x, y, gcd;

            while (true)
            {
                e = MyMath.GenerateRandomBigInt(bits);
                if (e < 2 || e >= n)
                {
                    continue;
                }

                (gcd, x, y) = MyMath.Evclid(e, fi);

                if (gcd == 1)
                {
                    richTextBoxE.Text = e.ToString();
                    break;
                }
            }

            (x, y, gcd) = MyMath.Evclid(e, fi);

            BigInteger d = y; // Обратный к 'e' по модулю 'fi' элемент, т.е. e * d mod fi = 1
            if (d < 0)
            {
                d += fi;
            }
            richTextBoxD.Text = d.ToString();
        }

        private void button_crypt_Click(object sender, EventArgs e_)
        {
            richTextBox_cryptedMsg.Text = "";
            progressBar1.Value = 0;
            if (richTextBox_msg.Text.Length == 0)
            {
                MessageBox.Show("Введите сообщение для шифрования");
                return;
            }

            if (!MyMath.IsNumberValid(richTextBoxN.Text) || !MyMath.IsNumberValid(richTextBoxE.Text) || !MyMath.IsNumberValid(richTextBoxD.Text) || !MyMath.IsNumberValid(richTextBoxFi.Text))
            {
                MessageBox.Show("Неверный формат ключей");
                return;
            }

            BigInteger fi = BigInteger.Parse(richTextBoxFi.Text);
            BigInteger n = BigInteger.Parse(richTextBoxN.Text);
            BigInteger e = BigInteger.Parse(richTextBoxE.Text);
            BigInteger d = BigInteger.Parse(richTextBoxD.Text);

            if (!MyMath.CheckRSAKeys(e, d, fi))
            {
                MessageBox.Show("Ключи не корректны,\n(e * d) mod fi != 1");
                return;
            }
            progressBar1.Minimum = 0;
            progressBar1.Maximum = richTextBox_msg.Text.Length - 1;
            foreach (char m in richTextBox_msg.Text)
            {
                string newCode = MyMath.FastExponentiation(m, e, n).ToString();
                richTextBox_cryptedMsg.Text += newCode + " ";
                progressBar1.PerformStep();
            }
        }

        private void button_decrypt_Click(object sender, EventArgs e_)
        {
            richTextBox_decryptedMsg.Text = "";
            progressBar2.Value = 0;
            string cryptedMsg = richTextBox_cryptedMsg.Text;
            if (cryptedMsg.Length == 0)
            {
                MessageBox.Show("Введите сообщение для дешифрования");
                return;
            }

            while (cryptedMsg.Contains("  "))
            {
                cryptedMsg = cryptedMsg.Replace("  ", " ");
            }
            while (cryptedMsg.Contains("\n"))
            {
                cryptedMsg = cryptedMsg.Replace("\n", "");
            }
            if (cryptedMsg[0] == ' ')
            {
                cryptedMsg = cryptedMsg.Remove(0, 1);
            }
            if (cryptedMsg[cryptedMsg.Length - 1] == ' ')
            {
                cryptedMsg = cryptedMsg.Remove(cryptedMsg.Length - 1, 1);
            }
           
            foreach (char i in cryptedMsg)
            {
                if ((i < '0' || i > '9') && i != ' ')
                {
                    MessageBox.Show("Невалидный код для расшифровки");
                    return;
                }
            }

            richTextBox_cryptedMsg.Text = cryptedMsg;

            if (!MyMath.IsNumberValid(richTextBoxN.Text) || !MyMath.IsNumberValid(richTextBoxE.Text) || !MyMath.IsNumberValid(richTextBoxD.Text) || !MyMath.IsNumberValid(richTextBoxFi.Text))
            {
                MessageBox.Show("Неверный формат ключей");
                return;
            }

            BigInteger fi = BigInteger.Parse(richTextBoxFi.Text);
            BigInteger n = BigInteger.Parse(richTextBoxN.Text);
            BigInteger e = BigInteger.Parse(richTextBoxE.Text);
            BigInteger d = BigInteger.Parse(richTextBoxD.Text);

            if (!MyMath.CheckRSAKeys(e, d, fi))
            {
                MessageBox.Show("Ключи не корректны,\n(e * d) mod fi != 1");
                return;
            }

            var splittedMsg = cryptedMsg.Split(' ');
            progressBar2.Minimum = 0;
            progressBar2.Maximum = splittedMsg.Length - 1;

            foreach (string code in splittedMsg)
            {
                BigInteger c = BigInteger.Parse(code);
                BigInteger m = MyMath.FastExponentiation(c, d, n) % 32767;

                short newSym;
                bool isParsable = Int16.TryParse(m.ToString(), out newSym);
                if (!isParsable)
                {
                    richTextBox_decryptedMsg.Text += "[error]";
                }
                else
                {
                    richTextBox_decryptedMsg.Text += (char)newSym;
                }
                progressBar2.PerformStep();
            }
        }
    }
}
