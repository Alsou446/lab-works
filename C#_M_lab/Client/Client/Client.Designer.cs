namespace Client
{
    partial class Client
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.connectButton = new System.Windows.Forms.Button();
            this.portLabel = new System.Windows.Forms.Label();
            this.localaddrLabel = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.logLabel = new System.Windows.Forms.Label();
            this.addrTextBox = new System.Windows.Forms.TextBox();
            this.logsRtb = new System.Windows.Forms.RichTextBox();
            this.usernameTextbox = new System.Windows.Forms.TextBox();
            this.passwordTextbox = new System.Windows.Forms.TextBox();
            this.authButton = new System.Windows.Forms.Button();
            this.authResLabel = new System.Windows.Forms.Label();
            this.chat_rtb = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.send_button = new System.Windows.Forms.Button();
            this.input_tb = new System.Windows.Forms.TextBox();
            this.file_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(648, 10);
            this.connectButton.Margin = new System.Windows.Forms.Padding(4);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(132, 28);
            this.connectButton.TabIndex = 28;
            this.connectButton.TabStop = false;
            this.connectButton.Text = "Подключиться";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(602, 79);
            this.portLabel.Margin = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(34, 16);
            this.portLabel.TabIndex = 27;
            this.portLabel.Text = "Port:";
            // 
            // localaddrLabel
            // 
            this.localaddrLabel.AutoSize = true;
            this.localaddrLabel.Location = new System.Drawing.Point(576, 49);
            this.localaddrLabel.Margin = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this.localaddrLabel.Name = "localaddrLabel";
            this.localaddrLabel.Size = new System.Drawing.Size(61, 16);
            this.localaddrLabel.TabIndex = 26;
            this.localaddrLabel.Text = "Address:";
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(648, 76);
            this.portTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.portTextBox.MaxLength = 10;
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(132, 22);
            this.portTextBox.TabIndex = 25;
            this.portTextBox.TabStop = false;
            this.portTextBox.Text = "12321";
            this.portTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // logLabel
            // 
            this.logLabel.AutoSize = true;
            this.logLabel.Location = new System.Drawing.Point(10, 100);
            this.logLabel.Margin = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this.logLabel.Name = "logLabel";
            this.logLabel.Size = new System.Drawing.Size(132, 16);
            this.logLabel.TabIndex = 31;
            this.logLabel.Text = "Лог обмена данных";
            // 
            // addrTextBox
            // 
            this.addrTextBox.Location = new System.Drawing.Point(648, 46);
            this.addrTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.addrTextBox.MaxLength = 200;
            this.addrTextBox.Name = "addrTextBox";
            this.addrTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.addrTextBox.Size = new System.Drawing.Size(132, 22);
            this.addrTextBox.TabIndex = 39;
            this.addrTextBox.TabStop = false;
            this.addrTextBox.Text = "127.0.0.1";
            this.addrTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // logsRtb
            // 
            this.logsRtb.Font = new System.Drawing.Font("Consolas", 10F);
            this.logsRtb.Location = new System.Drawing.Point(12, 123);
            this.logsRtb.Name = "logsRtb";
            this.logsRtb.Size = new System.Drawing.Size(768, 262);
            this.logsRtb.TabIndex = 42;
            this.logsRtb.Text = "";
            // 
            // usernameTextbox
            // 
            this.usernameTextbox.Location = new System.Drawing.Point(137, 10);
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.Size = new System.Drawing.Size(159, 22);
            this.usernameTextbox.TabIndex = 43;
            // 
            // passwordTextbox
            // 
            this.passwordTextbox.Location = new System.Drawing.Point(137, 38);
            this.passwordTextbox.Name = "passwordTextbox";
            this.passwordTextbox.Size = new System.Drawing.Size(159, 22);
            this.passwordTextbox.TabIndex = 43;
            // 
            // authButton
            // 
            this.authButton.Location = new System.Drawing.Point(12, 10);
            this.authButton.Margin = new System.Windows.Forms.Padding(4);
            this.authButton.Name = "authButton";
            this.authButton.Size = new System.Drawing.Size(116, 28);
            this.authButton.TabIndex = 28;
            this.authButton.TabStop = false;
            this.authButton.Text = "Авторизация";
            this.authButton.UseVisualStyleBackColor = true;
            this.authButton.Click += new System.EventHandler(this.authButton_Click);
            // 
            // authResLabel
            // 
            this.authResLabel.AutoSize = true;
            this.authResLabel.Location = new System.Drawing.Point(137, 67);
            this.authResLabel.Name = "authResLabel";
            this.authResLabel.Size = new System.Drawing.Size(10, 16);
            this.authResLabel.TabIndex = 44;
            this.authResLabel.Text = " ";
            // 
            // chat_rtb
            // 
            this.chat_rtb.Font = new System.Drawing.Font("Consolas", 10F);
            this.chat_rtb.Location = new System.Drawing.Point(12, 416);
            this.chat_rtb.Name = "chat_rtb";
            this.chat_rtb.Size = new System.Drawing.Size(768, 262);
            this.chat_rtb.TabIndex = 42;
            this.chat_rtb.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 393);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 31;
            this.label1.Text = "Окно чата";
            // 
            // send_button
            // 
            this.send_button.Enabled = false;
            this.send_button.Location = new System.Drawing.Point(581, 678);
            this.send_button.Name = "send_button";
            this.send_button.Size = new System.Drawing.Size(75, 31);
            this.send_button.TabIndex = 45;
            this.send_button.Text = "Отправить";
            this.send_button.UseVisualStyleBackColor = true;
            this.send_button.Click += new System.EventHandler(this.send_button_Click);
            // 
            // input_tb
            // 
            this.input_tb.Location = new System.Drawing.Point(13, 684);
            this.input_tb.Name = "input_tb";
            this.input_tb.Size = new System.Drawing.Size(562, 22);
            this.input_tb.TabIndex = 46;
            this.input_tb.TextChanged += new System.EventHandler(this.input_tb_TextChanged);
            // 
            // file_button
            // 
            this.file_button.Location = new System.Drawing.Point(662, 678);
            this.file_button.Name = "file_button";
            this.file_button.Size = new System.Drawing.Size(112, 31);
            this.file_button.TabIndex = 45;
            this.file_button.Text = "Отправить файл";
            this.file_button.UseVisualStyleBackColor = true;
            this.file_button.Click += new System.EventHandler(this.file_button_Click);
            // 
            // Client
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(786, 723);
            this.Controls.Add(this.input_tb);
            this.Controls.Add(this.file_button);
            this.Controls.Add(this.send_button);
            this.Controls.Add(this.authResLabel);
            this.Controls.Add(this.passwordTextbox);
            this.Controls.Add(this.usernameTextbox);
            this.Controls.Add(this.chat_rtb);
            this.Controls.Add(this.logsRtb);
            this.Controls.Add(this.addrTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logLabel);
            this.Controls.Add(this.authButton);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.localaddrLabel);
            this.Controls.Add(this.portTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Client";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Client_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Label localaddrLabel;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Label logLabel;
        private System.Windows.Forms.TextBox addrTextBox;
        private System.Windows.Forms.RichTextBox logsRtb;
        private System.Windows.Forms.TextBox usernameTextbox;
        private System.Windows.Forms.TextBox passwordTextbox;
        private System.Windows.Forms.Button authButton;
        private System.Windows.Forms.Label authResLabel;
        private System.Windows.Forms.RichTextBox chat_rtb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button send_button;
        private System.Windows.Forms.TextBox input_tb;
        private System.Windows.Forms.Button file_button;
    }
}

