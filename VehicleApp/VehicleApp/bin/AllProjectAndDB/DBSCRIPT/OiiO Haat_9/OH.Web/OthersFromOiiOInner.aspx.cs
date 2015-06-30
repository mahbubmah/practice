using OH.BLL.Basic;
using OH.DAL;
using OH.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OH.Web
{
    public partial class OthersFromOiiOInner : System.Web.UI.Page
    {
        public string Like_Button_Iframe_Count_Button = "";
      //  private readonly MaterialRT _materialRT;
        //private readonly CategoryRT _categoryRT;
        private readonly VisitorIPMACAddress _visitorIPMACAddress;
     //   private readonly CountryRT _countryRT;
       // private readonly DivisionOrStateRT _divisionOrStateRT;

       // public string QueryResult { get; set; }

       // Int64 CategoryID = default(Int64);
       // Int64 CatID = default(Int64);
        public int lvRowCount { get; set; }
        public int currentPage { get; set; }

       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    GettingCurrentUrl();

                    LoadListViewOthersFromOiiO();
                    Like_Button_Iframe_Count_Button = FacebookHelper.Get_Like_Button_Iframe_Count_Button("http://www.oiiohaat.com", "80");
                  
                  
                }
                catch(Exception ex){
                    throw new Exception(ex.Message, ex);
                }
            }
        }


        #region All Private Methods-----------------------

        private void LogFileWritten(string mssge, string stackTrace)
        {
            var datetime = DateTime.Now.ToString();
            try
            {
                string path = Server.MapPath("~/Resources/DefaultInnerPagelogFileWriting.txt");
                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();
                    using (TextWriter tw = new StreamWriter(path))
                    {
                        var text = datetime + "   " + _visitorIPMACAddress.GetVisitorIPAddress() + "   " + mssge + "   " + stackTrace;
                        tw.WriteLine(text);

                        tw.Flush();
                        tw.Close();
                    }
                }
                else if (File.Exists(path))
                {
                    using (var tw = File.AppendText(path))
                    {
                        var text = datetime + "   " + _visitorIPMACAddress.GetVisitorIPAddress() + "   " + mssge + "   " + stackTrace;
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
        //   private string GetQueryStringDataForSearch()
        //{
        //    string categoryType = default(string);
        //    try
        //    {
               
        //        if (!string.IsNullOrEmpty(Request.QueryString[0]))
        //        {
        //            bool reqIDIsValid = Int64.TryParse(Request.QueryString[0], out CatID);
        //            if (!reqIDIsValid)
        //            {
        //                categoryType = Request.QueryString[0];
        //            }
        //        }
        //        else
        //        {
        //            Response.Redirect("~/Default.aspx");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogFileWritten(ex.Message, ex.StackTrace);
        //    }
        //    return categoryType;
        //}
        //private void LoadAllCountries()
        //{
        //    try
        //    {
        //        var result = _countryRT.GetCountryAll().Where(x => x.IsRemoved == false).ToList();
        //        rp_Country_Load.DataSource = result;
        //        rp_Country_Load.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        LogFileWritten(ex.Message, ex.StackTrace);
        //    }
        //}

        private void LoadListViewOthersFromOiiO()
        {
            try
            {
                using (OtherContentRT receiverTransfer = new OtherContentRT())
                {
                    lvOthersFormOiiO.DataSource = receiverTransfer.GetotherActiveContentAllForListView(); ;
                    lvOthersFormOiiO.DataBind();
                }
            }
            catch (Exception ex)
            {
                //labelMessage.Text = "Error : " + ex.Message;
                //labelMessage.ForeColor = System.Drawing.Color.Red;
                throw new Exception(ex.Message,ex);
            }
        }
        private void GettingCurrentUrl()
        {
            string currentURL = HttpContext.Current.Request.Url.AbsoluteUri;
            Session["backURL"] = currentURL;
        }
        #endregion All Private Methods-----------------------

        #region All Protected Methods-----------------------

       

        //private void LoadingAllParentCategory()
        //{
        //    try
        //    {
        //        var objAllCategory = _categoryRT.GetAllParentCategory().ToList();

        //        rp_Load_Category_Outer.DataSource = objAllCategory;
        //        rp_Load_Category_Outer.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        LogFileWritten(ex.Message, ex.StackTrace);
        //    }
        //}

        //protected void btn_Category_Link_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        LinkButton linkButton = new LinkButton();
        //        linkButton = (LinkButton)sender;
        //        Int64 categoryID = (Convert.ToInt64(linkButton.CommandArgument));
        //        Response.Redirect("DefaultInner.aspx?val=" + categoryID.ToString());
        //        //LoadListViewForMaterial(categoryID);
        //    }
        //    catch (Exception ex)
        //    {
        //        LogFileWritten(ex.Message, ex.StackTrace);
        //    }
        //}
      

       
        protected void dataPagerOthersFormOiiO_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadListViewOthersFromOiiO();
                }
            }
            catch (Exception ex)
            {
                //labelMessage.Text = "Error : " + ex.Message;
                //labelMessage.ForeColor = System.Drawing.Color.Red;
                throw new Exception(ex.Message, ex);
            }
        }

        //protected void rp_Load_Category_Outer_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        Label objLabel = e.Item.FindControl("lbl_Total_Products") as Label;
        //        HiddenField objIID = e.Item.FindControl("hfCategoryIID") as HiddenField;

        //        var result = _materialRT.GetAllMaterialAccordingToCategoryIID(Convert.ToInt64(objIID.Value));
        //        objLabel.Text = Convert.ToString(result.Count);

        //        var objChildCategoryList = _categoryRT.GetAllCategoryByParentID(Convert.ToInt64(objIID.Value));
        //        Repeater objRepeater = e.Item.FindControl("rp_Inner_Category") as Repeater;
        //        objRepeater.DataSource = objChildCategoryList;
        //        objRepeater.DataBind();

        //    }
        //}
        //protected void rp_Country_Load_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //        {
        //            HiddenField cID = e.Item.FindControl("hfCIID") as HiddenField;

        //            var result = (from tr in _divisionOrStateRT.GetDivisionOrStateAll()
        //                          where tr.CountryID == Convert.ToInt64(cID.Value)
        //                          select tr).ToList();

        //            Repeater objRepeater = e.Item.FindControl("rp_StateDivision") as Repeater;
        //            objRepeater.DataSource = result;
        //            objRepeater.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogFileWritten(ex.Message, ex.StackTrace);
        //    }
        //}
        //protected void lnk_btn_Category_Inner_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        LinkButton linkButton = new LinkButton();
        //        linkButton = (LinkButton)sender;
        //        Int64 categoryID = (Convert.ToInt64(linkButton.CommandArgument));
        //        Response.Redirect("DefaultInner.aspx?val=" + categoryID.ToString(), false);
        //    }
        //    catch (Exception ex)
        //    {
        //        LogFileWritten(ex.Message, ex.StackTrace);
        //    }
        //}
        //protected void rp_Inner_Category_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        Label objlbl_Total_Products_Inner = e.Item.FindControl("lbl_Total_Products_Inner") as Label;
        //        HiddenField obj_Inner_IID = e.Item.FindControl("hf_inner_CategoryIID") as HiddenField;

        //        var result = _materialRT.GetAllMaterialAccordingToCategoryIID(Convert.ToInt64(obj_Inner_IID.Value));
        //        objlbl_Total_Products_Inner.Text = Convert.ToString(result.Count);
        //    }
        //}

        protected void lvOthersFormOiiO_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }
        #endregion All Protected Methods-----------------------
    }
}