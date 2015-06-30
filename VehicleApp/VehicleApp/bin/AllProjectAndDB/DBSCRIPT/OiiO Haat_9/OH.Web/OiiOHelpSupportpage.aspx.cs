using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OH.DAL;
using OH.BLL.Basic;
using OH.Utilities;
using System.IO;

namespace OH.Web
{
    public partial class OiiOHelpSupportpage : System.Web.UI.Page
    {
        private readonly alertRT _alertRT;
        private readonly HelpSupportRT _helpsupportRT;
        public OiiOHelpSupportpage()
        {
            this._alertRT = new alertRT();
            this._helpsupportRT = new HelpSupportRT();
           
        }
        private const string sesshelpSupport = "sehelpSupport";
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadAlertContent();
            lvForHelpsupport.DataBind();
        }

        protected void rptrForAlert_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {


                    Literal objltrDescription = (Literal)e.Item.FindControl("ltrlAlertDescription");
                    //if (objltrDescription.Text.Length > 40)
                    //{
                    //    var text = objltrDescription.Text.Substring(0, 40);
                    //    objltrDescription.Text = text;
                    //    //  objltrDescription.Text = text.Substring(0, text.LastIndexOf(" "));
                    //}

                    //Literal objltrSrtDescription = (Literal)e.Item.FindControl("ltrShortDescription");
                    //if (objltrSrtDescription.Text.Length > 45)
                    //{
                    //    var text = objltrSrtDescription.Text.Substring(0, 45);
                    //    objltrSrtDescription.Text = text;
                    //    // objltrSrtDescription.Text = text.Substring(0, text.LastIndexOf(" "));
                    //}
                    Label objTitle = (Label)e.Item.FindControl("lblAlertTitle");

                }
            }
            catch (Exception ex)
            {
                LogFileWritten(ex.Message, ex.StackTrace);
            }
        }
        private void LoadAlertContent()
        {
            try
            {
                var objOtherContent = _alertRT.GetAlert();
                if (objOtherContent!=null)
                {
                    rptrForAlert.DataSource = objOtherContent;
                    rptrForAlert.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogFileWritten(ex.Message, ex.StackTrace);
            }
        }
        private void LogFileWritten(string mssge, string stackTrace)
        {
            try
            {
                string path = Server.MapPath("~/Resources/HelpSupportPagelogFileWriting.txt");
                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();
                    using (TextWriter tw = new StreamWriter(path))
                    {
                        var text = DateTime.Now.ToString() + "   " + mssge + "   " + stackTrace;
                        tw.WriteLine(text);

                        tw.Flush();
                        tw.Close();
                    }
                }
                else if (File.Exists(path))
                {
                    using (var tw = File.AppendText(path))
                    {
                        var text = DateTime.Now.ToString() + "    " + mssge + "   " + stackTrace;
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

        protected void lnkBtnhelpHome_Click(object sender, EventArgs e)
        {
            liHelpHome.Attributes.Add("class", "active");
            libasics.Attributes.Remove("class");
            lifaq.Attributes.Remove("class");
            liWht.Attributes.Remove("class");
            Session[sesshelpSupport] = Utilities.EnumCollection.HelpSupportType.HomeTab;
            lvForHelpsupport.DataBind();
        }

        protected void objDataSourceForhelpSupport_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            try
            {

               //int helpSupportTypeID = Convert.ToInt32(Session[sesshelpSupport]);

                if (Session[sesshelpSupport]==null)
                {
                    e.InputParameters["supportID"] = Utilities.EnumCollection.HelpSupportType.HomeTab;
                }
                else
                e.InputParameters["supportID"] = Session[sesshelpSupport];

               //if (helpSupportTypeID != null)
               // {
               //     switch ((int)helpSupportTypeID)
               //     {
               //         case 1:
               //             e.InputParameters["HelpSupportTypeID"] = 1;
               //             break;
               //         case 2:
               //             e.InputParameters["HelpSupportTypeID"] = 2;
               //             break;
               //         case 3:
               //             e.InputParameters["HelpSupportTypeID"] = 3;
               //             break;
               //         case 4:
               //            e.InputParameters["HelpSupportTypeID"] = 4;
               //             break;
               //     }
               // }
            }
            catch (Exception ex)
            {
                LogFileWritten(ex.Message, ex.StackTrace);
            }
        }

        protected void lnkBtnBasics_Click(object sender, EventArgs e)
        {
            liHelpHome.Attributes.Remove("class");
            libasics.Attributes.Add("class", "active");
            lifaq.Attributes.Remove("class");
            liWht.Attributes.Remove("class");
            Session[sesshelpSupport] = Utilities.EnumCollection.HelpSupportType.basics;
            lvForHelpsupport.DataBind();
        }

        protected void lnkBtnFAQs_Click(object sender, EventArgs e)
        {
            liHelpHome.Attributes.Remove("class");
            libasics.Attributes.Remove("class");
            lifaq.Attributes.Add("class", "active");
            liWht.Attributes.Remove("class");
            Session[sesshelpSupport] = Utilities.EnumCollection.HelpSupportType.FAQs;
            lvForHelpsupport.DataBind();
        }

        protected void lnkBtnhtsrong_Click(object sender, EventArgs e)
        {
            liHelpHome.Attributes.Remove("class");
            libasics.Attributes.Remove("class");
            lifaq.Attributes.Remove("class");
            liWht.Attributes.Add("class", "active");
            Session[sesshelpSupport] = Utilities.EnumCollection.HelpSupportType.Something_not_working;
            lvForHelpsupport.DataBind();
        }




    }
}