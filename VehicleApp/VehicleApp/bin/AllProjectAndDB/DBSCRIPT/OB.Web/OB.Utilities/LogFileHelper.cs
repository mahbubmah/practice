using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Net;
using System.Text;

namespace Utilities
{
   public class LogFileHelper:Page
   {

       public static void VisitorLogFileWritten(string path)
       {
           try
           {
              
               if (!File.Exists(path))
               {
                   File.Create(path).Dispose();
                   using (TextWriter tw = new StreamWriter(path))
                   {
                       var text = DateTime.Now + "        " + VisitorIPMACAddress.GetVisitorIPAddress() + "        " + VisitorIPMACAddress.GetVisitorMACAddress();
                       tw.WriteLine(text);

                       tw.Flush();
                       tw.Close();
                   }
               }
               else if (File.Exists(path))
               {
                   using (var tw = File.AppendText(path))
                   {
                       var text = DateTime.Now + "        " + VisitorIPMACAddress.GetVisitorIPAddress() + "         " + VisitorIPMACAddress.GetVisitorMACAddress();
                       tw.WriteLine(text);
                       tw.Flush();
                       tw.Close();
                   }
               }
           }
           catch (Exception ex)
           {
               LogFileWritten(ex.Message, ex.StackTrace,path);
           }
       }
       public static void LogFileWritten(string mssge, string stackTrace,string path)
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
