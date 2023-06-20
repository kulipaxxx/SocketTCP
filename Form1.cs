using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketTCP
{
    //声明委托
    delegate void AddOnlineDelegate(string str, bool flag);

    delegate void RecvMsgDelegate(string msg);
    public partial class Form1 : Form
    {
        public Form1()
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

                //invoke 依次进行委托事件执行
                Invoke(myAddOnline, client, true);

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

                if (length > 0)
                {
                    string msg = Encoding.UTF8.GetString(arrMsgResc, 0, length);
                    Invoke(recvMsg, msg);
                }
                else //不为0 则断开连接
                {
                    Invoke(myAddOnline, client, false);
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
    }
}