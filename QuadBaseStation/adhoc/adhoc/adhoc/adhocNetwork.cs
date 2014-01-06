using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adhoc
{
    public class adhocNetwork
    {
        public String SSID { get; set; }
        public String Pswd { get; set; }

        public adhocNetwork(String ssid, String pswd)
        {
            SSID = ssid;
            Pswd = pswd;
            string command = string.Format(System.Globalization.CultureInfo.InvariantCulture, @"netsh wlan set hostednetwork mode=allow ssid={0}", SSID);
        }

        public void Connect()
        {
            string command = @"netsh wlan start hostednetwork";
            callShell(command);
        }

        public void Disconnect()
        {
            string command = @"netsh wlan stop hostednetwork";
            callShell(command);
        }
        private void callShell(String command)
        {

            System.Diagnostics.Process _Process = null;

            try
            {

                _Process = new System.Diagnostics.Process();
                string _CMDProcess = string.Format(System.Globalization.CultureInfo.InvariantCulture, @"{0}\cmd.exe", new object[] { Environment.SystemDirectory });
                string _Arguments = string.Format(System.Globalization.CultureInfo.InvariantCulture, "/C  {0}", command);
                System.Diagnostics.ProcessStartInfo _ProcessStartInfo = new System.Diagnostics.ProcessStartInfo(_CMDProcess, _Arguments);
                _ProcessStartInfo.CreateNoWindow = true;
                _ProcessStartInfo.UseShellExecute = false;
                _ProcessStartInfo.RedirectStandardOutput = true;
                _ProcessStartInfo.RedirectStandardInput = true;
                _ProcessStartInfo.RedirectStandardError = true;
                _Process.StartInfo = _ProcessStartInfo;
                _Process.Start();
                _Process.WaitForExit();
            }

            catch (Win32Exception _Win32Exception)
            {
                Console.WriteLine("Win32 Exception caught in process: {0}", _Win32Exception.ToString());
            }
            catch (Exception _Exception)
            {
                Console.WriteLine("Exception caught in process: {0}", _Exception.ToString());
            }
            finally
            {
                _Process.Close();
                _Process.Dispose();
                _Process = null;
            }
        }



    }
}


