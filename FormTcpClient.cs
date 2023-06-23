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

            thrClient = new Thread(ReceiveMsg);
            thrClient.IsBackground = true;
            thrClient.Start();
        }

        private void ReceiveMsg(object? obj)
        {
            
        }

        private void btn_send_Click(object sender, EventArgs e)
        {

        }
    }
}
