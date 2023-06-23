namespace SocketTCP
{
    partial class FormTcpServer
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
            components = new System.ComponentModel.Container();
            txt_IP = new TextBox();
            txt_Port = new TextBox();
            txt_msg = new TextBox();
            txt_send = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btn_startServer = new Button();
            txt_selectFile = new TextBox();
            btn_selectFile = new Button();
            btn_sendToSingle = new Button();
            btn_sendToAll = new Button();
            lbOnline = new ListBox();
            btn_sendFile = new Button();
            btn_openClient = new Button();
            SuspendLayout();
            // 
            // txt_IP
            // 
            txt_IP.Location = new Point(727, 51);
            txt_IP.Name = "txt_IP";
            txt_IP.Size = new Size(200, 38);
            txt_IP.TabIndex = 0;
            txt_IP.Text = "192.168.128.1";
            // 
            // txt_Port
            // 
            txt_Port.Location = new Point(727, 121);
            txt_Port.Name = "txt_Port";
            txt_Port.Size = new Size(200, 38);
            txt_Port.TabIndex = 1;
            txt_Port.Text = "1234";
            // 
            // txt_msg
            // 
            txt_msg.Location = new Point(34, 40);
            txt_msg.Multiline = true;
            txt_msg.Name = "txt_msg";
            txt_msg.ScrollBars = ScrollBars.Vertical;
            txt_msg.Size = new Size(521, 261);
            txt_msg.TabIndex = 2;
            // 
            // txt_send
            // 
            txt_send.Location = new Point(34, 349);
            txt_send.Multiline = true;
            txt_send.Name = "txt_send";
            txt_send.ScrollBars = ScrollBars.Vertical;
            txt_send.Size = new Size(521, 261);
            txt_send.TabIndex = 4;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(32, 32);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(589, 51);
            label1.Name = "label1";
            label1.Size = new Size(132, 31);
            label1.TabIndex = 7;
            label1.Text = "本机IP地址";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(639, 124);
            label2.Name = "label2";
            label2.Size = new Size(86, 31);
            label2.TabIndex = 8;
            label2.Text = "端口号";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(635, 188);
            label3.Name = "label3";
            label3.Size = new Size(134, 31);
            label3.TabIndex = 9;
            label3.Text = "在线列表：";
            // 
            // btn_startServer
            // 
            btn_startServer.AutoEllipsis = true;
            btn_startServer.Location = new Point(699, 381);
            btn_startServer.Name = "btn_startServer";
            btn_startServer.Size = new Size(150, 46);
            btn_startServer.TabIndex = 10;
            btn_startServer.Text = "启动服务";
            btn_startServer.UseVisualStyleBackColor = true;
            btn_startServer.Click += btn_startServer_Click;
            // 
            // txt_selectFile
            // 
            txt_selectFile.Location = new Point(34, 634);
            txt_selectFile.Multiline = true;
            txt_selectFile.Name = "txt_selectFile";
            txt_selectFile.Size = new Size(380, 48);
            txt_selectFile.TabIndex = 11;
            // 
            // btn_selectFile
            // 
            btn_selectFile.Location = new Point(420, 636);
            btn_selectFile.Name = "btn_selectFile";
            btn_selectFile.Size = new Size(150, 46);
            btn_selectFile.TabIndex = 12;
            btn_selectFile.Text = "选择文件";
            btn_selectFile.UseVisualStyleBackColor = true;
            btn_selectFile.Click += btn_selectFile_Click;
            // 
            // btn_sendToSingle
            // 
            btn_sendToSingle.AutoEllipsis = true;
            btn_sendToSingle.Location = new Point(699, 452);
            btn_sendToSingle.Name = "btn_sendToSingle";
            btn_sendToSingle.Size = new Size(150, 46);
            btn_sendToSingle.TabIndex = 13;
            btn_sendToSingle.Text = "发送消息";
            btn_sendToSingle.UseVisualStyleBackColor = true;
            btn_sendToSingle.Click += btn_sendToSingle_Click;
            // 
            // btn_sendToAll
            // 
            btn_sendToAll.AutoEllipsis = true;
            btn_sendToAll.Location = new Point(699, 523);
            btn_sendToAll.Name = "btn_sendToAll";
            btn_sendToAll.Size = new Size(150, 46);
            btn_sendToAll.TabIndex = 14;
            btn_sendToAll.Text = "群发消息";
            btn_sendToAll.UseVisualStyleBackColor = true;
            btn_sendToAll.Click += btn_sendToAll_Click;
            // 
            // lbOnline
            // 
            lbOnline.FormattingEnabled = true;
            lbOnline.ItemHeight = 31;
            lbOnline.Location = new Point(639, 222);
            lbOnline.Name = "lbOnline";
            lbOnline.SelectionMode = SelectionMode.MultiSimple;
            lbOnline.Size = new Size(288, 128);
            lbOnline.TabIndex = 15;
            // 
            // btn_sendFile
            // 
            btn_sendFile.AutoEllipsis = true;
            btn_sendFile.Location = new Point(699, 665);
            btn_sendFile.Name = "btn_sendFile";
            btn_sendFile.Size = new Size(150, 46);
            btn_sendFile.TabIndex = 16;
            btn_sendFile.Text = "发送文件";
            btn_sendFile.UseVisualStyleBackColor = true;
            btn_sendFile.Click += btn_sendFile_Click;
            // 
            // btn_openClient
            // 
            btn_openClient.AutoEllipsis = true;
            btn_openClient.Location = new Point(699, 594);
            btn_openClient.Name = "btn_openClient";
            btn_openClient.Size = new Size(150, 46);
            btn_openClient.TabIndex = 17;
            btn_openClient.Text = "客户端";
            btn_openClient.UseVisualStyleBackColor = true;
            btn_openClient.Click += btn_openClient_Click;
            // 
            // FormTcpServer
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(976, 753);
            Controls.Add(btn_openClient);
            Controls.Add(btn_sendFile);
            Controls.Add(lbOnline);
            Controls.Add(btn_sendToAll);
            Controls.Add(btn_sendToSingle);
            Controls.Add(btn_selectFile);
            Controls.Add(txt_selectFile);
            Controls.Add(btn_startServer);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txt_send);
            Controls.Add(txt_msg);
            Controls.Add(txt_Port);
            Controls.Add(txt_IP);
            Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "FormTcpServer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormTcpServer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_IP;
        private TextBox txt_Port;
        private TextBox txt_msg;
        private TextBox txt_send;
        private ContextMenuStrip contextMenuStrip1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btn_startServer;
        private TextBox txt_selectFile;
        private Button btn_selectFile;
        private Button btn_sendToSingle;
        private Button btn_sendToAll;
        private ListBox lbOnline;
        private Button btn_sendFile;
        private Button btn_openClient;
    }
}