using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketTCP
{
    //����ί��
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

        //������������ͻ��˵��߳�
        Thread threadListen = null;

        //����ip��socket���ֵ�
        Dictionary<string, Socket> DicSocket = new Dictionary<string, Socket>();

        private void btn_startServer_Click(object sender, EventArgs e)
        {
            //TCPͨѶ��ʽ������stream����ʽ���� IPV4
            this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress address = IPAddress.Parse(this.txt_IP.Text.Trim());//ȥ���ո�

            //����ip��ַ�Ͷ˿ںŴ���PE����
            IPEndPoint endPoint = new IPEndPoint(address, int.Parse(this.txt_Port.Text));

            try
            {
                //��
                socket.Bind(endPoint);
                Invoke(recvMsg, "�������ɹ�");
                MessageBox.Show("��������ɹ�!", "�򿪷���");
            }
            catch (Exception ex)
            {
                MessageBox.Show("��������ʧ��" + ex.Message, "�򿪷���");
            }
            //�����ʱ��
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
                //���ܵ��ͻ������ӣ����ȡsocketclient
                Socket socketClient = socket.Accept();

                string client = socketClient.RemoteEndPoint.ToString();//��ȡ���ӵ�ַ�Ͷ˿ں�

                DicSocket.Add(client, socketClient);

                //invoke ���ν���ί���¼�ִ��
                Invoke(myAddOnline, client, true);
                Invoke(RecvMsg, client + "������!");
                //�첽ִ��
                //BeginInvoke(myAddOnline, client);

                //������������
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
                //2M������
                byte[] arrMsgResc = new byte[1024 * 1024 * 2];

                string client = socket.RemoteEndPoint.ToString();

                int length = -1;
                try
                {
                    length = socket.Receive(arrMsgResc);
                }
                catch (Exception ex)
                {
                    //���ֵ����Ƴ���Socket
                    DicSocket.Remove(client);
                    Invoke(recvMsg, client + "������!");

                    //���б����Ƴ���Socket
                    Invoke(myAddOnline, client, false);
                    break;
                }

                if (length > 0)
                {
                    string msg = Encoding.UTF8.GetString(arrMsgResc, 0, length);
                    string str = "[����]  " + client + ": " + msg;
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
                MessageBox.Show("��ѡ��Ҫ���͵Ŀͻ���", "������Ϣ");
                return;
            }
            else
            {
                foreach (string client in this.lbOnline.SelectedItems)
                {
                    DicSocket[client].Send(arrMsg);

                    string str = "[���͵�]  " + client + ": " + strMsg;

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

                string str = "[����]  " + client + ": " + strMsg;

                Invoke(recvMsg, str);
            }
            Invoke(recvMsg, "[Ⱥ��] Ⱥ�����");
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
                MessageBox.Show("��ѡ����Ҫ���͵��ļ���", "�����ļ�");
                return;
            }
            var items = this.lbOnline.SelectedItems;
            if (items == null || items.Count == 0)
            {
                MessageBox.Show("��ѡ����Ҫ���͵��Ŀͻ��ˣ�", "�����ļ�");
                return;
            }
            using (FileStream fs = new FileStream(this.txt_selectFile.Text, FileMode.Open))
            {
                //����2M�ռ�
                const long fileSize = 1024 * 1024 * 2;
                if (fs.Length > fileSize)
                {
                    MessageBox.Show("�����ļ���С����2M�����ܷ���", "�����ļ�");
                }

                byte[] buffer = new byte[fileSize];

                int length = fs.Read(buffer, 0, buffer.Length);

                foreach (string item in this.lbOnline.SelectedItems)
                {
                    DicSocket[item].Send(buffer);
                }

            }
        }
    }
}