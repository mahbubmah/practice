using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace OH.Utilities
{
   public class EmailNotification
    {

       public static bool sendEmail(String fromAddr, String senderName, String toAddr, String ccAddr, String subject, String body, String _userName, String _password)
       {

           SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

           client.EnableSsl = true;

           client.Credentials = new NetworkCredential(_userName, _password);

           MailAddress from = new MailAddress(fromAddr, senderName);

           MailAddress to = new MailAddress(toAddr);

           MailMessage message = new MailMessage(from, to);

           if (ccAddr.Trim() != "")
           {

               string[] strArray = ccAddr.Trim().Split(new char[] { ';' });

               for (int i = 0; i < strArray.Length; i++)
               {

                   message.CC.Add(strArray[i].Trim());

               }

           }

           message.Subject = subject;

           message.IsBodyHtml = true;

           message.Body = body;

           try
           {

               client.Send(message);

               return true;

           }

           catch (Exception ex)
           {

               return false;

           }

       }
    }
}
