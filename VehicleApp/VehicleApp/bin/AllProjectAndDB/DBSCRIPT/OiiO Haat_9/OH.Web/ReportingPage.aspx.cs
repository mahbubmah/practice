using OH.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OH.Web
{
    public partial class ReportingPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            EmailNotification emailNotification = new EmailNotification();
            try
            {
                string subject = txtCauses.Text;
                string fromAddress = txtEmail.Text.Trim();
                string userName = "shi.bhowmick@gmail.com";
                string pass = "123";
                string body = "From: " + fromAddress + "\n";
                body += "Subject: " + subject + "\n";
                body += "Comments: \n" + txtComments.Text + "\n";
                if (EmailNotification.sendEmail(fromAddress, "UserName", "test@gmil.com", "", subject, body, userName, pass))
                    lblMessage.Text = "Success Sending Mail";
                else
                    lblMessage.Text = "Failed to send Mail !";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
            }

            catch (Exception ex)
            { throw ex; }
        }
    }
}