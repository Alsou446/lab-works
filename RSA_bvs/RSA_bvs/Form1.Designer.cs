
namespace RSA_bvs
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBoxP = new System.Windows.Forms.RichTextBox();
            this.richTextBoxQ = new System.Windows.Forms.RichTextBox();
            this.richTextBoxN = new System.Windows.Forms.RichTextBox();
            this.richTextBoxFi = new System.Windows.Forms.RichTextBox();
            this.richTextBoxE = new System.Windows.Forms.RichTextBox();
            this.richTextBoxD = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_bits = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button_genKeys = new System.Windows.Forms.Button();
            this.richTextBox_msg = new System.Windows.Forms.RichTextBox();
            this.richTextBox_cryptedMsg = new System.Windows.Forms.RichTextBox();
            this.button_crypt = new System.Windows.Forms.Button();
            this.button_decrypt = new System.Windows.Forms.Button();
            this.richTextBox_decryptedMsg = new System.Windows.Forms.RichTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // richTextBoxP
            // 
            this.richTextBoxP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.096F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxP.Location = new System.Drawing.Point(131, 95);
            this.richTextBoxP.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBoxP.Name = "richTextBoxP";
            this.richTextBoxP.Size = new System.Drawing.Size(410, 83);
            this.richTextBoxP.TabIndex = 0;
            this.richTextBoxP.Text = "";
            // 
            // richTextBoxQ
            // 
            this.richTextBoxQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.096F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxQ.Location = new System.Drawing.Point(131, 191);
            this.richTextBoxQ.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBoxQ.Name = "richTextBoxQ";
            this.richTextBoxQ.Size = new System.Drawing.Size(410, 83);
            this.richTextBoxQ.TabIndex = 1;
            this.richTextBoxQ.Text = "";
            // 
            // richTextBoxN
            // 
            this.richTextBoxN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.096F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxN.Location = new System.Drawing.Point(131, 286);
            this.richTextBoxN.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBoxN.Name = "richTextBoxN";
            this.richTextBoxN.Size = new System.Drawing.Size(410, 83);
            this.richTextBoxN.TabIndex = 2;
            this.richTextBoxN.Text = "";
            // 
            // richTextBoxFi
            // 
            this.richTextBoxFi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.096F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxFi.Location = new System.Drawing.Point(131, 382);
            this.richTextBoxFi.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBoxFi.Name = "richTextBoxFi";
            this.richTextBoxFi.Size = new System.Drawing.Size(410, 83);
            this.richTextBoxFi.TabIndex = 3;
            this.richTextBoxFi.Text = "";
            // 
            // richTextBoxE
            // 
            this.richTextBoxE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.096F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxE.Location = new System.Drawing.Point(131, 476);
            this.richTextBoxE.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBoxE.Name = "richTextBoxE";
            this.richTextBoxE.Size = new System.Drawing.Size(410, 83);
            this.richTextBoxE.TabIndex = 4;
            this.richTextBoxE.Text = "";
            // 
            // richTextBoxD
            // 
            this.richTextBoxD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.096F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxD.Location = new System.Drawing.Point(131, 571);
            this.richTextBoxD.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBoxD.Name = "richTextBoxD";
            this.richTextBoxD.Size = new System.Drawing.Size(410, 83);
            this.richTextBoxD.TabIndex = 5;
            this.richTextBoxD.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.096F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(67, 99);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "p=";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.096F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(67, 195);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "q=";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.096F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(25, 386);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "φ(n)=";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.096F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(67, 291);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "n=";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.096F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(67, 482);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "e=";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.096F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(67, 576);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "d=";
            // 
            // textBox_bits
            // 
            this.textBox_bits.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.096F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_bits.Location = new System.Drawing.Point(131, 9);
            this.textBox_bits.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_bits.Name = "textBox_bits";
            this.textBox_bits.Size = new System.Drawing.Size(148, 31);
            this.textBox_bits.TabIndex = 12;
            this.textBox_bits.Text = "512";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.096F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(13, 9);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 25);
            this.label7.TabIndex = 13;
            this.label7.Text = "Битность:";
            // 
            // button_genKeys
            // 
            this.button_genKeys.Location = new System.Drawing.Point(131, 47);
            this.button_genKeys.Name = "button_genKeys";
            this.button_genKeys.Size = new System.Drawing.Size(240, 41);
            this.button_genKeys.TabIndex = 14;
            this.button_genKeys.Text = "Сгенерировать ключи";
            this.button_genKeys.UseVisualStyleBackColor = true;
            this.button_genKeys.Click += new System.EventHandler(this.button_genKeys_Click);
            // 
            // richTextBox_msg
            // 
            this.richTextBox_msg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.096F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox_msg.Location = new System.Drawing.Point(725, 95);
            this.richTextBox_msg.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox_msg.Name = "richTextBox_msg";
            this.richTextBox_msg.Size = new System.Drawing.Size(614, 200);
            this.richTextBox_msg.TabIndex = 0;
            this.richTextBox_msg.Text = "";
            // 
            // richTextBox_cryptedMsg
            // 
            this.richTextBox_cryptedMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.096F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox_cryptedMsg.Location = new System.Drawing.Point(725, 350);
            this.richTextBox_cryptedMsg.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox_cryptedMsg.Name = "richTextBox_cryptedMsg";
            this.richTextBox_cryptedMsg.Size = new System.Drawing.Size(614, 110);
            this.richTextBox_cryptedMsg.TabIndex = 0;
            this.richTextBox_cryptedMsg.Text = "";
            // 
            // button_crypt
            // 
            this.button_crypt.Location = new System.Drawing.Point(725, 302);
            this.button_crypt.Name = "button_crypt";
            this.button_crypt.Size = new System.Drawing.Size(240, 41);
            this.button_crypt.TabIndex = 14;
            this.button_crypt.Text = "Зашифровать";
            this.button_crypt.UseVisualStyleBackColor = true;
            this.button_crypt.Click += new System.EventHandler(this.button_crypt_Click);
            // 
            // button_decrypt
            // 
            this.button_decrypt.Location = new System.Drawing.Point(725, 467);
            this.button_decrypt.Name = "button_decrypt";
            this.button_decrypt.Size = new System.Drawing.Size(240, 41);
            this.button_decrypt.TabIndex = 14;
            this.button_decrypt.Text = "Расшифровать";
            this.button_decrypt.UseVisualStyleBackColor = true;
            this.button_decrypt.Click += new System.EventHandler(this.button_decrypt_Click);
            // 
            // richTextBox_decryptedMsg
            // 
            this.richTextBox_decryptedMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.096F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox_decryptedMsg.Location = new System.Drawing.Point(725, 515);
            this.richTextBox_decryptedMsg.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox_decryptedMsg.Name = "richTextBox_decryptedMsg";
            this.richTextBox_decryptedMsg.Size = new System.Drawing.Size(614, 200);
            this.richTextBox_decryptedMsg.TabIndex = 0;
            this.richTextBox_decryptedMsg.Text = "";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(971, 302);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(368, 41);
            this.progressBar1.TabIndex = 15;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(971, 467);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(368, 41);
            this.progressBar2.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 947);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button_decrypt);
            this.Controls.Add(this.button_crypt);
            this.Controls.Add(this.button_genKeys);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_bits);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBoxD);
            this.Controls.Add(this.richTextBoxE);
            this.Controls.Add(this.richTextBoxFi);
            this.Controls.Add(this.richTextBoxN);
            this.Controls.Add(this.richTextBoxQ);
            this.Controls.Add(this.richTextBox_decryptedMsg);
            this.Controls.Add(this.richTextBox_cryptedMsg);
            this.Controls.Add(this.richTextBox_msg);
            this.Controls.Add(this.richTextBoxP);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.096F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "RSA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxP;
        private System.Windows.Forms.RichTextBox richTextBoxQ;
        private System.Windows.Forms.RichTextBox richTextBoxN;
        private System.Windows.Forms.RichTextBox richTextBoxFi;
        private System.Windows.Forms.RichTextBox richTextBoxE;
        private System.Windows.Forms.RichTextBox richTextBoxD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_bits;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_genKeys;
        private System.Windows.Forms.RichTextBox richTextBox_msg;
        private System.Windows.Forms.RichTextBox richTextBox_cryptedMsg;
        private System.Windows.Forms.Button button_crypt;
        private System.Windows.Forms.Button button_decrypt;
        private System.Windows.Forms.RichTextBox richTextBox_decryptedMsg;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
    }
}

