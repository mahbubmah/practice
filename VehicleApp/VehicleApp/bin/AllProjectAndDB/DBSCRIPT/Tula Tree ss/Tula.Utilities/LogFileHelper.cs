using System;
using System.IO;
using System.Web.UI;

namespace Tula.Utilities
{
    public class LogFileHelper
    {

        public static void VisitorLogFileWritten(string path)
        {
            try
            {
                string ipAndMac = VisitorIPMACAddress.GetVisitorIPAddress() + "         " +
                                          VisitorIPMACAddress.GetVisitorMACAddress();

                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();
                    using (TextWriter tw = new StreamWriter(path))
                    {
                        var text = DateTime.Now + "        " + ipAndMac;
                        tw.WriteLine(text);

                        tw.Flush();
                        tw.Close();
                    }
                }
                else if (File.Exists(path))
                {
                    string visitorLogText = File.ReadAllText(path);
                    if (!visitorLogText.Contains(ipAndMac))
                    {
                        using (var tw = File.AppendText(path))
                        {
                            var text = DateTime.Now + "        " + ipAndMac;

                            tw.WriteLine(text);

                            tw.Flush();
                            tw.Close();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogFileWritten(ex.Message, ex.StackTrace, path);
            }
        }
        public static void LogFileWritten(string mssge, string stackTrace, string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();
                    using (TextWriter tw = new StreamWriter(path))
                    {
                        var text = DateTime.Now + "   " + VisitorIPMACAddress.GetVisitorIPAddress() + "   " + mssge + "   " + stackTrace;
                        tw.WriteLine(text);

                        tw.Flush();
                        tw.Close();
                    }
                }
                else if (File.Exists(path))
                {
                    using (var tw = File.AppendText(path))
                    {
                        var text = DateTime.Now + "   " + VisitorIPMACAddress.GetVisitorIPAddress() + "   " + mssge + "   " + stackTrace;
                        tw.WriteLine(text);
                        tw.Flush();
                        tw.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                mssge = ex.Message.ToString();
                stackTrace = ex.StackTrace.ToString();
            }
        }
    }
}
