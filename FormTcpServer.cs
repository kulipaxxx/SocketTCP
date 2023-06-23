using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketTCP
{
    //声明委托
    delegate void AddOnlineDelegate(string str, bool flag);

    delegate void RecvMsgDelegate(string msg);

    delegate void SaveFIleDelegate(byte[] bt, int length);
    public partial class FormTcpServer : System.Windows.Forms.Form
    {
        public FormTcpServer()
        {
            InitializeComponent();
            myAddOnline += AddOnline;
            recvMsg += RecvMsg;
            MySaveFile += FileSave;
        }

        AddOnlineDelegate myAddOnline;
        RecvMsgDelegate recvMsg;
        Socket socket = null;

        SaveFIleDelegate MySaveFile;
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

                int length = -1;
                try
                {
                    length = socket.Receive(arrMsgResc);
                }
                catch (Exception ex)
                {
                    //从字典中移除该Socket
                    DicSocket.Remove(client);
                    Invoke(recvMsg, client + "下线了!");

                    //从列表中移除该Socket
                    Invoke(myAddOnline, client, false);
                    break;
                }

                if (length > 0)
                {
                    if (arrMsgResc[0] == 0)
                    {
                        string msg = Encoding.UTF8.GetString(arrMsgResc, 1, length - 1);
                        string str = "[接收]  " + client + ": " + msg;
                        Invoke(recvMsg, str);
                    }
                    else//接收文件类型
                    {
                        Invoke(MySaveFile, arrMsgResc, length);
                    }
                   
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
            byte[] sendMsg = new byte[arrMsg.Length + 1];
            sendMsg[0] = 0; //0标志位代表消息

            Buffer.BlockCopy(arrMsg, 0, sendMsg, 1, arrMsg.Length);
            if (this.lbOnline.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择要发送的客户端", "发送信息");
                return;
            }
            else
            {
                foreach (string client in this.lbOnline.SelectedItems)
                {
                    DicSocket[client].Send(sendMsg);

                    string str = "[发送到]  " + client + ": " + strMsg;

                    Invoke(recvMsg, str);
                }
            }

        }

        private void btn_sendToAll_Click(object sender, EventArgs e)
        {
            string strMsg = this.txt_send.Text.Trim();
            byte[] arrMsg = Encoding.UTF8.GetBytes(strMsg);
            byte[] sendMsg = new byte[arrMsg.Length + 1];
            sendMsg[0] = 0; //0标志位代表消息

            Buffer.BlockCopy(arrMsg, 0, sendMsg, 1, arrMsg.Length);
            foreach (string client in this.lbOnline.Items)
            {
                DicSocket[client].Send(sendMsg);

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

        private void btn_selectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "D:\\";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.txt_selectFile.Text = ofd.FileName;
            }

        }

        private void btn_sendFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txt_selectFile.Text))
            {
                MessageBox.Show("请选择你要发送的文件！", "发送文件");
                return;
            }
            var items = this.lbOnline.SelectedItems;
            if (items == null || items.Count == 0)
            {
                MessageBox.Show("请选择你要发送到的客户端！", "发送文件");
                return;
            }
            using (FileStream fs = new FileStream(this.txt_selectFile.Text, FileMode.Open))
            {
                //定义2M空间
                const long fileSize = 1024 * 1024 * 2;
                if (fs.Length > fileSize)
                {
                    MessageBox.Show("发送文件大小超过2M，不能发送", "发送文件");
                }

                string filename = Path.GetFileName(txt_selectFile.Text);
                string StrMsg = "发送文件为：" + filename;
                byte[] arrMsg = Encoding.UTF8.GetBytes(StrMsg);

                byte[] arrSend = new byte[arrMsg.Length + 1];
                arrSend[0] = 0;
                Buffer.BlockCopy(arrMsg, 0, arrSend, 1, arrMsg.Length);

                foreach (string item in this.lbOnline.SelectedItems)
                {
                    DicSocket[item].Send(arrSend);
                }

                byte[] buffer = new byte[fileSize];

                int length = fs.Read(buffer, 0, buffer.Length);
                byte[] sendMsg = new byte[length + 1];

                sendMsg[0] = 1;//标志位为1，代表是文件

                Buffer.BlockCopy(buffer, 0, sendMsg, 1, length);

                foreach (string item in this.lbOnline.SelectedItems)
                {
                    DicSocket[item].Send(sendMsg);
                }

            }
        }

        private void FileSave(byte[] bt, int length)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "word files(*.docx)|*.docx|txt files(*.txt)|*.txt|xls file(*.xls)|*.xls|ALL files(*.*)|*.*";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string FileSavePath = sfd.FileName;

                    using (FileStream fs = new FileStream(FileSavePath, FileMode.Create))
                    {
                        fs.Write(bt, 1, length - 1);
                        Invoke(() => this.txt_msg.AppendText("[保存] 保存文件成功" + FileSavePath + Environment.NewLine));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存文件失败");
            }

        }
    }
}