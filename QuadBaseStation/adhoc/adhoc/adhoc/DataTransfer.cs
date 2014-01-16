using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace adhoc
{
    public class DataTransfer
    {
        public delegate void EventHandler(object sender, DataEventArgs args);
        public event EventHandler UdpRecievedEvent = delegate { };

        public DataTransfer()
        {
            CreateUdpReadThread();
        }
        public void SendBroadcast(int port, string message, string ipAddress)
        {
            try
            {
                message = "~" + message;
                IPEndPoint RemoteEndPoint = new IPEndPoint(
                IPAddress.Parse(ipAddress), port);
                Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                byte[] data = Encoding.ASCII.GetBytes(message);
                server.SendTo(data, data.Length, SocketFlags.None, RemoteEndPoint);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private Thread _udpReadThread;
        private volatile bool _terminateThread;

        public event DataEventHandler OnDataReceived;
        public delegate void DataEventHandler(object sender, DataEventArgs e);

        private void CreateUdpReadThread()
        {
            _udpReadThread = new Thread(UdpReadThread) { Name = "UDP Read thread" };
            _udpReadThread.Start(new IPEndPoint(IPAddress.Any, 9750));
        }

        private void UdpReadThread(object endPoint)
        {
            var myEndPoint = (EndPoint)endPoint;
            var udpListener = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            udpListener.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            // Important to specify a timeout value, otherwise the socket ReceiveFrom() 
            // will block indefinitely if no packets are received and the thread will never terminate
            udpListener.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 100);
            udpListener.Bind(myEndPoint);
            var buffer = new byte[1024];
            try
            {
                while (!_terminateThread)
                {
                    try
                    {
                        buffer = new byte[1024];
                        var size = udpListener.ReceiveFrom(buffer, ref myEndPoint);
                        Array.Resize(ref buffer, size);
                        // Let any consumer(s) handle the data via an event
                        FireOnDataReceived(((IPEndPoint)(myEndPoint)).Address, buffer);
                    }
                    catch (SocketException socketException)
                    {
                        Console.WriteLine(socketException.Message);
                    }
                }
            }
            finally
            {
                // Close Socket
                udpListener.Shutdown(SocketShutdown.Both);
                udpListener.Close();
            }
        }

        private void FireOnDataReceived(IPAddress iPAddress, byte[] buffer)
        {
            UdpRecievedEvent(this, new DataEventArgs(iPAddress, buffer));
        }

        public class DataEventArgs : EventArgs
        {
            public byte[] Data { get; private set; }
            public IPAddress IpAddress { get; private set; }

            public DataEventArgs(IPAddress ipaddress, byte[] data)
            {
                IpAddress = ipaddress;
                Data = data;
            }
        }
    }
}

