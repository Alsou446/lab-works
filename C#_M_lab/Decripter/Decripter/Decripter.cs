using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Decripter
{
    public partial class Decripter : Form
    {
        public Decripter()
        {
            InitializeComponent();

        }

        private void button_a_Click(object sender, EventArgs e)
        {
            BigInteger A = BigInteger.Parse(textBox_A.Text);
            BigInteger g = BigInteger.Parse(textBox_g.Text);
            BigInteger p = BigInteger.Parse(textBox_p.Text);
            textBox_G_Sh_a.Text = MyMath.LogGelfond_Shenks(g, A, p).ToString();
            textBox_ro_pollard_a.Text = MyMath.roPollard(g, A, p).ToString();

        }

        private void button_K_Click(object sender, EventArgs e)
        {
            BigInteger B = BigInteger.Parse(textBox_B.Text);
            BigInteger a = BigInteger.Parse(textBox_a_for_K.Text);
            BigInteger p = BigInteger.Parse(textBox_p.Text);
            textBox_K.Text = MyMath.FastExponentiation(B, a, p).ToString();
        }

        private void button_Decript_Click(object sender, EventArgs e)
        {
            DES des = new DES();
            des.SetKey(BigInteger.Parse(textBox_K.Text));
            richTextBox_text.Text = des.DecryptString(richTextBox_shifrotext.Text);
        }

        private void button_factor_Click(object sender, EventArgs e)
        {
            BigInteger n = BigInteger.Parse(textBox_factor_num.Text);
            BigInteger a = Dixon.DixonFactorization(n);
            textBox_dix_ans1.Text = a.ToString();
            textBox_dix_ans2.Text = (n / a).ToString();
        }

        private void button_pollard_Click(object sender, EventArgs e)
        {
            BigInteger n = BigInteger.Parse(textBox_factor_num.Text);
            BigInteger a = MyMath.pollardP1_v1(n);
            textBox_ro_min_ans1.Text = a.ToString();
            textBox_ro_min_ans2.Text = (n / a).ToString();
        }

        private void button_ferma_Click(object sender, EventArgs e)
        {
            BigInteger n = BigInteger.Parse(textBox_factor_num.Text);
            BigInteger a = MyMath.ferma(n);
            textBox_ferma_ans1.Text = a.ToString();
            textBox_ferma_ans2.Text = (n / a).ToString();
        }
    }
}