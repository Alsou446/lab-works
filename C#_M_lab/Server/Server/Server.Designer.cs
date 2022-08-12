namespace Server
{
    partial class Server
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
            this.startButton = new System.Windows.Forms.Button();
            this.portLabel = new System.Windows.Forms.Label();
            this.localaddrLabel = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.logLabel = new System.Windows.Forms.Label();
            this.addrTextBox = new System.Windows.Forms.TextBox();
            this.logsRtb = new System.Windows.Forms.RichTextBox();
            this.usernameTextbox = new System.Windows.Forms.TextBox();
            this.passwordTextbox = new System.Windows.Forms.TextBox();
            this.registerButton = new System.Windows.Forms.Button();
            this.confirmPasswordTextbot = new System.Windows.Forms.TextBox();
            this.labelRegisterResult = new System.Windows.Forms.Label();
            this.chat_rtb = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.input_tb = new System.Windows.Forms.TextBox();
            this.send_button = new System.Windows.Forms.Button();
            this.file_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(13, 13);
            this.startButton.Margin = new System.Windows.Forms.Padding(4);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(116, 28);
            this.startButton.TabIndex = 23;
            this.startButton.TabStop = false;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.BackColor = System.Drawing.Color.Transparent;
            this.portLabel.Location = new System.Drawing.Point(224, 51);
            this.portLabel.Margin = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(29, 13);
            this.portLabel.TabIndex = 22;
            this.portLabel.Text = "Port:";
            // 
            // localaddrLabel
            // 
            this.localaddrLabel.AutoSize = true;
            this.localaddrLabel.BackColor = System.Drawing.Color.Transparent;
            this.localaddrLabel.Location = new System.Drawing.Point(197, 21);
            this.localaddrLabel.Margin = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this.localaddrLabel.Name = "localaddrLabel";
            this.localaddrLabel.Size = new System.Drawing.Size(48, 13);
            this.localaddrLabel.TabIndex = 21;
            this.localaddrLabel.Text = "Address:";
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(266, 48);
            this.portTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.portTextBox.MaxLength = 10;
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(132, 20);
            this.portTextBox.TabIndex = 20;
            this.portTextBox.TabStop = false;
            this.portTextBox.Text = "12321";
            this.portTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // logLabel
            // 
            this.logLabel.AutoSize = true;
            this.logLabel.BackColor = System.Drawing.Color.Transparent;
            this.logLabel.Location = new System.Drawing.Point(10, 138);
            this.logLabel.Margin = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this.logLabel.Name = "logLabel";
            this.logLabel.Size = new System.Drawing.Size(107, 13);
            this.logLabel.TabIndex = 29;
            this.logLabel.Text = "Лог обмена данных";
            // 
            // addrTextBox
            // 
            this.addrTextBox.Location = new System.Drawing.Point(266, 18);
            this.addrTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.addrTextBox.MaxLength = 200;
            this.addrTextBox.Name = "addrTextBox";
            this.addrTextBox.Size = new System.Drawing.Size(132, 20);
            this.addrTextBox.TabIndex = 37;
            this.addrTextBox.TabStop = false;
            this.addrTextBox.Text = "127.0.0.1";
            this.addrTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // logsRtb
            // 
            this.logsRtb.Font = new System.Drawing.Font("Consolas", 10F);
            this.logsRtb.Location = new System.Drawing.Point(12, 165);
            this.logsRtb.Name = "logsRtb";
            this.logsRtb.Size = new System.Drawing.Size(888, 212);
            this.logsRtb.TabIndex = 38;
            this.logsRtb.Text = "";
            // 
            // usernameTextbox
            // 
            this.usernameTextbox.Location = new System.Drawing.Point(762, 13);
            this.usernameTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.usernameTextbox.MaxLength = 200;
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.Size = new System.Drawing.Size(138, 20);
            this.usernameTextbox.TabIndex = 37;
            this.usernameTextbox.Text = "username";
            // 
            // passwordTextbox
            // 
            this.passwordTextbox.Location = new System.Drawing.Point(762, 43);
            this.passwordTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.passwordTextbox.MaxLength = 200;
            this.passwordTextbox.Name = "passwordTextbox";
            this.passwordTextbox.Size = new System.Drawing.Size(138, 20);
            this.passwordTextbox.TabIndex = 37;
            this.passwordTextbox.TabStop = false;
            this.passwordTextbox.Text = "password";
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(762, 103);
            this.registerButton.Margin = new System.Windows.Forms.Padding(4);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(138, 28);
            this.registerButton.TabIndex = 39;
            this.registerButton.TabStop = false;
            this.registerButton.Text = "Зарегистрировать";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // confirmPasswordTextbot
            // 
            this.confirmPasswordTextbot.Location = new System.Drawing.Point(762, 73);
            this.confirmPasswordTextbot.Margin = new System.Windows.Forms.Padding(4);
            this.confirmPasswordTextbot.MaxLength = 200;
            this.confirmPasswordTextbot.Name = "confirmPasswordTextbot";
            this.confirmPasswordTextbot.Size = new System.Drawing.Size(138, 20);
            this.confirmPasswordTextbot.TabIndex = 37;
            this.confirmPasswordTextbot.TabStop = false;
            this.confirmPasswordTextbot.Text = "password";
            // 
            // labelRegisterResult
            // 
            this.labelRegisterResult.AutoSize = true;
            this.labelRegisterResult.Location = new System.Drawing.Point(759, 138);
            this.labelRegisterResult.Name = "labelRegisterResult";
            this.labelRegisterResult.Size = new System.Drawing.Size(10, 13);
            this.labelRegisterResult.TabIndex = 40;
            this.labelRegisterResult.Text = " ";
            // 
            // chat_rtb
            // 
            this.chat_rtb.Font = new System.Drawing.Font("Consolas", 10F);
            this.chat_rtb.Location = new System.Drawing.Point(12, 462);
            this.chat_rtb.Name = "chat_rtb";
            this.chat_rtb.Size = new System.Drawing.Size(888, 212);
            this.chat_rtb.TabIndex = 38;
            this.chat_rtb.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(10, 439);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Окно чата";
            // 
            // input_tb
            // 
            this.input_tb.Location = new System.Drawing.Point(13, 680);
            this.input_tb.Name = "input_tb";
            this.input_tb.Size = new System.Drawing.Size(667, 20);
            this.input_tb.TabIndex = 41;
            this.input_tb.TextChanged += new System.EventHandler(this.input_tb_TextChanged);
            // 
            // send_button
            // 
            this.send_button.Enabled = false;
            this.send_button.Location = new System.Drawing.Point(686, 673);
            this.send_button.Name = "send_button";
            this.send_button.Size = new System.Drawing.Size(92, 32);
            this.send_button.TabIndex = 42;
            this.send_button.Text = "Отправить";
            this.send_button.UseVisualStyleBackColor = true;
            this.send_button.Click += new System.EventHandler(this.send_button_Click);
            // 
            // file_button
            // 
            this.file_button.Location = new System.Drawing.Point(784, 673);
            this.file_button.Name = "file_button";
            this.file_button.Size = new System.Drawing.Size(114, 32);
            this.file_button.TabIndex = 42;
            this.file_button.Text = "Отправить файл";
            this.file_button.UseVisualStyleBackColor = true;
            this.file_button.Click += new System.EventHandler(this.file_button_Click);
            // 
            // Server
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(910, 724);
            this.Controls.Add(this.file_button);
            this.Controls.Add(this.send_button);
            this.Controls.Add(this.input_tb);
            this.Controls.Add(this.labelRegisterResult);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.chat_rtb);
            this.Controls.Add(this.logsRtb);
            this.Controls.Add(this.confirmPasswordTextbot);
            this.Controls.Add(this.passwordTextbox);
            this.Controls.Add(this.usernameTextbox);
            this.Controls.Add(this.addrTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logLabel);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.localaddrLabel);
            this.Controls.Add(this.portTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Server";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Server_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Label localaddrLabel;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Label logLabel;
        private System.Windows.Forms.TextBox addrTextBox;
        private System.Windows.Forms.RichTextBox logsRtb;
        private System.Windows.Forms.TextBox usernameTextbox;
        private System.Windows.Forms.TextBox passwordTextbox;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.TextBox confirmPasswordTextbot;
        private System.Windows.Forms.Label labelRegisterResult;
        private System.Windows.Forms.RichTextBox chat_rtb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox input_tb;
        private System.Windows.Forms.Button send_button;
        private System.Windows.Forms.Button file_button;
    }
}

