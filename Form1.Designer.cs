namespace SocketTCP
{
    partial class Form1
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
            textBox3 = new TextBox();
            textBox5 = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btn_startServer = new Button();
            textBox6 = new TextBox();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            lbOnline = new ListBox();
            SuspendLayout();
            // 
            // txt_IP
            // 
            txt_IP.Location = new Point(727, 51);
            txt_IP.Name = "txt_IP";
            txt_IP.Size = new Size(200, 38);
            txt_IP.TabIndex = 0;
            // 
            // txt_Port
            // 
            txt_Port.Location = new Point(727, 121);
            txt_Port.Name = "txt_Port";
            txt_Port.Size = new Size(200, 38);
            txt_Port.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(34, 40);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(521, 261);
            textBox3.TabIndex = 2;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(34, 349);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(521, 261);
            textBox5.TabIndex = 4;
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
            btn_startServer.Location = new Point(699, 449);
            btn_startServer.Name = "btn_startServer";
            btn_startServer.Size = new Size(150, 46);
            btn_startServer.TabIndex = 10;
            btn_startServer.Text = "启动服务";
            btn_startServer.UseVisualStyleBackColor = true;
            btn_startServer.Click += btn_startServer_Click;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(34, 634);
            textBox6.Multiline = true;
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(380, 48);
            textBox6.TabIndex = 11;
            // 
            // button2
            // 
            button2.Location = new Point(420, 636);
            button2.Name = "button2";
            button2.Size = new Size(150, 46);
            button2.TabIndex = 12;
            button2.Text = "选择文件";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.AutoEllipsis = true;
            button3.Location = new Point(699, 551);
            button3.Name = "button3";
            button3.Size = new Size(150, 46);
            button3.TabIndex = 13;
            button3.Text = "启动服务";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.AutoEllipsis = true;
            button4.Location = new Point(699, 652);
            button4.Name = "button4";
            button4.Size = new Size(150, 46);
            button4.TabIndex = 14;
            button4.Text = "启动服务";
            button4.UseVisualStyleBackColor = true;
            // 
            // lbOnline
            // 
            lbOnline.FormattingEnabled = true;
            lbOnline.ItemHeight = 31;
            lbOnline.Location = new Point(639, 222);
            lbOnline.Name = "lbOnline";
            lbOnline.Size = new Size(288, 159);
            lbOnline.TabIndex = 15;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(976, 753);
            Controls.Add(lbOnline);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(textBox6);
            Controls.Add(btn_startServer);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox5);
            Controls.Add(textBox3);
            Controls.Add(txt_Port);
            Controls.Add(txt_IP);
            Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_IP;
        private TextBox txt_Port;
        private TextBox textBox3;
        private TextBox textBox5;
        private ContextMenuStrip contextMenuStrip1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btn_startServer;
        private TextBox textBox6;
        private Button button2;
        private Button button3;
        private Button button4;
        private ListBox lbOnline;
    }
}