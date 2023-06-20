using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketTCP
{
    //����ί��
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

        //������������ͻ��˵��߳�
        Thread threadListen = null;

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

                //invoke ���ν���ί���¼�ִ��
                Invoke(myAddOnline, client, true);

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

                int length = socket.Receive(arrMsgResc);

                if (length > 0)
                {
                    string msg = Encoding.UTF8.GetString(arrMsgResc, 0, length);
                    Invoke(recvMsg, msg);
                }
                else //��Ϊ0 ��Ͽ�����
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