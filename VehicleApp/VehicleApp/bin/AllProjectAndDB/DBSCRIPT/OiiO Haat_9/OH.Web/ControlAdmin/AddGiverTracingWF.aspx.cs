using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Net;
using System.Net.NetworkInformation;
using System.IO;
using System.Text;
using OH.BLL.Basic;
using OH.DAL;
using OH.Utilities;



namespace OH.Web.ControlAdmin
{
    /// <summary>
    /// Author : Asiful Islam
    /// Date:25.02.2015
    /// </summary>
    public partial class AddGiverTracingWF : System.Web.UI.Page
    {
        private const string sessAddGiverTracing = "seAddGiverTracing";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    GetCustomerIP();
                    //GetVisitorIPAddress();
                    GetMACAddress();
                    GetVisitorWebBrowser();
                    txtBrowsingTime.Text = DateTime.Now.ToShortTimeString();
                }
                catch (Exception ex)
                {
                    labelMessageAddGiverTracing.Text = "Error : " + ex.Message;
                    labelMessageAddGiverTracing.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void GetVisitorWebBrowser()
        {
            System.Web.HttpBrowserCapabilities browser = Request.Browser;
            string s = "" + browser.Browser + "\n";
            #region need later
            /*
            "Browser Capabilities\n"
            + "Type = " + browser.Type + "\n"
            + "Version = " + browser.Version + "\n"
            + "Major Version = " + browser.MajorVersion + "\n"
            + "Minor Version = " + browser.MinorVersion + "\n"
            + "Platform = " + browser.Platform + "\n"
            + "Is Beta = " + browser.Beta + "\n"
            + "Is Crawler = " + browser.Crawler + "\n"
            + "Is AOL = " + browser.AOL + "\n"
            + "Is Win16 = " + browser.Win16 + "\n"
            + "Is Win32 = " + browser.Win32 + "\n"
            + "Supports Frames = " + browser.Frames + "\n"
            + "Supports Tables = " + browser.Tables + "\n"
            + "Supports Cookies = " + browser.Cookies + "\n"
            + "Supports VBScript = " + browser.VBScript + "\n"
            + "Supports JavaScript = " +
                browser.EcmaScriptVersion.ToString() + "\n"
            + "Supports Java Applets = " + browser.JavaApplets + "\n"
            + "Supports ActiveX Controls = " + browser.ActiveXControls
                  + "\n"
            + "Supports JavaScript Version = " +
                browser["JavaScriptVersion"] + "\n";
             
            */
            #endregion 
            try
            {
                DropDownListHelper.Bind(DropDownBrowser, EnumHelper.EnumToList<EnumCollection.Browsers>());
                if (s.Contains("Chrome"))
                {
                    var browsersID =Convert.ToInt32(EnumCollection.Browsers.Chrome);
                    txtBrowserID.Text = browsersID.ToString();

                    var browserName = EnumCollection.Browsers.Chrome.ToString();
                    txtBrowserNameID.Text = browserName;
                }
                else if (s.Contains("Firefox"))
                {
                    var browsersID = Convert.ToInt32(EnumCollection.Browsers.Firefox);
                    txtBrowserID.Text = browsersID.ToString();

                    var browserName = EnumCollection.Browsers.Firefox.ToString();
                    txtBrowserNameID.Text = browserName;
                }
                else if (s.Contains("InternetExplorer"))
                {
                    var browsersID = Convert.ToInt32(EnumCollection.Browsers.InternetExplorer);
                    txtBrowserID.Text = browsersID.ToString();

                    var browserName = EnumCollection.Browsers.InternetExplorer.ToString();
                    txtBrowserNameID.Text = browserName;
                }
                else if (s.Contains("Safari"))
                {
                    var browsersID = Convert.ToInt32(EnumCollection.Browsers.Safari);
                    txtBrowserID.Text = browsersID.ToString();

                    var browserName = EnumCollection.Browsers.Safari.ToString();
                    txtBrowserNameID.Text = browserName;
                }
                else if (s.Contains("Opera"))
                {
                    var browsersID = Convert.ToInt32(EnumCollection.Browsers.Opera);
                    txtBrowserID.Text = browsersID.ToString();

                    var browserName = EnumCollection.Browsers.Opera.ToString();
                    txtBrowserNameID.Text = browserName;
                }
                else
                {
                    var browsersID = Convert.ToInt32(EnumCollection.Browsers.Other);
                    txtBrowserID.Text = s.ToString();

                    //var browserName = EnumCollection.Browsers.Other.ToString();
                    txtBrowserNameID.Text = s;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public string GetMACAddress()
        {
             
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
                  txtMACAddress.Text = sMacAddress.ToString();
                  return sMacAddress;
        }

        /// <summary>
        /// method to get Client ip address
        /// </summary>
        /// <param name="GetLan"> set to true if want to get local(LAN) Connected ip address</param>
        /// <returns></returns>
        //public string GetVisitorIPAddress(bool GetLan = false)
        //{
        //    string visitorIPAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        //    if (String.IsNullOrEmpty(visitorIPAddress))
        //        visitorIPAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

        //    if (string.IsNullOrEmpty(visitorIPAddress))
        //        visitorIPAddress = HttpContext.Current.Request.UserHostAddress;

        //    if (string.IsNullOrEmpty(visitorIPAddress) || visitorIPAddress.Trim() == "::1")
        //    {
        //        GetLan = true;
        //        visitorIPAddress = string.Empty;
        //    }

        //    if (GetLan && string.IsNullOrEmpty(visitorIPAddress))
        //    {
        //        //This is for Local(LAN) Connected ID Address
        //        string stringHostName = Dns.GetHostName();
        //        //Get Ip Host Entry
        //        IPHostEntry ipHostEntries = Dns.GetHostEntry(stringHostName);
        //        //Get Ip Address From The Ip Host Entry Address List
        //        IPAddress[] arrIpAddress = ipHostEntries.AddressList;

        //        try
        //        {
        //            visitorIPAddress = arrIpAddress[arrIpAddress.Length - 2].ToString();
        //        }
        //        catch
        //        {
        //            try
        //            {
        //                visitorIPAddress = arrIpAddress[0].ToString();
        //            }
        //            catch
        //            {
        //                try
        //                {
        //                    arrIpAddress = Dns.GetHostAddresses(stringHostName);
        //                    visitorIPAddress = arrIpAddress[0].ToString();
        //                }
        //                catch
        //                {
        //                    visitorIPAddress = "127.0.0.1";
        //                }
        //            }
        //        }
        //    }
        //    txtIPAddress.Text = visitorIPAddress.ToString();
        //    return visitorIPAddress;


        //}

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessageAddGiverTracing.Text = string.Empty;
                using (AddGiverTracingRT receiverTransfer = new AddGiverTracingRT())
                {
                    AdGiverTracing addGivrTrc = CreateAdGiverTracing();
                    receiverTransfer.InsertAdGiverTracing(addGivrTrc);
                    if (addGivrTrc.IID > 0)
                    {
                        labelMessageAddGiverTracing.Text = "Data successfully saved...";
                        labelMessageAddGiverTracing.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        labelMessageAddGiverTracing.Text = "Data not saved...";
                        labelMessageAddGiverTracing.ForeColor = System.Drawing.Color.Red;
                    }
                }

                ClearField();
                //LoadUserGrp();
            }
            catch (Exception ex)
            {
                labelMessageAddGiverTracing.Text = "Error : " + ex.Message;
                labelMessageAddGiverTracing.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ClearField()
        {
            txtAdGiverName.Text = string.Empty;
            txtAdGiverID.Text = string.Empty;
            txtBrowsingTime.Text = DateTime.Now.ToShortTimeString();
            GetCustomerIP();
            GetMACAddress();
            GetVisitorWebBrowser();
            txtMaterial.Text = string.Empty;
            txtMaterialID.Text = string.Empty;
        }

        private AdGiverTracing CreateAdGiverTracing()
        {
            Session["UserID"] = "1";
            AdGiverTracing adGiverTracing = new AdGiverTracing();
            try
            {
                
                adGiverTracing.AdGiverID =Convert.ToInt32 (txtAdGiverID.Text);
                adGiverTracing.MaterialID = Convert.ToInt32(txtMaterialID.Text);
                adGiverTracing.IPAddress = txtIPAddress.Text;
                adGiverTracing.MACAddress =txtMACAddress.Text;
                adGiverTracing.BrowserNameID = Convert.ToInt32(txtBrowserID.Text);
                adGiverTracing.BrowsingTimeDuration = txtBrowsingTime.Text;
                if (adGiverTracing.IID <= 0)
                {
                    adGiverTracing.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    adGiverTracing.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    AdGiverTracing adgivrtracng = (AdGiverTracing)Session[sessAddGiverTracing];
                    adGiverTracing.CreatedBy = adgivrtracng.CreatedBy; ;
                    adGiverTracing.CreatedDate = adgivrtracng.CreatedDate;
                }
            }
            catch (Exception ex)
            {
                labelMessageAddGiverTracing.Text = "Error : " + ex.Message;
                labelMessageAddGiverTracing.ForeColor = System.Drawing.Color.Red;
            }
            return adGiverTracing;
        }

        protected void btnShowAddGiver_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/ControlAdmin/AdGiverTracingUpdateWF.aspx");
            }
            catch (Exception ex)
            {

                labelMessageAddGiverTracing.Text = "Error : " + ex.Message;
                labelMessageAddGiverTracing.ForeColor = System.Drawing.Color.Red;
            }
        }
        //test IP Real/Fake
        public string GetCustomerIP(bool GetLan = false)
        {
            //
            //for (int indexCounter = 0; indexCounter < HttpContext.Current.Request.ServerVariables.Count; indexCounter++)
            //{
            //    CreateNwRite(HttpContext.Current.Request.ServerVariables[indexCounter]);
            //}
            //
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

                
            }
            else// not using proxy or can't get the Client IP
            {
                //visitorIPAddress = Context.Request.ServerVariables["REMOTE_ADDR"].ToString(); //While it can't get the Client IP, it will return proxy IP.
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
                CreateNwRite(visitorIPAddress,"","","");
                //ReadTxt(visitorIPAddress);
            }
            txtIPAddress.Text = visitorIPAddress.ToString();
            return visitorIPAddress;
            
        }
        public void CreateNwRite(string newTxt,string datetime,string mssge,string stackTrace)
        {
          //  CreateLogFiles();
            datetime = DateTime.Now.ToString();
            try
            {
                string path = Server.MapPath("~/Resources/logFileWriting.txt"); //@"E:\- F - Project\OiiO Haat\OH.Web\Resources\test.txt";
                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();
                    using (TextWriter tw = new StreamWriter(path))
                    {
                        tw.WriteLine(datetime + "   " + newTxt + "   " + mssge + "   " + stackTrace);
                        //tw.WriteLine(IPLogFormat + newTxt);                        
                        //tw.WriteLine(MssgLogFormat + mssge);
                        //tw.WriteLine(stackTraceLogFormat + stackTrace);
                        tw.Flush();
                        tw.Close();
                    }
                }
                else if (File.Exists(path))
                {
                    using (var tw = File.AppendText(path))
                    {
                        //tw.WriteLine(newTxt);
                        tw.WriteLine(datetime + "   " + newTxt + "   " + mssge + "   "  + stackTrace);
                        //tw.WriteLine(IPLogFormat + newTxt);
                        //tw.WriteLine(MssgLogFormat + mssge);
                        //tw.WriteLine(stackTraceLogFormat + stackTrace);
                        tw.Flush();
                        tw.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                mssge = ex.Message.ToString();
                stackTrace = ex.StackTrace.ToString();
                //labelMessageAddGiverTracing.Text = "Error : " + ex.Message;
                labelMessageAddGiverTracing.ForeColor = System.Drawing.Color.Red;
                labelMessageAddGiverTracing.Text = "Error : File is not Writable. Please Check Out 'Resources' folder under OH.Web First !" ;
            }        
        }

        //private string IPLogFormat;
        //private string DateTimeLogFormat;
        //private string MssgLogFormat;
        //private string stackTraceLogFormat;
        //    public void CreateLogFiles()
        //        {
        //            //sLogFormat used to create log files format :
        //            // dd/mm/yyyy hh:mm:ss AM/PM ==> Log Message
        //            IPLogFormat = " IP Address==> ";
        //            DateTimeLogFormat = " Date Time==> ";
        //           MssgLogFormat = " Exception Message==> ";
        //            stackTraceLogFormat = " Exception Stack Trace==> ";
            
                   
        //        }
        //public void ReadTxt(string line)
        //{
            
        //    try
        //    {
        //        string path = @"E:\- F - Project\OiiO Haat\OH.Web\Resources\test.txt";
        //        if (File.Exists(path))
        //        {
        //            using (TextReader tw = new StreamReader(path))
        //            {
        //                tw.ReadLine().ToString();
        //                labelMessgRead.Text = tw.ReadLine().ToString();
        //                tw.Close();

        //            }
        //        }
        //        //labelMessgRead.Text = line.ToString();
        //    }
        //    catch (Exception ex)
        //    {

        //        labelMessageAddGiverTracing.Text = "Error : " + ex.Message;
        //        labelMessageAddGiverTracing.ForeColor = System.Drawing.Color.Red;
        //    }
        //    finally
        //    {
        //        Console.WriteLine("Executing finally block.");
        //    }
        
        
        //}
    }
}