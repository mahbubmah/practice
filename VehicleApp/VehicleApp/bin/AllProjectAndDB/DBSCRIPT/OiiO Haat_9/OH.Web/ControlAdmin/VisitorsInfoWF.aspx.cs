using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OH.BLL.Basic;
using OH.DAL;
using OH.Utilities;
using System.Net.NetworkInformation;
using System.Net;

namespace OH.Web.ControlAdmin
{
    public partial class VisitorsInfoWF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    GetCustomerIP();
                    labelMessageDateTime.Text = DateTime.Now.ToString();
                    saveVisitorInfo();
                }
                catch (Exception ex)
                {
                    labelMessageVisitorInfo.Text = "Error : " + ex.Message;
                    labelMessageVisitorInfo.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        public string GetCustomerIP(bool GetLan = false)
        {
            string visitorIPAddress = "";
            if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null
              && HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != "")
            // using proxy 
            {
                visitorIPAddress = (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null
                                    && HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != "")
                                    ? HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]
                                    : HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                if (visitorIPAddress.Contains(","))
                    visitorIPAddress = visitorIPAddress.Split(',').First().Trim();// Return real client IP.
                labelMessageIPType.Text = "Virtual IP";
                labelMessageIP.Text = visitorIPAddress.ToString();
            }
            else// not using proxy or can't get the Client IP
            {
                visitorIPAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (String.IsNullOrEmpty(visitorIPAddress))
                    visitorIPAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                if (string.IsNullOrEmpty(visitorIPAddress))
                    visitorIPAddress = HttpContext.Current.Request.UserHostAddress;
                if (string.IsNullOrEmpty(visitorIPAddress) || visitorIPAddress.Trim() == "::1")
                {
                    GetLan = true;
                    visitorIPAddress = string.Empty;
                }
                if (GetLan && string.IsNullOrEmpty(visitorIPAddress))
                {
                    //This is for Local(LAN) Connected ID Address
                    string stringHostName = Dns.GetHostName();
                    //Get Ip Host Entry
                    IPHostEntry ipHostEntries = Dns.GetHostEntry(stringHostName);
                    //Get Ip Address From The Ip Host Entry Address List
                    IPAddress[] arrIpAddress = ipHostEntries.AddressList;
                    try
                    {
                        visitorIPAddress = arrIpAddress[arrIpAddress.Length - 2].ToString();
                    }
                    catch
                    {
                        try
                        {
                            visitorIPAddress = arrIpAddress[0].ToString();
                        }
                        catch
                        {
                            try
                            {
                                arrIpAddress = Dns.GetHostAddresses(stringHostName);
                                visitorIPAddress = arrIpAddress[0].ToString();
                            }
                            catch
                            {
                                visitorIPAddress = "127.0.0.1";
                            }
                        }
                    }
                }
                labelMessageIPType.Text = "Real IP";
                labelMessageIP.Text = visitorIPAddress.ToString();
            }
            return visitorIPAddress;
           
        }
        private void saveVisitorInfo()
        {
            try
            {

                labelMessageVisitorInfo.Text = string.Empty;
                using (VisitorRT receiverTransfer = new VisitorRT())
                {

                    List<VisitorInfo> VisitorInfoList = new List<VisitorInfo>();
                    VisitorInfoList = receiverTransfer.GetVisitorInfoIPnType(labelMessageIP.Text, labelMessageIPType.Text);

                    if (VisitorInfoList != null && VisitorInfoList.Count > 0)
                    {
                        VisitorInfo vIsitor = new VisitorInfo();
                        vIsitor = receiverTransfer.GetVisitorID(labelMessageIP.Text, labelMessageIPType.Text);
                        VisitorInfoDetail visitorDetailes = CreateVisitordetails();
                        visitorDetailes.VisitorInfoID = vIsitor.IID;
                        using (VisitorInfoDetailRT visitorDetailesRT = new VisitorInfoDetailRT())
                        {
                            visitorDetailesRT.AddVisitorInfo(visitorDetailes);
                        }
                    }

                    else
                    {
                        VisitorInfo visitor = CreateVisitor();
                        VisitorInfoDetail visitorDetailes = CreateVisitordetails();
                        receiverTransfer.AddVisitor(visitor);
                        visitorDetailes.VisitorInfoID = visitor.IID;
                        using (VisitorInfoDetailRT visitorDetailesRT = new VisitorInfoDetailRT())
                        {
                            visitorDetailesRT.AddVisitorInfo(visitorDetailes);
                        }



                        if (visitor.IID > 0 && visitorDetailes.IID > 0)
                        {
                            labelMessageVisitorInfo.Text = "Data successfully saved...";
                            labelMessageVisitorInfo.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            labelMessageVisitorInfo.Text = "Data not saved...";
                            labelMessageVisitorInfo.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }

                //LoadUserGrp();
            }


            catch (Exception ex)
            {
                labelMessageVisitorInfo.Text = "Error : " + ex.Message;
                labelMessageVisitorInfo.ForeColor = System.Drawing.Color.Red;
            }



        }

        private VisitorInfoDetail CreateVisitordetails()
        {
            VisitorInfoDetail visitorInfoDetails = new VisitorInfoDetail();
            try
            {                
                visitorInfoDetails.AccessDateTime = Convert.ToDateTime(labelMessageDateTime.Text);
            }
            catch (Exception ex)
            {
                labelMessageVisitorInfo.Text = "Error : " + ex.Message;
                labelMessageVisitorInfo.ForeColor = System.Drawing.Color.Red;
            }
            return visitorInfoDetails;
        }

        private VisitorInfo CreateVisitor()
        {
            Session["UserID"] = "1";
            VisitorInfo visitorInfo = new VisitorInfo();
            try
            {
                visitorInfo.IPAddress = labelMessageIP.Text;
                visitorInfo.IPType = labelMessageIPType.Text;
            }
            catch (Exception ex)
            {
                labelMessageVisitorInfo.Text = "Error : " + ex.Message;
                labelMessageVisitorInfo.ForeColor = System.Drawing.Color.Red;
            }
            return visitorInfo;
        }
        
    }
}