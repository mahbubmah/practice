using Microsoft.Ajax.Utilities;
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
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using AjaxControlToolkit;
namespace OH.Web
{
    public partial class DefaultInner : System.Web.UI.Page
    {
        private readonly MaterialRT _materialRT;
        private readonly CategoryRT _categoryRT;
        private readonly VisitorIPMACAddress _visitorIPMACAddress;
        private readonly CountryRT _countryRT;
        private readonly DivisionOrStateRT _divisionOrStateRT;

        public string QueryResult { get; set; }

        Int64 CategoryID = default(Int64);
        Int64 CatID = default(Int64);
        Int64 catIDForDropDown = default(Int64);
        public int lvRowCount { get; set; }
        public int currentPage { get; set; }
        private const string sessAdsType = "seAdsType";

        string EncryptedString = default(string);
        public DefaultInner()
        {
            this._materialRT = new MaterialRT();
            this._categoryRT = new CategoryRT();
            this._visitorIPMACAddress = new VisitorIPMACAddress();
            this._countryRT = new CountryRT();
            this._divisionOrStateRT = new DivisionOrStateRT();
        }


        #region All  Methods---------------------

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    Session[sessAdsType] = null;
                    GettingCurrentUrl();

                    QueryResult = GetQueryStringDataForSearch();
                    CategoryID = GetCategoryIdByName(QueryResult);

                    CountForMaterialAllAds(CategoryID == 0 ? CatID : CategoryID);
                    //Finding Parent CategoryID For Child CategoryID to Select DropdownList
                    if (CatID > 0 && IsParentCategory(CatID) == false)
                    {
                        catIDForDropDown = GetParentCategoryIdForChild(CatID);
                        LoadDropDownCategory(catIDForDropDown);
                    }
                    else
                        LoadDropDownCategory(CategoryID == 0 ? CatID : CategoryID);
                    CountForPrivateAds(CategoryID == 0 ? CatID : CategoryID,
                        Convert.ToInt32(EnumCollection.ClientType.Personal));
                    ////LoadListViewForPrivateAds(CategoryID == 0 ? CatID : CategoryID, Convert.ToInt32(EnumCollection.ClientType.Personal));
                    CountForBusinessAds(CategoryID == 0 ? CatID : CategoryID,
                        Convert.ToInt32(EnumCollection.ClientType.OrganiztionOrCompany));
                    //// LoadListViewForBusinessAds(CategoryID == 0 ? CatID : CategoryID, Convert.ToInt32(EnumCollection.ClientType.OrganiztionOrCompany));                                 
                    LoadingAllParentCategory();
                    ////LoadListViewForRecentMaterial(CategoryID == 0 ? CatID : CategoryID);
                    CountRecentMaterial(CategoryID == 0 ? CatID : CategoryID);
                    LoadAllCountries();

                    //  LoadAds();
                }
            }
            catch (Exception ex)
            {
                LogFileWritten(ex.Message, ex.StackTrace);
            }


        }


        private void GettingCurrentUrl()
        {
            string currentURL = HttpContext.Current.Request.Url.AbsoluteUri;
            Session["backURL"] = currentURL;
        }
        private string GetQueryStringDataForSearch()
        {
            string categoryType = default(string);
            try
            {
                if (Request.QueryString != null && Request.QueryString.ToString()!=string.Empty)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString[0]))
                    {
                        string EncryptedString = Request.QueryString[0];
                        string DecrptedIString = StringCipher.Decrypt(EncryptedString).ToString();
                        bool reqIDIsValid = Int64.TryParse(DecrptedIString.ToString(), out CatID);
                        if (!reqIDIsValid)
                        {
                            categoryType = DecrptedIString;
                        }
                    }
                    else
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                LogFileWritten(ex.Message, ex.StackTrace);
            }
            return categoryType;
        }

        private Int64 GetCategoryIdByName(string categoryName)
        {
            Int64 categoryID = 0;
            try
            {
                if (!String.IsNullOrEmpty(categoryName))
                    categoryID = _categoryRT.GetParentCategoryIDByName(categoryName);

            }
            catch (Exception ex)
            {
                LogFileWritten(ex.Message, ex.StackTrace);
            }
            return categoryID;
        }

        private void CountForMaterialAllAds(Int64 categoryID)
        {
            try
            {
                var result = _materialRT.GetAllMaterialAccordingToCategoryIID(Convert.ToInt64(categoryID));

                if (result.Count > 0)
                    lblAllAds.Text = Convert.ToString(result.Count);
                else
                    lblAllAds.Text = "0";
            }
            catch (Exception ex)
            {
                LogFileWritten(ex.Message, ex.StackTrace);
            }
        }

        private bool IsParentCategory(Int64 CatID)
        {

            bool isParent = true;
            try
            {
                isParent = _categoryRT.IsParentCategoryID(CatID);
                return isParent;

            }
            catch (Exception ex)
            {
                LogFileWritten(ex.Message, ex.StackTrace);
            }
            return isParent;
        }

        private Int64 GetParentCategoryIdForChild(Int64 CatID)
        {
            try
            {
                CatID = Convert.ToInt64(_categoryRT.GetParentCategoryIDForChildID(CatID).ParentID);
            }
            catch (Exception ex)
            {
                LogFileWritten(ex.Message, ex.StackTrace);
            }
            return CatID;
        }

        private void LoadDropDownCategory(Int64 categoryID)
        {
            try
            {
                List<Category> catagoryList = new List<Category>();
                catagoryList = _categoryRT.GetAllParentCategory();
                DropDownListHelper.Bind<Category>(ddlCategory, catagoryList, "Name", "IID", EnumCollection.ListItemType.Category);
                ddlCategory.SelectedValue = categoryID.ToString();
            }
            catch (Exception ex)
            {
                LogFileWritten(ex.Message, ex.StackTrace);
            }
        }

        private void CountForPrivateAds(Int64 categoryID, int clientTypeID)
        {
            try
            {
                int result = _materialRT.GetCountAllMaterialForCategoryIDnClientType(categoryID, clientTypeID);

                if (result != 0)
                    lblPrivateAds.Text = result.ToString();
                else
                    lblPrivateAds.Text = "0";
            }
            catch (Exception ex)
            {
                LogFileWritten(ex.Message, ex.StackTrace);
            }
        }


        private void CountForBusinessAds(Int64 categoryID, int clientTypeID)
        {
            try
            {
                int result = _materialRT.GetCountAllMaterialForCategoryIDnClientType(categoryID, clientTypeID);

                if (result != 0)
                    lblBusinessAds.Text = result.ToString();
                else
                    lblBusinessAds.Text = "0";
            }
            catch (Exception ex)
            {
                LogFileWritten(ex.Message, ex.StackTrace);
            }
        }



        private void LoadingAllParentCategory()
        {
            try
            {
                var objAllCategory = _categoryRT.GetAllParentCategory().ToList();

                rp_Load_Category_Outer.DataSource = objAllCategory;
                rp_Load_Category_Outer.DataBind();
            }
            catch (Exception ex)
            {
                LogFileWritten(ex.Message, ex.StackTrace);
            }
        }

        private void CountRecentMaterial(Int64 categoryID)
        {
            try
            {
                int result = _materialRT.CountAllRecentMaterialForCategoryIID(categoryID);

                if (result > 0)
                    lblMostRecentAds.Text = result.ToString();
                else
                    lblMostRecentAds.Text = "0";
            }
            catch (Exception ex)
            {
                LogFileWritten(ex.Message, ex.StackTrace);
            }
        }


        private void LoadAllCountries()
        {
            try
            {
                var result = _countryRT.GetCountryAll().Where(x => x.IsRemoved == false).ToList();
                rp_Country_Load.DataSource = result;
                rp_Country_Load.DataBind();
            }
            catch (Exception ex)
            {
                LogFileWritten(ex.Message, ex.StackTrace);
            }
        }

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

        private void VisitorLogFileWritten()
        {
            var datetime = DateTime.Now.ToString();
            try
            {
                string path = Server.MapPath("~/Resources/VisitorlogFileWriting.txt");
                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();
                    using (TextWriter tw = new StreamWriter(path))
                    {
                        var text = datetime + "        " + _visitorIPMACAddress.GetVisitorIPAddress() + "        " + _visitorIPMACAddress.GetVisitorMACAddress();
                        tw.WriteLine(text);

                        tw.Flush();
                        tw.Close();
                    }
                }
                else if (File.Exists(path))
                {
                    using (var tw = File.AppendText(path))
                    {
                        var text = datetime + "        " + _visitorIPMACAddress.GetVisitorIPAddress() + "         " + _visitorIPMACAddress.GetVisitorMACAddress();
                        tw.WriteLine(text);
                        tw.Flush();
                        tw.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                LogFileWritten(ex.Message, ex.StackTrace);
            }
        }







        #endregion All  Methods---------------------

        #region ALL Events--------------------------






        protected void lvForAllAddsMaterial_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int categoryIID = Convert.ToInt32(ddlCategory.SelectedValue);
                Response.Redirect("DefaultInner.aspx?tp=" + StringCipher.Encrypt(categoryIID.ToString()), false);
            }
            catch (Exception ex)
            {
                LogFileWritten(ex.Message, ex.StackTrace);
            }

        }

        protected void rp_Load_Category_Outer_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label objLabel = e.Item.FindControl("lbl_Total_Products") as Label;
                HiddenField objIID = e.Item.FindControl("hfCategoryIID") as HiddenField;

                var result = _materialRT.GetAllMaterialAccordingToCategoryIID(Convert.ToInt64(objIID.Value));
                objLabel.Text = Convert.ToString(result.Count);

                var objChildCategoryList = _categoryRT.GetAllCategoryByParentID(Convert.ToInt64(objIID.Value));
                Repeater objRepeater = e.Item.FindControl("rp_Inner_Category") as Repeater;
                objRepeater.DataSource = objChildCategoryList;
                objRepeater.DataBind();

            }
        }

        protected void rp_Inner_Category_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label objlbl_Total_Products_Inner = e.Item.FindControl("lbl_Total_Products_Inner") as Label;
                HiddenField obj_Inner_IID = e.Item.FindControl("hf_inner_CategoryIID") as HiddenField;

                var result = _materialRT.GetAllMaterialAccordingToCategoryIID(Convert.ToInt64(obj_Inner_IID.Value));
                objlbl_Total_Products_Inner.Text = Convert.ToString(result.Count);
            }
        }

        protected void rp_Country_Load_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    HiddenField cID = e.Item.FindControl("hfCIID") as HiddenField;

                    var result = (from tr in _divisionOrStateRT.GetDivisionOrStateAll()
                                  where tr.CountryID == Convert.ToInt64(cID.Value)
                                  select tr).ToList();

                    Repeater objRepeater = e.Item.FindControl("rp_StateDivision") as Repeater;
                    objRepeater.DataSource = result;
                    objRepeater.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogFileWritten(ex.Message, ex.StackTrace);
            }
        }


        protected void btn_Category_Link_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                Int64 categoryID = (Convert.ToInt64(linkButton.CommandArgument));
                Response.Redirect("DefaultInner.aspx?tp=" + StringCipher.Encrypt(categoryID.ToString()), false);
                //LoadListViewForMaterial(categoryID);
            }
            catch (Exception ex)
            {
                LogFileWritten(ex.Message, ex.StackTrace);
            }
        }

        protected void lnk_btn_Category_Inner_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                Int64 categoryID = (Convert.ToInt64(linkButton.CommandArgument));
                Response.Redirect("DefaultInner.aspx?tp=" + StringCipher.Encrypt(categoryID.ToString()), false);
            }
            catch (Exception ex)
            {
                LogFileWritten(ex.Message, ex.StackTrace);
            }
        }

        protected void OnRatingChanged(object sender, RatingEventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["Data Source=192.168.1.2;Initial Catalog=AjaxSamples;Persist Security Info=True;User ID=sa;Password=oIIoAdmin"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO UserRatings VALUES(@Rating)"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Rating", e.Value);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            Response.Redirect(Request.Url.AbsoluteUri);
            DataTable dt = this.GetData("SELECT ISNULL(AVG(Rating), 0) AverageRating, COUNT(Rating) RatingCount FROM UserRatings");
            // Rating1.CurrentRating = Convert.ToInt32(dt.Rows[0]["AverageRating"]);
            // lblRatingStatus.Text = string.Format("{0} Users have rated. Average Rating {1}", dt.Rows[0]["RatingCount"], dt.Rows[0]["AverageRating"]);

        }

        private DataTable GetData(string query)
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["Data Source=192.168.1.2;Initial Catalog=AjaxSamples;Persist Security Info=True;User ID=sa;Password=oIIoAdmin"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                    }
                }
                return dt;
            }
        }



        protected void objDataSourceForMaterial_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            try
            {
                QueryResult = GetQueryStringDataForSearch();
                CategoryID = GetCategoryIdByName(QueryResult);
                e.InputParameters["categoryID"] = (CategoryID == 0 ? CatID : CategoryID);
                e.InputParameters["clientTypeId"] = null;
                e.InputParameters["isRecent"] = false;
                if (Session[sessAdsType] != null)
                {
                    switch ((string)Session[sessAdsType])
                    {
                        case "PrivateAds":
                            e.InputParameters["clientTypeId"] = 1;
                            break;
                        case "BusinessAds":
                            e.InputParameters["clientTypeId"] = 2;
                            break;
                        case "MostRecentAds":
                            e.InputParameters["isRecent"] = true;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                LogFileWritten(ex.Message, ex.StackTrace);
            }
        }







        #endregion ALL Events--------------------------



        protected void lnkBtnPrivateAds_OnClick(object sender, EventArgs e)
        {
            liAllAds.Attributes.Remove("class");
            liBusinessAds.Attributes.Remove("class");
            liPrivateAds.Attributes.Add("class", "active");
            liMostRecentAds.Attributes.Remove("class");

            Session[sessAdsType] = lnkBtnPrivateAds.CommandArgument;
            lvForAllAddsMaterial.DataBind();
        }


        protected void lnkBtnAllAds_OnClick(object sender, EventArgs e)
        {
            liAllAds.Attributes.Add("class", "active");
            liBusinessAds.Attributes.Remove("class");
            liPrivateAds.Attributes.Remove("class");
            liMostRecentAds.Attributes.Remove("class");

            Session[sessAdsType] = lnkBtnAllAds.CommandArgument;
            lvForAllAddsMaterial.DataBind();
        }

        protected void lnkBtnBusinessAds_OnClick(object sender, EventArgs e)
        {
            liAllAds.Attributes.Remove("class");
            liBusinessAds.Attributes.Add("class", "active");
            liPrivateAds.Attributes.Remove("class");
            liMostRecentAds.Attributes.Remove("class");

            Session[sessAdsType] = lnkBtnBusinessAds.CommandArgument;
            lvForAllAddsMaterial.DataBind();
        }

        protected void lnkBtnMostRecentAds_OnClick(object sender, EventArgs e)
        {
            liAllAds.Attributes.Remove("class");
            liBusinessAds.Attributes.Remove("class");
            liPrivateAds.Attributes.Remove("class");
            liMostRecentAds.Attributes.Add("class", "active");

            Session[sessAdsType] = lnkBtnMostRecentAds.CommandArgument;
            lvForAllAddsMaterial.DataBind();
        }
    }
}