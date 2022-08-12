namespace Decripter
{
    partial class Decripter
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_A = new System.Windows.Forms.TextBox();
            this.button_a = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_g = new System.Windows.Forms.TextBox();
            this.textBox_p = new System.Windows.Forms.TextBox();
            this.textBox_G_Sh_a = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_ro_pollard_a = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox_K = new System.Windows.Forms.TextBox();
            this.button_K = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_B = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_a_for_K = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.richTextBox_text = new System.Windows.Forms.RichTextBox();
            this.button_Decript = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.richTextBox_shifrotext = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button_ferma = new System.Windows.Forms.Button();
            this.button_pollard = new System.Windows.Forms.Button();
            this.textBox_ferma_ans2 = new System.Windows.Forms.TextBox();
            this.textBox_ferma_ans1 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.textBox_ro_min_ans2 = new System.Windows.Forms.TextBox();
            this.textBox_ro_min_ans1 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.textBox_dix_ans2 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.textBox_dix_ans1 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.button_factor_dixon = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox_factor_num = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "A = ";
            // 
            // textBox_A
            // 
            this.textBox_A.Location = new System.Drawing.Point(67, 59);
            this.textBox_A.Name = "textBox_A";
            this.textBox_A.Size = new System.Drawing.Size(390, 29);
            this.textBox_A.TabIndex = 1;
            // 
            // button_a
            // 
            this.button_a.Location = new System.Drawing.Point(200, 182);
            this.button_a.Name = "button_a";
            this.button_a.Size = new System.Drawing.Size(111, 30);
            this.button_a.TabIndex = 2;
            this.button_a.Text = "Вычислить a";
            this.button_a.UseVisualStyleBackColor = true;
            this.button_a.Click += new System.EventHandler(this.button_a_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(167, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Алгоритм Гельфонда — Шенкса";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(226, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "A = g^a mod p";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "g = ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 21);
            this.label5.TabIndex = 6;
            this.label5.Text = "p = ";
            // 
            // textBox_g
            // 
            this.textBox_g.Location = new System.Drawing.Point(67, 96);
            this.textBox_g.Name = "textBox_g";
            this.textBox_g.Size = new System.Drawing.Size(390, 29);
            this.textBox_g.TabIndex = 7;
            // 
            // textBox_p
            // 
            this.textBox_p.Location = new System.Drawing.Point(67, 134);
            this.textBox_p.Name = "textBox_p";
            this.textBox_p.Size = new System.Drawing.Size(390, 29);
            this.textBox_p.TabIndex = 8;
            // 
            // textBox_G_Sh_a
            // 
            this.textBox_G_Sh_a.Location = new System.Drawing.Point(67, 254);
            this.textBox_G_Sh_a.Name = "textBox_G_Sh_a";
            this.textBox_G_Sh_a.ReadOnly = true;
            this.textBox_G_Sh_a.Size = new System.Drawing.Size(390, 29);
            this.textBox_G_Sh_a.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 254);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 21);
            this.label6.TabIndex = 9;
            this.label6.Text = "a = ";
            // 
            // textBox_ro_pollard_a
            // 
            this.textBox_ro_pollard_a.Location = new System.Drawing.Point(67, 325);
            this.textBox_ro_pollard_a.Name = "textBox_ro_pollard_a";
            this.textBox_ro_pollard_a.ReadOnly = true;
            this.textBox_ro_pollard_a.Size = new System.Drawing.Size(390, 29);
            this.textBox_ro_pollard_a.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 325);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 21);
            this.label7.TabIndex = 12;
            this.label7.Text = "a = ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(200, 301);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(175, 21);
            this.label8.TabIndex = 11;
            this.label8.Text = "Ро-алгоритм Полларда";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_ro_pollard_a);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBox_A);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.button_a);
            this.groupBox1.Controls.Add(this.textBox_G_Sh_a);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox_p);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox_g);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(482, 375);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Взлом закрытого ключа a";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.textBox_K);
            this.groupBox2.Controls.Add(this.button_K);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.textBox_B);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.textBox_a_for_K);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(500, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(460, 231);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Вычисление сессионного ключа K";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 182);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 21);
            this.label15.TabIndex = 13;
            this.label15.Text = "K = ";
            // 
            // textBox_K
            // 
            this.textBox_K.Location = new System.Drawing.Point(54, 182);
            this.textBox_K.Name = "textBox_K";
            this.textBox_K.ReadOnly = true;
            this.textBox_K.Size = new System.Drawing.Size(390, 29);
            this.textBox_K.TabIndex = 14;
            // 
            // button_K
            // 
            this.button_K.Location = new System.Drawing.Point(179, 134);
            this.button_K.Name = "button_K";
            this.button_K.Size = new System.Drawing.Size(111, 30);
            this.button_K.TabIndex = 12;
            this.button_K.Text = "Вычислить K";
            this.button_K.UseVisualStyleBackColor = true;
            this.button_K.Click += new System.EventHandler(this.button_K_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 21);
            this.label10.TabIndex = 8;
            this.label10.Text = "B = ";
            // 
            // textBox_B
            // 
            this.textBox_B.Location = new System.Drawing.Point(54, 59);
            this.textBox_B.Name = "textBox_B";
            this.textBox_B.Size = new System.Drawing.Size(390, 29);
            this.textBox_B.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 21);
            this.label11.TabIndex = 10;
            this.label11.Text = "a = ";
            // 
            // textBox_a_for_K
            // 
            this.textBox_a_for_K.Location = new System.Drawing.Point(54, 96);
            this.textBox_a_for_K.Name = "textBox_a_for_K";
            this.textBox_a_for_K.Size = new System.Drawing.Size(390, 29);
            this.textBox_a_for_K.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(162, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 21);
            this.label9.TabIndex = 5;
            this.label9.Text = "K = B^a mod p";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.richTextBox_text);
            this.groupBox3.Controls.Add(this.button_Decript);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.richTextBox_shifrotext);
            this.groupBox3.Location = new System.Drawing.Point(966, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(511, 346);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Дешифровка";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(29, 241);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 21);
            this.label14.TabIndex = 17;
            this.label14.Text = "Текст";
            // 
            // richTextBox_text
            // 
            this.richTextBox_text.Location = new System.Drawing.Point(106, 197);
            this.richTextBox_text.Name = "richTextBox_text";
            this.richTextBox_text.ReadOnly = true;
            this.richTextBox_text.Size = new System.Drawing.Size(390, 125);
            this.richTextBox_text.TabIndex = 16;
            this.richTextBox_text.Text = "";
            // 
            // button_Decript
            // 
            this.button_Decript.Location = new System.Drawing.Point(219, 153);
            this.button_Decript.Name = "button_Decript";
            this.button_Decript.Size = new System.Drawing.Size(133, 30);
            this.button_Decript.TabIndex = 15;
            this.button_Decript.Text = "Расшифровать";
            this.button_Decript.UseVisualStyleBackColor = true;
            this.button_Decript.Click += new System.EventHandler(this.button_Decript_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 67);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 21);
            this.label12.TabIndex = 14;
            this.label12.Text = "Шифротекст";
            // 
            // richTextBox_shifrotext
            // 
            this.richTextBox_shifrotext.Location = new System.Drawing.Point(106, 22);
            this.richTextBox_shifrotext.Name = "richTextBox_shifrotext";
            this.richTextBox_shifrotext.Size = new System.Drawing.Size(390, 125);
            this.richTextBox_shifrotext.TabIndex = 0;
            this.richTextBox_shifrotext.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button_ferma);
            this.groupBox4.Controls.Add(this.button_pollard);
            this.groupBox4.Controls.Add(this.textBox_ferma_ans2);
            this.groupBox4.Controls.Add(this.textBox_ferma_ans1);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.textBox_ro_min_ans2);
            this.groupBox4.Controls.Add(this.textBox_ro_min_ans1);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.textBox_dix_ans2);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.textBox_dix_ans1);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.button_factor_dixon);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.textBox_factor_num);
            this.groupBox4.Location = new System.Drawing.Point(12, 414);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1336, 291);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Факторизация";
            // 
            // button_ferma
            // 
            this.button_ferma.Location = new System.Drawing.Point(1033, 224);
            this.button_ferma.Name = "button_ferma";
            this.button_ferma.Size = new System.Drawing.Size(157, 30);
            this.button_ferma.TabIndex = 23;
            this.button_ferma.Text = "Факторизировать";
            this.button_ferma.UseVisualStyleBackColor = true;
            this.button_ferma.Click += new System.EventHandler(this.button_ferma_Click);
            // 
            // button_pollard
            // 
            this.button_pollard.Location = new System.Drawing.Point(588, 224);
            this.button_pollard.Name = "button_pollard";
            this.button_pollard.Size = new System.Drawing.Size(157, 30);
            this.button_pollard.TabIndex = 22;
            this.button_pollard.Text = "Факторизировать";
            this.button_pollard.UseVisualStyleBackColor = true;
            this.button_pollard.Click += new System.EventHandler(this.button_pollard_Click);
            // 
            // textBox_ferma_ans2
            // 
            this.textBox_ferma_ans2.Location = new System.Drawing.Point(905, 177);
            this.textBox_ferma_ans2.Name = "textBox_ferma_ans2";
            this.textBox_ferma_ans2.ReadOnly = true;
            this.textBox_ferma_ans2.Size = new System.Drawing.Size(390, 29);
            this.textBox_ferma_ans2.TabIndex = 21;
            // 
            // textBox_ferma_ans1
            // 
            this.textBox_ferma_ans1.Location = new System.Drawing.Point(905, 142);
            this.textBox_ferma_ans1.Name = "textBox_ferma_ans1";
            this.textBox_ferma_ans1.ReadOnly = true;
            this.textBox_ferma_ans1.Size = new System.Drawing.Size(390, 29);
            this.textBox_ferma_ans1.TabIndex = 20;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(1033, 118);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(131, 21);
            this.label21.TabIndex = 19;
            this.label21.Text = "Алгоритм Ферма";
            // 
            // textBox_ro_min_ans2
            // 
            this.textBox_ro_min_ans2.Location = new System.Drawing.Point(488, 177);
            this.textBox_ro_min_ans2.Name = "textBox_ro_min_ans2";
            this.textBox_ro_min_ans2.ReadOnly = true;
            this.textBox_ro_min_ans2.Size = new System.Drawing.Size(390, 29);
            this.textBox_ro_min_ans2.TabIndex = 18;
            // 
            // textBox_ro_min_ans1
            // 
            this.textBox_ro_min_ans1.Location = new System.Drawing.Point(488, 142);
            this.textBox_ro_min_ans1.Name = "textBox_ro_min_ans1";
            this.textBox_ro_min_ans1.ReadOnly = true;
            this.textBox_ro_min_ans1.Size = new System.Drawing.Size(390, 29);
            this.textBox_ro_min_ans1.TabIndex = 17;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(588, 118);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(208, 21);
            this.label20.TabIndex = 16;
            this.label20.Text = "Алгоритм (ро - 1) Полларда";
            // 
            // textBox_dix_ans2
            // 
            this.textBox_dix_ans2.Location = new System.Drawing.Point(69, 177);
            this.textBox_dix_ans2.Name = "textBox_dix_ans2";
            this.textBox_dix_ans2.ReadOnly = true;
            this.textBox_dix_ans2.Size = new System.Drawing.Size(390, 29);
            this.textBox_dix_ans2.TabIndex = 15;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(24, 220);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(0, 21);
            this.label19.TabIndex = 14;
            // 
            // textBox_dix_ans1
            // 
            this.textBox_dix_ans1.Location = new System.Drawing.Point(69, 142);
            this.textBox_dix_ans1.Name = "textBox_dix_ans1";
            this.textBox_dix_ans1.ReadOnly = true;
            this.textBox_dix_ans1.Size = new System.Drawing.Size(390, 29);
            this.textBox_dix_ans1.TabIndex = 13;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(169, 118);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(144, 21);
            this.label17.TabIndex = 11;
            this.label17.Text = "Алгоритм Диксона";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(24, 185);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(0, 21);
            this.label18.TabIndex = 12;
            // 
            // button_factor_dixon
            // 
            this.button_factor_dixon.Location = new System.Drawing.Point(169, 224);
            this.button_factor_dixon.Name = "button_factor_dixon";
            this.button_factor_dixon.Size = new System.Drawing.Size(157, 30);
            this.button_factor_dixon.TabIndex = 4;
            this.button_factor_dixon.Text = "Факторизировать";
            this.button_factor_dixon.UseVisualStyleBackColor = true;
            this.button_factor_dixon.Click += new System.EventHandler(this.button_factor_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(443, 54);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 21);
            this.label16.TabIndex = 2;
            this.label16.Text = "n = ";
            // 
            // textBox_factor_num
            // 
            this.textBox_factor_num.Location = new System.Drawing.Point(488, 51);
            this.textBox_factor_num.Name = "textBox_factor_num";
            this.textBox_factor_num.Size = new System.Drawing.Size(390, 29);
            this.textBox_factor_num.TabIndex = 3;
            this.textBox_factor_num.Text = "12709189";
            // 
            // Decripter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1498, 730);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Decripter";
            this.Text = "Decripter";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private TextBox textBox_A;
        private Button button_a;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBox_g;
        private TextBox textBox_p;
        private TextBox textBox_G_Sh_a;
        private Label label6;
        private TextBox textBox_ro_pollard_a;
        private Label label7;
        private Label label8;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label15;
        private TextBox textBox_K;
        private Button button_K;
        private Label label10;
        private TextBox textBox_B;
        private Label label11;
        private TextBox textBox_a_for_K;
        private Label label9;
        private GroupBox groupBox3;
        private Label label12;
        private RichTextBox richTextBox_shifrotext;
        private Label label13;
        private Button button_Decript;
        private Label label14;
        private RichTextBox richTextBox_text;
        private GroupBox groupBox4;
        private TextBox textBox_ro_min_ans2;
        private TextBox textBox_ro_min_ans1;
        private Label label20;
        private TextBox textBox_dix_ans2;
        private Label label19;
        private TextBox textBox_dix_ans1;
        private Label label17;
        private Label label18;
        private Button button_factor_dixon;
        private Label label16;
        private TextBox textBox_factor_num;
        private Button button_ferma;
        private Button button_pollard;
        private TextBox textBox_ferma_ans2;
        private TextBox textBox_ferma_ans1;
        private Label label21;
    }
}