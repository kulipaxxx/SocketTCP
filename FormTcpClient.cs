using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketTCP
{
    public partial class FormTcpClient : Form
    {
        public FormTcpClient()
        {
            InitializeComponent();
        }

        //创建Socket对象
        Socket socketClient = null;

        Thread thrClient = null;

        //标志位，标准是否还在连接
        private bool isRunning = true;
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            //解析Ip地址
            IPAddress address = IPAddress.Parse(this.txt_IP.Text.Trim());

            //创建端口号
            IPEndPoint ipe = new IPEndPoint(address, int.Parse(this.txt_Port.Text.Trim()));

            //创建基于ipv4的字节流tcp
            socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                this.txt_msg.AppendText("连接服务器中......" + Environment.NewLine);
                //连接服务器
                socketClient.Connect(ipe);
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接失败" + ex.Message, "建立连接" + Environment.NewLine);
                return;
            }
            this.txt_msg.AppendText("与服务器连接成功" + Environment.NewLine);
            //关闭建立连接按钮，避免多次连接
            this.btn_Connect.Enabled = false;
            thrClient = new Thread(ReceiveMsg);
            thrClient.IsBackground = true;
            thrClient.Start();
        }

        private void ReceiveMsg(object? obj)
        {
            while (isRunning)
            {
                //定义一个2M缓冲区
                byte[] arrMsg = new byte[1024 * 1024 * 2];

                int length = -1;

                try
                {
                    length = socketClient.Receive(arrMsg);
                }
                catch (SocketException ex)
                {
                    break;
                }
                catch (Exception ex)
                {
                    Invoke(() => this.txt_msg.AppendText("断开连接:" + ex.Message + Environment.NewLine));
                    break;
                }


                //说明未连接 了
                if (length > 0)
                {
                    string strMsg = Encoding.UTF8.GetString(arrMsg, 0, length);
                    string Msg = "[接收] " + strMsg + Environment.NewLine;
                    Invoke(() => this.txt_msg.AppendText(Msg));

                }


            }
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            if (this.btn_Connect.Enabled == true)
            {
                MessageBox.Show("请先建立连接", "建立连接");
                return;
            }
            string txt = this.txt_name.Text.Trim();
            //if (string.IsNullOrEmpty(txt))
            //{
            //    MessageBox.Show("请输入内容", "发送信息");
            //    return;
            //}

            string msg = "来自" + this.txt_name.Text.Trim() + ": " + this.txt_send.Text.Trim();

            byte[] arrMsg = Encoding.UTF8.GetBytes(msg);

            socketClient.Send(arrMsg);

            Invoke(() => this.txt_msg.AppendText("[发送] " + this.txt_send.Text.Trim() + Environment.NewLine));
        }

        private void FormTcpClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            isRunning = false;
            //关闭socket,不为null处理，为null不处理
            socketClient?.Close();
        }

        private void btn_selectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "D:\\";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.txt_selectFile.Text = ofd.FileName;
            }
        }
    }
}
