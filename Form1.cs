using System.Net;
using System.Net.Sockets;

namespace SocketTCP
{
    //声明委托
    delegate void AddOnlineDelegate(string str);
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            myAddOnline += AddOnline;
        }

        AddOnlineDelegate myAddOnline;

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

                string client =  socketClient.RemoteEndPoint.ToString();//获取连接地址和端口号
                
                //invoke 依次进行委托事件执行
                Invoke(myAddOnline, client);

                //异步执行
                //BeginInvoke(myAddOnline, client);
            }
        }

        private void AddOnline(string str)
        {
            this.lbOnline.Items.Add(str);
        }
    }
}