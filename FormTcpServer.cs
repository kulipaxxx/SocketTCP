using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketTCP
{
    //声明委托
    delegate void AddOnlineDelegate(string str, bool flag);

    delegate void RecvMsgDelegate(string msg);
    public partial class FormTcpServer : System.Windows.Forms.Form
    {
        public FormTcpServer()
        {
            InitializeComponent();
            myAddOnline += AddOnline;
            recvMsg += RecvMsg;
        }

        AddOnlineDelegate myAddOnline;
        RecvMsgDelegate recvMsg;
        Socket socket = null;

        //创建负责监听客户端的线程
        Thread threadListen = null;

        //创建ip与socket的字典
        Dictionary<string, Socket> DicSocket = new Dictionary<string, Socket>();

        private void btn_startServer_Click(object sender, EventArgs e)
        {
            //TCP通讯方式，采用stream流方式进行 IPV4
            this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress address = IPAddress.Parse(this.txt_IP.Text.Trim());//去除空格

            //根据ip地址和端口号创建PE对象
            IPEndPoint endPoint = new IPEndPoint(address, int.Parse(this.txt_Port.Text));

            try
            {
                //绑定
                socket.Bind(endPoint);
                Invoke(recvMsg, "服务开启成功");
                MessageBox.Show("开启服务成功!", "打开服务");
            }
            catch (Exception ex)
            {
                MessageBox.Show("开启服务失败" + ex.Message, "打开服务");
            }
            //最长监听时间
            socket.Listen(1000);

            threadListen = new Thread(ListenConnect);
            threadListen.IsBackground = true;
            threadListen.Start();

            this.btn_startServer.Enabled = false;
        }

        private void ListenConnect(object? obj)
        {
            while (true)
            {
                //接受到客户端连接，则获取socketclient
                Socket socketClient = socket.Accept();

                string client = socketClient.RemoteEndPoint.ToString();//获取连接地址和端口号

                DicSocket.Add(client, socketClient);

                //invoke 依次进行委托事件执行
                Invoke(myAddOnline, client, true);
                Invoke(RecvMsg, client + "上线了!");
                //异步执行
                //BeginInvoke(myAddOnline, client);

                //开启接受数据
                Thread thread = new Thread(ReceiveMsg);
                thread.IsBackground = true;
                thread.Start(socketClient);
            }
        }

        private void ReceiveMsg(object? socketClient)
        {
            Socket socket = socketClient as Socket;
            while (true)
            {
                //2M缓冲区
                byte[] arrMsgResc = new byte[1024 * 1024 * 2];

                string client = socket.RemoteEndPoint.ToString();

                int length = socket.Receive(arrMsgResc);

                if (length == 0)//为0 则断开连接
                {
                    DicSocket.Remove(client);
                    Invoke(recvMsg, client + "下线了!");
                    Invoke(myAddOnline, client, false);
                    break;
                }
                else
                {
                    string msg = Encoding.UTF8.GetString(arrMsgResc, 0, length);
                    string str = "[接收]  " + client + ": " + msg;
                    Invoke(recvMsg, str);
                }
            }
        }

        private void AddOnline(string str, bool flag)
        {
            if (flag)
            {
                this.lbOnline.Items.Add(str);
            }
            else
            {
                this.lbOnline.Items.Remove(str);
            }

        }

        private void RecvMsg(string msg)
        {
            this.txt_msg.AppendText(msg + Environment.NewLine);
        }

        private void btn_sendToSingle_Click(object sender, EventArgs e)
        {
            string strMsg = this.txt_send.Text.Trim();
            byte[] arrMsg = Encoding.UTF8.GetBytes(strMsg);

            if (this.lbOnline.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择要发送的客户端", "发送信息");
                return;
            }
            else
            {
                foreach (string client in this.lbOnline.SelectedItems)
                {
                    DicSocket[client].Send(arrMsg);

                    string str = "[发送到]  " + client + ": " + strMsg;

                    Invoke(recvMsg, str);
                }
            }

        }

        private void btn_sendToAll_Click(object sender, EventArgs e)
        {
            string strMsg = this.txt_send.Text.Trim();
            byte[] arrMsg = Encoding.UTF8.GetBytes(strMsg);

            foreach (string client in this.lbOnline.Items)
            {
                DicSocket[client].Send(arrMsg);

                string str = "[发送]  " + client + ": " + strMsg;

                Invoke(recvMsg, str);
            }
            Invoke(recvMsg, "[群发] 群发完毕");
        }

        private void btn_openClient_Click(object sender, EventArgs e)
        {
            FormTcpClient tcpClient = new FormTcpClient();
            tcpClient.Show();
        }
    }
}