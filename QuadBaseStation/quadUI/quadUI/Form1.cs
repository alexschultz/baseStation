using controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quadUI
{
    public partial class Form1 : Form
    {
        public adhoc.adhocNetwork Connection { get; set; }
        public adhoc.DataTransfer DataConn { get; set; }
        public MpuDataReading _tempDataReading;
        public Controller xboxController { get; set; }

        public Form1()
        {
            InitializeComponent();
            xboxController = new Controller();
            DataConn = new adhoc.DataTransfer();
        }

        private void UpdateMessage(object sender, adhoc.DataTransfer.DataEventArgs args)
        {
            string incommingMessage = Encoding.ASCII.GetString(args.Data);
            
            if (incommingMessage.StartsWith("~m"))
            {//mpu data
                _tempDataReading = new MpuDataReading(incommingMessage);
                
                if (textBoxIncomming.InvokeRequired)
                {
                    textBoxIncomming.Invoke(new MethodInvoker(delegate { textBoxIncomming.Text = _tempDataReading.ToString(); }));
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
                DataConn.UdpRecievedEvent += UpdateMessage;
                Connection.Connect();
                buttonConnect.Text = "Disconnect";
            }
            else
            {
                DataConn.UdpRecievedEvent -= UpdateMessage;
                Connection.Disconnect();
                buttonConnect.Text = "Connect";
                DataConn = null;  
            }
        }

        private void buttonSendPacket_Click(object sender, EventArgs e)
        {
            sendData(textBoxMessage.Text);
        }

        private void sendData(string message)
        {
            DataConn.SendBroadcast(Convert.ToInt32(textBoxPort.Text), message, textBoxIpAddress.Text);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxIncomming.Text = "";
        }

        private void startSending()
        { 
            while (true)
            {
                sendData(xboxController.GetControllerState());
                Thread.Sleep(100);
               // Console.Write(xboxController.GetControllerState());
            }
            
        }

        private void buttonStartBroadcasting_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(startSending);
        }

        
    }
}
