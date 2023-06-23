namespace SocketTCP
{
    partial class FormTcpClient
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
            btn_selectFile = new Button();
            txt_selectFile = new TextBox();
            txt_send = new TextBox();
            txt_msg = new TextBox();
            label2 = new Label();
            label1 = new Label();
            txt_Port = new TextBox();
            txt_IP = new TextBox();
            btn_Connect = new Button();
            btn_send = new Button();
            btn_sendFile = new Button();
            label3 = new Label();
            txt_name = new TextBox();
            SuspendLayout();
            // 
            // btn_selectFile
            // 
            btn_selectFile.Location = new Point(415, 615);
            btn_selectFile.Name = "btn_selectFile";
            btn_selectFile.Size = new Size(150, 46);
            btn_selectFile.TabIndex = 16;
            btn_selectFile.Text = "选择文件";
            btn_selectFile.UseVisualStyleBackColor = true;
            btn_selectFile.Click += btn_selectFile_Click;
            // 
            // txt_selectFile
            // 
            txt_selectFile.Location = new Point(29, 613);
            txt_selectFile.Multiline = true;
            txt_selectFile.Name = "txt_selectFile";
            txt_selectFile.Size = new Size(380, 48);
            txt_selectFile.TabIndex = 15;
            // 
            // txt_send
            // 
            txt_send.Location = new Point(29, 328);
            txt_send.Multiline = true;
            txt_send.Name = "txt_send";
            txt_send.ScrollBars = ScrollBars.Vertical;
            txt_send.Size = new Size(521, 261);
            txt_send.TabIndex = 14;
            // 
            // txt_msg
            // 
            txt_msg.Location = new Point(29, 19);
            txt_msg.Multiline = true;
            txt_msg.Name = "txt_msg";
            txt_msg.ScrollBars = ScrollBars.Vertical;
            txt_msg.Size = new Size(521, 261);
            txt_msg.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(567, 149);
            label2.Name = "label2";
            label2.Size = new Size(158, 31);
            label2.TabIndex = 20;
            label2.Text = "服务器端口号";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(569, 79);
            label1.Name = "label1";
            label1.Size = new Size(156, 31);
            label1.TabIndex = 19;
            label1.Text = "服务器IP地址";
            // 
            // txt_Port
            // 
            txt_Port.Location = new Point(731, 149);
            txt_Port.Name = "txt_Port";
            txt_Port.Size = new Size(200, 38);
            txt_Port.TabIndex = 18;
            txt_Port.Text = "1234";
            // 
            // txt_IP
            // 
            txt_IP.Location = new Point(731, 79);
            txt_IP.Name = "txt_IP";
            txt_IP.Size = new Size(200, 38);
            txt_IP.TabIndex = 17;
            txt_IP.Text = "192.168.128.1";
            // 
            // btn_Connect
            // 
            btn_Connect.Location = new Point(667, 266);
            btn_Connect.Name = "btn_Connect";
            btn_Connect.Size = new Size(172, 76);
            btn_Connect.TabIndex = 21;
            btn_Connect.Text = "建立连接";
            btn_Connect.UseVisualStyleBackColor = true;
            btn_Connect.Click += btn_Connect_Click;
            // 
            // btn_send
            // 
            btn_send.Location = new Point(667, 389);
            btn_send.Name = "btn_send";
            btn_send.Size = new Size(172, 76);
            btn_send.TabIndex = 22;
            btn_send.Text = "发送消息";
            btn_send.UseVisualStyleBackColor = true;
            btn_send.Click += btn_send_Click;
            // 
            // btn_sendFile
            // 
            btn_sendFile.Location = new Point(667, 512);
            btn_sendFile.Name = "btn_sendFile";
            btn_sendFile.Size = new Size(172, 76);
            btn_sendFile.TabIndex = 23;
            btn_sendFile.Text = "发送文件";
            btn_sendFile.UseVisualStyleBackColor = true;
            btn_sendFile.Click += btn_sendFile_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(615, 215);
            label3.Name = "label3";
            label3.Size = new Size(110, 31);
            label3.TabIndex = 25;
            label3.Text = "本机名称";
            // 
            // txt_name
            // 
            txt_name.Location = new Point(731, 212);
            txt_name.Name = "txt_name";
            txt_name.Size = new Size(200, 38);
            txt_name.TabIndex = 24;
            txt_name.Text = "长江7号";
            // 
            // FormTcpClient
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(976, 753);
            Controls.Add(label3);
            Controls.Add(txt_name);
            Controls.Add(btn_sendFile);
            Controls.Add(btn_send);
            Controls.Add(btn_Connect);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txt_Port);
            Controls.Add(txt_IP);
            Controls.Add(btn_selectFile);
            Controls.Add(txt_selectFile);
            Controls.Add(txt_send);
            Controls.Add(txt_msg);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            ImeMode = ImeMode.Off;
            Name = "FormTcpClient";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormTcpClient";
            FormClosing += FormTcpClient_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_selectFile;
        private TextBox txt_selectFile;
        private TextBox txt_send;
        private TextBox txt_msg;
        private Label label2;
        private Label label1;
        private TextBox txt_Port;
        private TextBox txt_IP;
        private Button btn_Connect;
        private Button btn_send;
        private Button btn_sendFile;
        private Label label3;
        private TextBox txt_name;
    }
}