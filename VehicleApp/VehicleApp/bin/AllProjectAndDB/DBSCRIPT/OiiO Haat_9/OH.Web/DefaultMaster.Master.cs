using OH.BLL.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using OH.DAL;
using OH.Utilities;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using System.Reflection;


namespace OH.Web
{
    public partial class DefaultMaster : System.Web.UI.MasterPage
    {
        //int totalDigits = 6;
        private const string sessEmailSubscribe = "seEmailSubscribe";
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";

        private readonly CategoryRT _categoryRT;
        private readonly UserInformationRT _userInformationRT;
        private readonly VisitorCounterRT _visitorCounterRT;
        private readonly VisitorCounter _visitorCounter;

        public DefaultMaster()
        {
            this._categoryRT = new CategoryRT();
            this._userInformationRT = new UserInformationRT();
            this._visitorCounterRT = new VisitorCounterRT();
            this._visitorCounter = new VisitorCounter();
        }
        protected string SearchUrlforRead
        {
            get { return (string)ViewState["SearchUrlforRead"] ?? String.Empty; }
            private set { ViewState["SearchUrlforRead"] = value; }
        }

        protected string SearchKeyWord
        {
            get { return (string)ViewState["SearchKeyWord"] ?? String.Empty; }
            private set { ViewState["SearchKeyWord"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadVisitorCounter();
                    LoadDefaultPageUrl();
                    LoadDefaultLoginLogout();
                    //LoadAllCategory();
                    DisableBrowserBackButton();
                    GetCustomerIP();
                    lblDateTime.Text = DateTime.Now.ToString();
                    saveVisitorInfo();
                    ShowVisitorCounter();
                    LoadCMSFirstFooterManu();
                    LoadCMSSecondFooterManu();
                    LoadLogoHaatFtrInfo();
                    //ltlCounter.Text = FormatHTMLCounter(Session["hits"].ToString());
                }
              
            }
            catch (Exception ex)
            {

            }

        }

        public void DisableBrowserBackButton()
        {
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoServerCaching();
            HttpContext.Current.Response.Cache.SetNoStore();
        }

        //private void LoadAllCategory()
        //{
        //    var allCategoryList = _categoryRT.GetAllSearchedCategory(string.Empty).ToList();
        //    ddlAllCategory.DataSource = allCategoryList;
        //    ddlAllCategory.DataTextField = "Name";
        //    ddlAllCategory.DataValueField = "IID";
        //    ddlAllCategory.DataBind();
        //}

        private void LoadDefaultLoginLogout()
        {
            try
            {
                ulLoginOut.Visible = true;
                if (Session["UserName"] != null)
                {
                    ulLoginOutDirect.Visible = false;
                    var userText = Session["UserName"] != null ? Session["UserName"].ToString() : string.Empty;
                    lblUsername.Text = "Welcome " + userText + " !";
                    lbLogStatus.Text = Session["LoginStatus"] != null ? Session["LoginStatus"].ToString() : string.Empty;

                    //var _findUser = _userInformationRT.FindUserByUserName(Convert.ToString(Session["UserName"]));
                    //var objUserGroup = _userInformationRT.FindUserGroup(_findUser != null ? _findUser.UserGroupID : default(Int64));

                    //if (objUserGroup != null)
                    //{
                    //    if (Convert.ToInt32(objUserGroup.TypeID) != Convert.ToInt32(OH.Utilities.EnumCollection.UserGrpType.Add_Giver))
                    //    {
                    //        Response.Redirect("~/ControlAdmin/AdminDefault.aspx");
                    //    }
                    //    else
                    //    {
                    //        Response.Redirect("~/Default.aspx");
                    //    }
                    //}
                }
                else
                {
                    ulLoginOutDirect.Visible = true;
                    lblUsername.Text = string.Empty;
                    lbLogStatus.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void LoadDefaultPageUrl()
        {
            #region Default url loading

            hrfRegister.HRef = "~/UserRegistrationPage";
            hrfLogin.HRef = "~/LoginPage";

            #endregion
        }
        protected void lbLogStatus_OnClick(object sender, EventArgs e)
        {
            Session["LoginStatus"] = "Login";
            lblUsername.Text = string.Empty;
            ulLoginOut.Visible = false;
            ulLoginOutDirect.Visible = true;
            lbLogStatus.Text = string.Empty;
            Session["UserName"] = null;
            Response.Redirect("~/LoginPage.aspx");  
       }

        

        #region Author : Asiful Islam
        private void LoadLogoHaatFtrInfo()
        {
            try
            {
                using (OiiOHaatRT receiverTransfer = new OiiOHaatRT())
                {
                    OiiOHaat haatContentActive = receiverTransfer.GetActiveHaatContentForShow();
                   // lblftrAddress.Text = haatContentActive.Address;
                    lblftrPhn.Text = haatContentActive.Phone;
                    lblftrEmail.Text = haatContentActive.Email;
                    logoImg.ImageUrl = haatContentActive.Logo;
                }
            }
            catch (Exception ex)
            { 
            
            }
        
        
        }
        private void LoadCMSFirstFooterManu()
        {



            try
            {
                List<EnumModifier> enumModifierList = new List<EnumModifier>();
                var enumMemberList = EnumHelper.EnumToList<EnumCollection.CMSType>();
                foreach (var enumMember in enumMemberList)
                {
                    EnumModifier aEnumModifier = new EnumModifier();
                    string enumDisplayMember = enumMember.ToString();

                    string name = string.Empty;
                    string value = string.Empty;

                    switch (enumDisplayMember)
                    {
                        case "About OiiO Haat":
                            name = "About OiiO Haat";
                            value = "1";
                            break;
                        case "Work With Us":
                            name = "Work With Us";
                            value = "2";
                            break;
                        case "Contact With Us":
                            name = "Contact With Us";
                            value = "3";
                            break;
                        case "Press Releases":
                            name = "Press Releases";
                            value = "4";
                            break;
                        case "OiiO Haat Blog":
                            name = "OiiO Haat Blog";
                            value = "5";
                            break;
                      
                    }
                    aEnumModifier.Name = name;
                    aEnumModifier.Value = value;
                    enumModifierList.Add(aEnumModifier);

                }
             

                rptCMSMenu.DataSource = enumModifierList.Take(5); //objNavManu;
                rptCMSMenu.DataBind();


                //var objNavManu = _categoryRT.GetNavmenu().Take(6).ToList();
                //if (objNavManu.Count > 0)
                //{

                //}
            }
            catch (Exception ex)
            {
                //LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        private void LoadCMSSecondFooterManu()
        {



            try
            {
                List<EnumModifier> enumModifierList = new List<EnumModifier>();
                var enumMemberList = EnumHelper.EnumToList<EnumCollection.CMSType>();
                foreach (var enumMember in enumMemberList)
                {
                    EnumModifier aEnumModifier = new EnumModifier();
                    string enumDisplayMember = enumMember.ToString();

                    string name = string.Empty;
                    string value = string.Empty;

                    switch (enumDisplayMember)
                    {
                        case "Our Partners":
                            name = "Our Partners";
                            value = "6";
                            break;
                        case "For Business":
                            name = "For Business";
                            value = "7";
                            break;
                        case "Privacy Policy":
                            name = "Privacy Policy";
                            value = "8";
                            break;
                        case "Cookies Policy":
                            name = "Cookies Policy";
                            value = "9";
                            break;
                        case "Terms of Use":
                            name = "Terms of Use";
                            value = "10";
                            break;
                        case "Safety Tips":
                            name = "Safety Tips";
                            value = "11";
                            break;

                    }
                    aEnumModifier.Name = name;
                    aEnumModifier.Value = value;
                    enumModifierList.Add(aEnumModifier);

                }


                rptrSecondFtr.DataSource = enumModifierList; //objNavManu;
                rptrSecondFtr.DataBind();


                //var objNavManu = _categoryRT.GetNavmenu().Take(6).ToList();
                //if (objNavManu.Count > 0)
                //{

                //}
            }
            catch (Exception ex)
            {
                //LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        private void ShowVisitorCounter()
        {
            try
            {

                lblVisitorINfo.Text = string.Empty;
                using (VisitorRT receiverTransfer = new VisitorRT())
                {

                    List<VisitorInfo> AllVisitorList = new List<VisitorInfo>();
                    AllVisitorList = receiverTransfer.GetAllVisitor();


                    if (AllVisitorList != null && AllVisitorList.Count > 0)
                    {
                       // lblVisitorINfo.Text = "Total Visitor: " + AllVisitorList.Count;
                       // lblVisitorINfo.ForeColor = System.Drawing.Color.SeaGreen;

                    }
                    else
                    {
                       // lblVisitorINfo.Text = "Total Visitor: 0" ;
                    }
                }

            }
            catch (Exception ex)
            {
                lblVisitorINfo.Text = "Error : " + ex.Message;
                lblVisitorINfo.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void saveVisitorInfo()
        {
            try
            {

                lblVisitorINfo.Text = string.Empty;
                using (VisitorRT receiverTransfer = new VisitorRT())
                {

                    List<VisitorInfo> VisitorInfoList = new List<VisitorInfo>();
                    VisitorInfoList = receiverTransfer.GetVisitorInfoIPnType(lblIPAddress.Text, lblIPrealFake.Text);

                    if (VisitorInfoList != null && VisitorInfoList.Count > 0)
                    {
                        VisitorInfo vIsitor = new VisitorInfo();
                        vIsitor = receiverTransfer.GetVisitorID(lblIPAddress.Text, lblIPrealFake.Text);
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
                            lblVisitorINfo.Text = "Data successfully saved...";
                            lblVisitorINfo.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            lblVisitorINfo.Text = "Data not saved...";
                            lblVisitorINfo.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblVisitorINfo.Text = "Error : " + ex.Message;
                lblVisitorINfo.ForeColor = System.Drawing.Color.Red;
            }
        }

        private VisitorInfo CreateVisitor()
        {
            Session["UserID"] = "1";
            VisitorInfo visitorInfo = new VisitorInfo();
            try
            {
                visitorInfo.IPAddress = lblIPAddress.Text;
                visitorInfo.IPType = lblIPrealFake.Text;
            }
            catch (Exception ex)
            {
                lblVisitorINfo.Text = "Error : " + ex.Message;
                lblVisitorINfo.ForeColor = System.Drawing.Color.Red;
            }
            return visitorInfo;
        }

        private VisitorInfoDetail CreateVisitordetails()
        {
            VisitorInfoDetail visitorInfoDetails = new VisitorInfoDetail();
            try
            {
                visitorInfoDetails.AccessDateTime = Convert.ToDateTime(lblDateTime.Text);
            }
            catch (Exception ex)
            {
                lblVisitorINfo.Text = "Error : " + ex.Message;
                lblVisitorINfo.ForeColor = System.Drawing.Color.Red;
            }
            return visitorInfoDetails;
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
                lblIPrealFake.Text = "Virtual IP";
                lblIPAddress.Text = visitorIPAddress.ToString();
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
                lblIPrealFake.Text = "Real IP";
                lblIPAddress.Text = visitorIPAddress.ToString();
            }
            return visitorIPAddress;

        }

        protected void btnSubscribeUnsubcbe_Click(object sender, EventArgs e)
        {
            //if (ChkEmailUnsubcribe.Checked == false)
            //{
                try
                {
                    lblEmailSubscribe.Text = string.Empty;
                    using (EmailSubscriptionRT receiverTransfer = new EmailSubscriptionRT())
                    {

                        List<OiiONewsLetter> EmailSubscriberList = new List<OiiONewsLetter>();
                        EmailSubscriberList = receiverTransfer.GetEmailSubscriber(txtEmailSubscription.Text);

                        if (EmailSubscriberList != null && EmailSubscriberList.Count > 0)
                        {
                            string msg = "" + txtEmailSubscription.Text + " Already Subscribed!";
                            lblEmailSubscribe.Text = msg;
                            lblEmailSubscribe.ForeColor = System.Drawing.Color.White;
                            lblEmailSubscribe.BackColor = System.Drawing.Color.Blue;
                            return;
                        }

                        OiiONewsLetter EmailSubscribe = CreateEmailSubscriber();
                        receiverTransfer.AddEmailSubscriber(EmailSubscribe);
                        if (EmailSubscribe.IID > 0)
                        {
                            lblEmailSubscribe.Text = "Data successfully saved...";
                            lblEmailSubscribe.ForeColor = System.Drawing.Color.White;
                            lblEmailSubscribe.BackColor = System.Drawing.Color.Blue;
                        }
                        else
                        {
                            lblEmailSubscribe.Text = "Data not saved...";
                            lblEmailSubscribe.ForeColor = System.Drawing.Color.White;
                            lblEmailSubscribe.BackColor = System.Drawing.Color.Blue;
                        }
                    }

                    ClearEmailField();
                    //LoadUserGrp();
                }
                catch (Exception ex)
                {
                    lbLogStatus.Text = "Error : " + ex.Message;
                    lbLogStatus.ForeColor = System.Drawing.Color.Red;
                }
            //}
            //else if(ChkEmailUnsubcribe.Checked==true && txtEmailSubscription.Text!=null)
            //{

            //    try
            //    {
            //        lblEmailSubscribe.Text = string.Empty;
            //        using (EmailSubscriptionRT receiverTransfer = new EmailSubscriptionRT())
            //        {
            //            List<OiiONewsLetter> EmailSubscriberList = new List<OiiONewsLetter>();
            //            EmailSubscriberList = receiverTransfer.GetEmailSubscriber(txtEmailSubscription.Text);

            //            if (EmailSubscriberList != null && EmailSubscriberList.Count > 0)
            //            {
            //                hdIsDelete.Value = "true";
            //                hdIsEdit.Value = "true";

            //                OiiONewsLetter EmailSubscribe = CreateEmailSubscriber();

            //                if (EmailSubscribe != null)
            //                {
            //                    receiverTransfer.UpdateEmailSubscribe(EmailSubscribe);
            //                    lblEmailSubscribe.Text = "Data successfully deleted...";
            //                    lblEmailSubscribe.ForeColor = System.Drawing.Color.White;
            //                    lblEmailSubscribe.BackColor = System.Drawing.Color.Blue;
            //                }
            //                else
            //                {
            //                    lblEmailSubscribe.Text = "Data not deleted...";
            //                    lblEmailSubscribe.ForeColor = System.Drawing.Color.White;
            //                }
            //            }
            //            else
            //            {
            //                lblEmailSubscribe.Text = "You Should Subscribe First";
            //                lblEmailSubscribe.ForeColor = System.Drawing.Color.YellowGreen;
            //            }
                       
            //        }
                    
            //        ClearEmailField();
            //    }
            //    catch (Exception ex)
            //    {
            //        lblEmailSubscribe.Text = "Error : " + ex.Message;
            //        lblEmailSubscribe.ForeColor = System.Drawing.Color.White;
            //    }
            
            //}
            //else
            //{
            //    lblEmailSubscribe.Text = "Can Not Subscribe Or Unsubscribe";
            //}
        }
        private void ClearEmailField()
        {
            txtEmailSubscription.Text = string.Empty;
            //ChkEmailUnsubcribe.Checked = false;
        }
        private OiiONewsLetter CreateEmailSubscriber()
        {
            Session["EmailID"] = "1";
            OiiONewsLetter EmailSubscriber = new OiiONewsLetter();
            try
            {
                if (hdIsEdit.Value == "true")
                {
                    EmailSubscriptionRT receiverTransfer = new EmailSubscriptionRT();
                    OiiONewsLetter emailSubscription = receiverTransfer.GetEmailSubscribrIDByEmail(txtEmailSubscription.Text);
                    Session[sessEmailSubscribe] = emailSubscription;
                   // OiiONewsLetter EmailSubscribe = (OiiONewsLetter)Session[sessEmailSubscribe];
                    EmailSubscriber.IID = emailSubscription.IID;
                }
                EmailSubscriber.UserEmail = txtEmailSubscription.Text.Trim();
                EmailSubscriber.SubscribeDate = DateTime.Now;
                if (EmailSubscriber.IID <= 0)
                {
                    EmailSubscriber.CreatedBy = Convert.ToInt64(Session["EmailID"]);
                    EmailSubscriber.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    OiiONewsLetter EmailSubscribe = (OiiONewsLetter)Session[sessEmailSubscribe];
                    EmailSubscriber.CreatedBy = EmailSubscribe.CreatedBy; ;
                    EmailSubscriber.CreatedDate = EmailSubscribe.CreatedDate;
                    EmailSubscriber.ModifiedBy = Convert.ToInt64(Session["EmailID"]);
                    EmailSubscriber.ModifiedDate = GlobalRT.GetServerDateTime();
                }
                if (hdIsDelete.Value != "true")
                {
                    EmailSubscriber.IsSubscribe = true;
                }
                else
                {
                    EmailSubscriber.IsSubscribe= false;
                }
            }
            catch (Exception ex)
            {
                lblEmailSubscribe.Text = "Error : " + ex.Message;
                lblEmailSubscribe.ForeColor = System.Drawing.Color.White;
            }
            return EmailSubscriber;
        }
       

        protected void btnSearchWeb_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == string.Empty)
            {
                SearchKeyWord = null;
                Response.Redirect("~/Default");
            }
            else
            {
                SearchKeyWord = txtSearch.Text.Trim();
                Session["SearchWeb"] = SearchKeyWord;
               // AspxPageRead();
                Response.Redirect("~/SearchWeb");
            }
        }

        //public void AspxPageRead()
        //{
        //    string result = null;
        //    WebResponse response = null;
        //    StreamReader reader = null;

        //    try
        //    {


        //        string webRootPath = Server.MapPath("~"); //docPath = Path.GetFullPath(Path.Combine(path, "../~"));
        //        DirectoryInfo Dir = new DirectoryInfo(webRootPath);
        //        FileInfo[] FileList = Dir.GetFiles("*.aspx", SearchOption.TopDirectoryOnly);
        //        List<string> urlpath = new List<string>();
        //        foreach (FileInfo FI in FileList)
        //        {
        //            try
        //            {
        //                // Console.WriteLine(FI.FullName);// http://localhost:32681/Default
        //                SearchUrlforRead = "http://" + HttpContext.Current.Request.Url.Authority + "/" + FI.Name.Replace(".aspx", string.Empty);
        //                string path = SearchUrlforRead;
        //                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(path);
        //                request.Method = "GET";
        //                response = request.GetResponse();
        //                reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
        //                result = reader.ReadToEnd();
        //                string plainText = Regex.Replace(result, @"<script\b[^>]*>(.*?)<\/script>", ""); //remove javascript

        //                plainText = Regex.Replace(plainText, "<[^>]+?>", ""); //remove HTML


        //                if (plainText.Contains(txtSearch.Text))
        //                {
        //                    urlpath.Add(path);
        //                    //Request.QueryString[];
        //                }




        //            }
        //            catch (Exception ex)
        //            {


        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        // LogFileWritten(ex.Message, ex.StackTrace);
        //    }

        //    finally
        //    {
        //        if (reader != null)
        //            reader.Close();
        //        if (response != null)
        //            response.Close();
        //    }
        //}
        

        /// <summary>
        /// Original Visitor Counter
        /// </summary>
        private void LoadVisitorCounter()
        {
            try
            {
                var objVisitor = _visitorCounterRT.GetAllVisitorCounterList().SingleOrDefault();

                if (objVisitor == null && OH.Web.Global.TotalNumberOfUsers == 1)
                {
                    _visitorCounter.TotalVisitor = OH.Web.Global.TotalNumberOfUsers;
                    _visitorCounterRT.AddVisitorCounter(_visitorCounter);
                    OH.Web.Global.TotalNumberOfUsers = 0;
                }

                if (objVisitor != null && OH.Web.Global.TotalNumberOfUsers == 1)
                {
                    objVisitor.TotalVisitor += OH.Web.Global.TotalNumberOfUsers;
                    _visitorCounterRT.UpdateVisitorCounter(objVisitor);
                    OH.Web.Global.TotalNumberOfUsers = 0;
                }

                var objVisitorTotal = _visitorCounterRT.GetAllVisitorCounterList();
                lblVisitorCounter.Text = "Total Visitors : "+Convert.ToString(objVisitorTotal.SingleOrDefault().TotalVisitor);
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

    }
}