using controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quadUI
{
    public enum ConnectionStatus
    {
        NotConnected,
        Pending,
        Connected
    }

    public partial class Main : Form
    {

        public ConnectionStatus ConnStatus { get; set; }
        public adhoc.adhocNetwork Connection { get; set; }
        public adhoc.DataTransfer DataConn { get; set; }
        public MpuDataReading _tempDataReading;
        public Controller xboxController { get; set; }
        public bool Running { get; set; }
        public bool BroadCasting { get; set; }
        public CancellationTokenSource ts { get; set; }
        public CancellationToken ct { get; set; }


        public Main()
        {
            InitializeComponent();
            setup();
        }

        #region Private Methods

        /// <summary>
        /// Sets up the components of the form
        /// </summary>
        private void setup()
        {
            xboxController = new Controller();
            DataConn = new adhoc.DataTransfer();
            DataConn.UdpRecievedEvent += UpdateMessage;
            BroadCasting = false;
            ConnStatus = ConnectionStatus.NotConnected;
            ts = new CancellationTokenSource();
            ct = ts.Token;
            _dataGridViewQuadParams.Rows.Add("Quad IP Address", "192.168.");
            _dataGridViewQuadParams.Rows.Add("Port", "9750");
            _dataGridViewQuadParams.Rows.Add("Baud Rate", "xx");
            _dataGridViewQuadParams.Rows.Add("Network SSID", "quad");
            _dataGridViewQuadParams.Rows.Add("Password", "");
        }

        private void UpdateMessage(object sender, adhoc.DataTransfer.DataEventArgs args)
        {
            string incmnIP = args.IpAddress.ToString();
            if (_dataGridViewQuadParams.InvokeRequired)
            {
                _dataGridViewQuadParams.Invoke(new MethodInvoker(delegate{_dataGridViewQuadParams.Rows[0].Cells[1].Value = incmnIP;}));
                toggleIsConnected();
            }
            string incommingMessage = Encoding.ASCII.GetString(args.Data);
            if (incommingMessage.StartsWith("~m"))
            {//mpu data
                //_tempDataReading = new MpuDataReading(incommingMessage);

            //    if (textBoxIncoming.InvokeRequired)
            //    {
            //        textBoxIncoming.Invoke(new MethodInvoker(delegate { textBoxIncoming.Text = _tempDataReading.ToString(); }));
            //    }
            //}
                if (textBoxIncoming.InvokeRequired)
                {
                    textBoxIncoming.Invoke(new MethodInvoker(delegate { textBoxIncoming.Text = incommingMessage; }));
                }
            }
        }

        private void toggleIsConnected()
        {
            IPAddress ip;
            bool validIP = IPAddress.TryParse(_dataGridViewQuadParams.Rows[0].Cells[1].Value.ToString(),out ip);
            if (BroadCasting && validIP)
            {
                ConnStatus = ConnectionStatus.Connected;
                _pictureBoxConnectiom.Image = Properties.Resources.green;
                if (_pbIgnition.InvokeRequired)
                {
                    _pbIgnition.Invoke(new MethodInvoker(delegate { _pbIgnition.Enabled = true; }));
                }
            }
            else
            {
                ConnStatus = ConnectionStatus.NotConnected;
                _pictureBoxConnectiom.Image = Properties.Resources.red;
                if (_pbIgnition.InvokeRequired)
                {
                    _pbIgnition.Invoke(new MethodInvoker(delegate { _pbIgnition.Enabled = false; }));
                }
                else
                {
                    _pbIgnition.Enabled = false;
                }
            }
        }

        /// <summary>
        /// send individual data packet to ip address listed
        /// </summary>
        /// <param name="message"></param>
        private void sendData(string message)
        {
            try
            {
                DataConn.SendBroadcast(Convert.ToInt32(_dataGridViewQuadParams.Rows[1].Cells[1].Value), message, (string)_dataGridViewQuadParams.Rows[0].Cells[1].Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Start sending controller packets to the ip address listed
        /// </summary>
        private void startSending()
        {
            while (true)
            {
                Thread.Sleep(100);
                sendData(xboxController.GetControllerState());
                if (textBoxoutgoing.InvokeRequired)
                {
                    textBoxoutgoing.Invoke(new MethodInvoker(delegate { textBoxoutgoing.Text = xboxController.GetControllerState(); }));
                }

                if (ct.IsCancellationRequested)
                {
                    Console.WriteLine("task canceled");
                    if (textBoxoutgoing.InvokeRequired)
                    {
                        textBoxoutgoing.Invoke(new MethodInvoker(delegate { textBoxoutgoing.Text = "No Data being sent"; }));
                    }
                    break;
                }
            }
        }

        private void toggleSendControllerData()
        {
            Running = !Running;
            if (Running)
            {
                ts = new CancellationTokenSource();
                ct = ts.Token;
                Task.Factory.StartNew(startSending, ct);
            }
            else
            {
                ts.Cancel();
            }
        }

        #endregion


        #region Event Handlers

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (!BroadCasting)
                {
                    Connection = new adhoc.adhocNetwork((string)_dataGridViewQuadParams.Rows[3].Cells[1].Value, (string)_dataGridViewQuadParams.Rows[4].Cells[1].Value);
                    Connection.Connect();
                    buttonConnect.Text = "Shut Down Network";
                }
                else
                {
                    if (Running)
                    {
                        toggleSendControllerData();
                        _pbIgnition.Image = Properties.Resources.start;
                    }
                    Connection.Disconnect();
                    _dataGridViewQuadParams.Rows[0].Cells[1].Value = string.Empty;
                    buttonConnect.Text = "Broadcast Network";
                    DataConn = null;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                BroadCasting = !BroadCasting;
                toggleIsConnected();
                
            }
        }

        private void buttonSendPacket_Click(object sender, EventArgs e)
        {
            sendData(textBoxMessage.Text);
        }

        private void _pbIgnition_MouseEnter(object sender, EventArgs e)
        {
            if (Running)
            {
                _pbIgnition.Image = Properties.Resources.stop_glow;
            }
            else
            {
                _pbIgnition.Image = Properties.Resources.start_glow;
            }
        }

        private void _pbIgnition_MouseLeave(object sender, EventArgs e)
        {
            if (Running)
            {
                _pbIgnition.Image = Properties.Resources.stop;
            }
            else
            {
                _pbIgnition.Image = Properties.Resources.start;
            }

        }

        private void _pbIgnition_Click(object sender, EventArgs e)
        {
            toggleSendControllerData();
        }

        

        #endregion

    }
}
