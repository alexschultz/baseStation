using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quadUI
{
    public partial class Form1 : Form
    {
        public adhoc.adhocNetwork Connection { get; set; }
        public adhoc.DataTransfer DataConn { get; set; }
        public MpuDataReading _tempDataReading;
        public Form1()
        {
            InitializeComponent();
            DataConn = new adhoc.DataTransfer();
            DataConn.UdpRecievedEvent += UpdateMessage;
        }

        private void UpdateMessage(object sender, adhoc.DataTransfer.DataEventArgs args)
        {
            string incommingMessage = Encoding.ASCII.GetString(args.Data);
            
            if (incommingMessage.StartsWith("~m"))
            {//mpu data
                _tempDataReading = new MpuDataReading(incommingMessage);
                
                if (textBoxIncomming.InvokeRequired)
                {
                    textBoxIncomming.Invoke(new MethodInvoker(delegate { _tempDataReading.ToString(); }));
                }
            
            }
            string incmnIP = args.IpAddress.ToString();
            if (textBoxIpAddress.InvokeRequired)
            {
                textBoxIpAddress.Invoke(new MethodInvoker(delegate { textBoxIpAddress.Text = incmnIP; }));
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (buttonConnect.Text == "Connect")
            {
                Connection = new adhoc.adhocNetwork(textBoxSSID.Text, "");
                Connection.Connect();
                buttonConnect.Text = "Disconnect";
            }
            else
            {
                Connection.Disconnect();
                buttonConnect.Text = "Connect";
                DataConn = null;  
            }
        }

        private void buttonSendPacket_Click(object sender, EventArgs e)
        {
            DataConn.SendBroadcast(Convert.ToInt32(textBoxPort.Text), textBoxMessage.Text, textBoxIpAddress.Text);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxIncomming.Text = "";
        }
    }
}
