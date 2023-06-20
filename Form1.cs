using System.Net;
using System.Net.Sockets;

namespace SocketTCP
{
    //����ί��
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

                string client =  socketClient.RemoteEndPoint.ToString();//��ȡ���ӵ�ַ�Ͷ˿ں�
                
                //invoke ���ν���ί���¼�ִ��
                Invoke(myAddOnline, client);

                //�첽ִ��
                //BeginInvoke(myAddOnline, client);
            }
        }

        private void AddOnline(string str)
        {
            this.lbOnline.Items.Add(str);
        }
    }
}