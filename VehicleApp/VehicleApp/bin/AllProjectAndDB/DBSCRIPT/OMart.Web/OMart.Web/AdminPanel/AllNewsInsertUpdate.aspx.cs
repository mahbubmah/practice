using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;
using DAL;
using Microsoft.Ajax.Utilities;
using Utilities;

namespace OMart.Web.AdminPanel
{
    public partial class AllNewsInsertUpdate : System.Web.UI.Page
    {
        private readonly AllNewsRT _allNewsRt;
        private const string sessAllNewsDetail = "seAllNewsDetail";
        private int IID = default(Int32);
        int lvRowCount = 0;
        int currentPage = 0;


        public AllNewsInsertUpdate()
        {
            _allNewsRt = new AllNewsRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadDropDownForBusinessType();
                    LoadDropDownForBusinessTypeBreakdown();
                    Session[sessAllNewsDetail] = new List<AllNewsDetail>();
                    var requestId = Request.QueryString["IID"];
                    bool reqIDIsValid = Int32.TryParse(requestId, out IID);
                    if (reqIDIsValid)
                    {
                        ShowAllNewsData();
                    }
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }


        #region private methods
        private void LoadDropDownForBusinessType()
        {
            try
            {
                dropDownBusinessType.Items.Add(new ListItem("--Select--", "-1"));
                DropDownListHelper.Bind(dropDownBusinessType, EnumHelper.EnumCamelSpaceToList<EnumCollection.BussinessType>());
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void LoadDropDownForBusinessTypeBreakdown()
        {
            try
            {

                dropDownBusinessTypeBreakdown.Items.Clear();
                dropDownBusinessTypeBreakdown.Items.Add(new ListItem("--Select--", "-1"));
                switch (dropDownBusinessType.SelectedValue)
                {
                    case "1":
                        DropDownListHelper.Bind(dropDownBusinessTypeBreakdown, EnumHelper.EnumCamelSpaceToList<EnumCollection.BusinessEnergyType>());
                        break;
                    case "2":
                        DropDownListHelper.Bind(dropDownBusinessTypeBreakdown, EnumHelper.EnumCamelSpaceToList<EnumCollection.BusinessBankingType>());
                        break;
                    case "3":
                        DropDownListHelper.Bind(dropDownBusinessTypeBreakdown, EnumHelper.EnumCamelSpaceToList<EnumCollection.BusinessTravelType>());
                        break;
                    case "4":
                        DropDownListHelper.Bind(dropDownBusinessTypeBreakdown, EnumHelper.EnumCamelSpaceToList<EnumCollection.BusinessInsuranceType>());
                        break;
                    case "5":
                        DropDownListHelper.Bind(dropDownBusinessTypeBreakdown, EnumHelper.EnumCamelSpaceToList<EnumCollection.BusinessShoppingType>());
                        break;
                    case "6":
                        DropDownListHelper.Bind(dropDownBusinessTypeBreakdown, EnumHelper.EnumCamelSpaceToList<EnumCollection.BusinessMobilePhonesType>());
                        break;
                    case "7":
                        DropDownListHelper.Bind(dropDownBusinessTypeBreakdown, EnumHelper.EnumCamelSpaceToList<EnumCollection.NetworkServiceProvider>());
                        break;
                    case "8":
                        DropDownListHelper.Bind(dropDownBusinessTypeBreakdown, EnumHelper.EnumCamelSpaceToList<EnumCollection.BusinessBroadbandType>());
                        break;
                }

            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void ShowAllNewsData()
        {
            try
            {
                AllNews allNews = _allNewsRt.GetAllNewsByIid(IID);
                if (allNews.IsRemoved)
                {
                    labelMessage.Text = "Error : this information has been removed.";
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (allNews.IID > 0)
                {
                    if (Session[sessAllNewsDetail] == null || !((List<AllNewsDetail>)Session[sessAllNewsDetail]).Any())
                    {
                        Session[sessAllNewsDetail] = new List<AllNewsDetail>(_allNewsRt.GetAllNewsDetailListByAllNesIid(allNews.IID));
                        // Session[sessAllNewsDetail] = _allNewsRt.GetAllNewsDetailListByAllNesIid(allNews.IID);
                    }

                    txtDescription.Text = allNews.Description;
                    // txtImageUrl.Text = allNews.ImageUrl;
                    txtTitleName.Text = allNews.TitleName;

                    dropDownBusinessType.SelectedValue = allNews.BusinessTypeID.ToString();
                    LoadDropDownForBusinessTypeBreakdown();
                    dropDownBusinessTypeBreakdown.SelectedValue = allNews.BusinessTypeBreakdownID.ToString();
                }
                ShowAllNewsDetailsData();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void ShowAllNewsDetailsData()
        {
            if (Session[sessAllNewsDetail] == null) return;
            lvAllNewsDetails.DataSource = Session[sessAllNewsDetail];
            lvAllNewsDetails.DataBind();
        }
        private string BusinessLogicValidationAllNews(AllNews allNews)
        {
            string msg = string.Empty;
            try
            {
                if (txtTitleName.Text.IsNullOrWhiteSpace())
                {
                    msg = "Please enter a title";
                }
                if (txtDescription.Text.IsNullOrWhiteSpace())
                {
                    msg = "Please enter description";
                }
                if (dropDownBusinessType.SelectedValue == "-1" || dropDownBusinessType.SelectedValue.IsNullOrWhiteSpace())
                {
                    msg = "Please select business type";
                }

            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return msg;
        }
        private string BusinessLogicValidationAllNewsDetail(AllNewsDetail allNewsDetail)
        {
            string msg = string.Empty;
            try
            {
                if (txtDetailTitleName.Text.IsNullOrWhiteSpace())
                {
                    msg = "please enter a title";
                }
                if (txtDetailDescription.Text.IsNullOrWhiteSpace())
                {
                    msg = "please enter description";
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return msg;
        }
        private AllNewsDetail CreateAllNewsDetails()
        {

            AllNewsDetail allNewsDetail = new AllNewsDetail();
            try
            {
                if (fuAllNewsDetails.HasFile)
                {
                    string path = Server.MapPath("~/All Photos/NewsImage/AllNewsDetailsTemp/");
                    string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff", CultureInfo.InvariantCulture);
                    var sb = new StringBuilder();
                    foreach (char t in now.Where(char.IsLetterOrDigit))
                    {
                        sb.Append(t);
                    }

                    now = sb.ToString();//save to now string
                    var rnd = new Random(100000);
                    var allNewsDetailTempImageName = now + rnd.Next();
                    FileUploadHelper.BindImage(fuAllNewsDetails, path, allNewsDetailTempImageName);
                    allNewsDetail.ImageUrl = "~/All Photos/NewsImage/AllNewsDetailsTemp/" + allNewsDetailTempImageName + Path.GetExtension(fuAllNewsDetails.FileName);
                }

                allNewsDetail.TitleName = txtDetailTitleName.Text;
                //allNewsDetail.ImageUrl = txtDetailImageUrl.Text;
                allNewsDetail.Description = txtDetailDescription.Text;
                allNewsDetail.IsRemoved = false;
                if (allNewsDetail.CreatedBy == 0)
                {
                    allNewsDetail.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    allNewsDetail.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    allNewsDetail.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    allNewsDetail.ModifiedDate = GlobalRT.GetServerDateTime();
                }

            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return allNewsDetail;
        }
        private AllNews CreateAllNews()
        {

            AllNews allNews = new AllNews();
            try
            {
                var allNewsByIid = new AllNews();
                if (IID > 0)
                {
                    allNews.IID = IID;
                    allNewsByIid = _allNewsRt.GetAllNewsByIid(IID);
                    if (allNewsByIid != null)
                    {
                        allNews = allNewsByIid;
                    }
                }

                allNews.ReleaseDate = GlobalRT.GetServerDateTime();
                allNews.TitleName = txtTitleName.Text;
                //allNews.ImageUrl = txtImageUrl.Text;
                allNews.Description = txtDescription.Text;
                if (dropDownBusinessTypeBreakdown.SelectedValue != "-1" || !dropDownBusinessTypeBreakdown.SelectedValue.IsNullOrWhiteSpace())
                {
                    allNews.BusinessTypeBreakdownID = Convert.ToInt32(dropDownBusinessTypeBreakdown.SelectedValue);
                }
                if (dropDownBusinessType.SelectedValue != "-1" || !dropDownBusinessType.SelectedValue.IsNullOrWhiteSpace())
                {
                    allNews.BusinessTypeID = Convert.ToInt32(dropDownBusinessType.SelectedValue);
                }


                if (allNews.CreatedBy == 0)
                {
                    allNews.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    allNews.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    allNews.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    allNews.ModifiedDate = GlobalRT.GetServerDateTime();
                }
                allNews.IsRemoved = false;
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return allNews;
        }
        private void ClearData()
        {
            txtDescription.Text = string.Empty;
            txtDetailDescription.Text = string.Empty;
            // txtDetailImageUrl.Text = string.Empty;
            txtDetailTitleName.Text = string.Empty;
            // txtImageUrl.Text = string.Empty;
            txtTitleName.Text = string.Empty;
            dropDownBusinessTypeBreakdown.SelectedValue = "-1";
            dropDownBusinessType.SelectedValue = "-1";
            lvAllNewsDetails.Items.Clear();
            lvAllNewsDetails.DataBind();
        }
        private void ClearAllNewsData()
        {
            txtDetailDescription.Text = string.Empty;
            // txtDetailImageUrl.Text = string.Empty;
            txtDetailTitleName.Text = string.Empty;
        }

        #endregion private methods





        #region protected event
        protected void btnCreateOrEditAllNewsDetail_OnClick(object sender, EventArgs e)
        {
            try
            {
                var requestId = Request.QueryString["IID"];
                bool reqIDIsValid = Int32.TryParse(requestId, out IID);
                AllNewsDetail allNewsDetail = CreateAllNewsDetails();
                var msg = BusinessLogicValidationAllNewsDetail(allNewsDetail);
                if (msg.IsNullOrWhiteSpace())
                {
                    if (Session[sessAllNewsDetail] == null)
                    {
                        Session[sessAllNewsDetail] = new List<AllNewsDetail>();
                    }
                    List<AllNewsDetail> allNewsDetailList = (List<AllNewsDetail>)Session[sessAllNewsDetail];
                    allNewsDetailList.Add(allNewsDetail);
                    Session[sessAllNewsDetail] = allNewsDetailList;
                    ShowAllNewsDetailsData();
                    ClearAllNewsData();

                    labelMessage.Text = "Information has been inserted successfully.";
                    labelMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    labelMessage.Text = msg;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }

        }
        protected void btnAllNewsDetailCancel_Click(object sender, EventArgs e)
        {
            ClearAllNewsData();
        }
        protected void btnCreateOrEdit_Click(object sender, EventArgs e)
        {
            try
            {
                bool reqIDIsValid = int.TryParse(Request.QueryString["IID"], out IID);
                AllNews allNews = CreateAllNews();

                var msg = BusinessLogicValidationAllNews(allNews);
                if (msg.IsNullOrWhiteSpace())
                {
                    string allNewsImageName = string.Empty;
                    string path = Server.MapPath("~/All Photos/NewsImage/AllNews/");
                    if (IID > 0)
                    {
                        allNewsImageName = IID.ToString();
                    }
                    else
                    {
                        var allNewsLast = _allNewsRt.GetAllNewsLast();
                        if (allNewsLast != null)
                        {
                            allNewsImageName = (allNewsLast.IID + 1).ToString();
                        }
                        else
                        {
                            allNewsImageName = "1";
                        }
                    }
                    if (fuAllNews.HasFile)
                    {
                        allNews.ImageUrl = "~/All Photos/NewsImage/AllNews/" + allNewsImageName + Path.GetExtension(fuAllNews.FileName);
                    }

                    if (IID <= 0)
                    {
                        List<AllNewsDetail> allNewsDetailColl = new List<AllNewsDetail>();
                        List<AllNewsDetail> allNewsDetailList = (List<AllNewsDetail>)Session[sessAllNewsDetail];

                        if (allNewsDetailList.Count > 0)
                        {
                            foreach (var allnews in allNewsDetailList)
                            {
                                if (allnews.ImageUrl != null)
                                {
                                    if (allnews.ImageUrl.StartsWith("~/All Photos/NewsImage/AllNewsDetailsTemp/"))
                                    {
                                        File.Move(Server.MapPath(allnews.ImageUrl), Server.MapPath("~/All Photos/NewsImage/AllNewsDetails/") + Path.GetFileName(allnews.ImageUrl));
                                        allnews.ImageUrl = "~/All Photos/NewsImage/AllNewsDetails/" + Path.GetFileName(allnews.ImageUrl);
                                    }
                                }

                            }
                            allNewsDetailColl = allNewsDetailList;
                        }



                        string allNewsWithAllChildAllNewsDetailXML = ConversionXML.ConvertObjectToXML<AllNews, AllNewsDetail>(allNews, allNewsDetailColl, string.Empty);

                        int allNewsId = AllNewsRT.InsertAllNewsAndAllChildAllNewsCartDetailsXML(allNewsWithAllChildAllNewsDetailXML);
                        if (allNewsId > 0)
                        {
                            if (fuAllNews.HasFile)
                            {
                                FileUploadHelper.BindImage(fuAllNews, path, allNewsImageName);
                            }
                            Session[sessAllNewsDetail] = new List<AllNewsDetail>();
                            ClearData();
                            labelMessage.Text = "Information has been inserted successfully.";
                            labelMessage.ForeColor = System.Drawing.Color.Green;
                        }
                        else if (allNewsId == -100)
                        {
                            labelMessage.Text = "Network connection fail ... Please try again..!!";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                            labelMessage.Focus();
                        }
                        else if (allNewsId == -101)
                        {
                            labelMessage.Text = "Network connection fail ... Please try again..!!";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                            labelMessage.Focus();
                        }
                        else
                        {
                            labelMessage.Text = "Error";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                            labelMessage.Focus();
                        }
                    }
                    else
                    {
                        AllNews objAllNews = _allNewsRt.GetAllNewsByIid(IID);

                        if (objAllNews != null)
                        {

                            allNews.IID = objAllNews.IID;

                            allNews.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                            allNews.ModifiedDate = GlobalRT.GetServerDateTime();

                            _allNewsRt.UpdateAllNews(allNews);
                            if (fuAllNews.HasFile)
                            {
                                FileUploadHelper.BindImage(fuAllNews, path, allNewsImageName);
                            }


                            var allNewsDetailsListToRemove = _allNewsRt.GetAllNewsDetailListByAllNesIid(IID);
                            foreach (var allNewsDetail in allNewsDetailsListToRemove)
                            {
                                allNewsDetail.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                                allNewsDetail.ModifiedDate = GlobalRT.GetServerDateTime();
                                allNewsDetail.IsRemoved = true;
                                _allNewsRt.UpdateAllNewsDetail(allNewsDetail);
                            }

                            List<AllNewsDetail> allNewsDetailsListToAdd = (List<AllNewsDetail>)Session[sessAllNewsDetail];
                            foreach (var allNewsDetail in allNewsDetailsListToAdd)
                            {
                                if (allNewsDetail.IID <= 0)
                                {
                                    allNewsDetail.AllNewsID = IID;
                                    _allNewsRt.AddAllNewsDetail(allNewsDetail);
                                }
                                else
                                {
                                    allNewsDetail.IsRemoved = false;
                                    allNewsDetail.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                                    allNewsDetail.ModifiedDate = GlobalRT.GetServerDateTime();
                                    _allNewsRt.UpdateAllNewsDetail(allNewsDetail);
                                }
                            }


                            Session[sessAllNewsDetail] = new List<AllNewsDetail>();
                            ClearData();

                            labelMessage.Text = "Information has been updated successfully.";
                            labelMessage.ForeColor = System.Drawing.Color.Green;
                        }
                    }


                }
                else
                {
                    labelMessage.Text = msg;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }


            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void lvAllNewsDetails_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            labelMessage.Text = string.Empty;
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }
        protected void dataPagerAllNewsDetails_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    // ShowAllNewsDetailsData();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void lnkbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                List<AllNewsDetail> allNewsDetailList = (List<AllNewsDetail>)Session[sessAllNewsDetail];
                if (allNewsDetailList.Count > 0)
                {
                    var firstOrDefault = allNewsDetailList.FirstOrDefault(x => x.TitleName == linkButton.CommandArgument);
                    if (firstOrDefault != null)
                    {
                        File.Delete(Server.MapPath(firstOrDefault.ImageUrl));
                    }
                    allNewsDetailList.Remove(allNewsDetailList.FirstOrDefault(x => x.TitleName == linkButton.CommandArgument));

                    Session[sessAllNewsDetail] = allNewsDetailList;
                    ShowAllNewsDetailsData();

                    labelMessage.Text = "News details has been removed successfully.";
                    labelMessage.ForeColor = System.Drawing.Color.Green;

                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void dropDownBusinessType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (dropDownBusinessType.SelectedValue != "-1" || !dropDownBusinessType.SelectedValue.IsNullOrWhiteSpace())
                {
                    LoadDropDownForBusinessTypeBreakdown();
                }

            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/AdminPanel/AllNewsDisplay.aspx");
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        #endregion protected event




    }
}