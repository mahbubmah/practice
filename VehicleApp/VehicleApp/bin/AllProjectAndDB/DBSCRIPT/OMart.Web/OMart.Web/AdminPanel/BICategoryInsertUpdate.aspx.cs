using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;
using DAL;
using Microsoft.Ajax.Utilities;
using Utilities;

namespace OMart.Web.AdminPanel
{
    public partial class BICategoryInsertUpdate : System.Web.UI.Page
    {
        private readonly BICategoryRT _biCategoryRt;
        private const string sessBiCategoryChild = "seBiCategoryChild";
        private long IID = default(Int64);

        public BICategoryInsertUpdate()
        {
            _biCategoryRt = new BICategoryRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Session[sessBiCategoryChild] = new List<BICategoryDetail>();
                    var requestId = Request.QueryString["IID"];
                    bool reqIDIsValid = Int64.TryParse(requestId, out IID);
                    if (reqIDIsValid)
                    {
                        ShowBiCategoryData();
                    }
                }

            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnCreateOrEdit_Click(object sender, EventArgs e)
        {
            try
            {
                //Session[sessBiCategoryChild] = new List<BICategoryDetail>();
                var requestId = Request.QueryString["IID"];
                bool reqIDIsValid = Int64.TryParse(requestId, out IID);
                var biCategory = CreateBiCategory();
                string msg = BusinessLogicValidationBiCategory(biCategory);
                if (msg.IsNullOrWhiteSpace())
                {
                    if (IID <= 0)//insert
                    {
                        biCategory.CreatedBy = Convert.ToInt64(Session["UserID"]);
                        biCategory.CreatedDate = GlobalRT.GetServerDateTime();
                        biCategory.IsRemoved = false;

                        List<BICategoryDetail> bICategoryDetailColl = (List<BICategoryDetail>)Session[sessBiCategoryChild];

                        foreach (var biCategoryDetail in bICategoryDetailColl)
                        {
                            biCategoryDetail.CreatedBy = Convert.ToInt64(Session["UserID"]);
                            biCategoryDetail.CreatedDate = GlobalRT.GetServerDateTime();
                            biCategoryDetail.IsRemoved = false;
                        }

                        string bICategoryAndChildCategoryXml = ConversionXML.ConvertObjectToXML<BICategory, BICategoryDetail>(biCategory, bICategoryDetailColl, string.Empty);

                        int biCategoryIid = _biCategoryRt.InsertBiCategoryAndChildCategoryXml(bICategoryAndChildCategoryXml);
                        if (biCategoryIid > 0)
                        {
                            labelMessage.Text = "Information has been inserted successfully.";
                            labelMessage.ForeColor = System.Drawing.Color.Green;
                        }
                        else if (biCategoryIid == -100)
                        {
                            labelMessage.Text = "Network connection fail ... Please try again..!!";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                            labelMessage.Focus();
                        }
                        else if (biCategoryIid == -101)
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
                    else//Update
                    {
                        var objBiCategory = _biCategoryRt.GetBiCategoryByIid(IID);

                        if (objBiCategory != null)
                        {
                            biCategory.IID = objBiCategory.IID;
                            biCategory.CreatedBy = objBiCategory.CreatedBy;
                            biCategory.CreatedDate = objBiCategory.CreatedDate;
                            biCategory.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                            biCategory.ModifiedDate = GlobalRT.GetServerDateTime();
                            _biCategoryRt.UpdateBiCategory(biCategory);


                            var biCategoryDetailListToRemove = _biCategoryRt.GetBiCategoryChildListByCategoryIid(IID);
                            foreach (var biCategoryDetail in biCategoryDetailListToRemove)
                            {
                                biCategoryDetail.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                                biCategoryDetail.ModifiedDate = GlobalRT.GetServerDateTime();
                                biCategoryDetail.IsRemoved = true;
                                _biCategoryRt.UpdateBiCategoryDetail(biCategoryDetail);
                            }
                            List<BICategoryDetail> biCategoryDetailListToAdd = (List<BICategoryDetail>)Session[sessBiCategoryChild];
                            foreach (var biCategoryDetail in biCategoryDetailListToAdd)
                            {
                                if (biCategoryDetail.IID <= 0)
                                {
                                    biCategoryDetail.BICategoryID = IID;
                                    _biCategoryRt.AddCategoryDetail(biCategoryDetail);
                                }
                                else
                                {
                                    biCategoryDetail.IsRemoved = false;
                                    biCategoryDetail.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                                    biCategoryDetail.ModifiedDate = GlobalRT.GetServerDateTime();
                                    _biCategoryRt.UpdateBiCategoryDetail(biCategoryDetail);
                                }
                            }
                            labelMessage.Text = "Information has been updated successfully.";
                            labelMessage.ForeColor = System.Drawing.Color.Green;
                        }
                    }
                    ClearData();
                    Session[sessBiCategoryChild] =new List<BICategoryDetail>();
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

        private void ClearData()
        {
            lvBiCategoryChild.Items.Clear();
            lvBiCategoryChild.DataBind();
            txtName.Text = string.Empty;
            txtNote.Text = string.Empty;
        }

        private void ShowBiCategoryData()
        {
            try
            {
                if (IID > 0)
                {
                    var biCategory = _biCategoryRt.GetBiCategoryByIid(IID);
                    if (biCategory != null)
                    {
                        txtName.Text = biCategory.Name;
                        if (!biCategory.Note.IsNullOrWhiteSpace())
                        {
                            txtNote.Text = biCategory.Note;
                        }
                        Session[sessBiCategoryChild] = _biCategoryRt.GetBiCategoryChildListByCategoryIid(biCategory.IID);
                        ShowBiCategoryDetailData();
                    }

                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ShowBiCategoryDetailData()
        {
            try
            {
                if (Session[sessBiCategoryChild] != null)
                {
                    lvBiCategoryChild.DataSource = Session[sessBiCategoryChild];
                    lvBiCategoryChild.DataBind();
                }

            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }

        }

        private BICategory CreateBiCategory()
        {
            try
            {
                var biCategory = new BICategory { Name = txtName.Text, Note = txtNote.Text };
                return biCategory;
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return null;
        }

        private BICategoryDetail CreateBiCategoryDetail()
        {
            try
            {
                var biCategoryDetaiil = new BICategoryDetail { Name = txtNameChild.Text, Note = txtNoteChild.Text };
                return biCategoryDetaiil;
            }
            catch (Exception ex)
            {
                lblMessageChild.Text = "Error : " + ex.Message;
                lblMessageChild.ForeColor = System.Drawing.Color.Red;
            }
            return null;
        }

        private string BusinessLogicValidationBiCategory(BICategory biCategory)
        {
            try
            {
                string msg = string.Empty;

                if (txtName.Text.IsNullOrWhiteSpace())
                {
                    msg = "please enter category name..";
                    return msg;
                }
                //chk duplicate name
                bool isNameExist = _biCategoryRt.IsCategoryNameExist(biCategory.Name);
                if (IID <= 0)
                {
                    if (isNameExist)
                    {
                        msg = "Category name already exist..";
                        return msg;
                    }
                }
                else
                {
                    var cat = _biCategoryRt.GetBiCategoryByIid(IID);
                    if (cat != null)
                    {
                        if (isNameExist && cat.Name != txtName.Text)
                        {
                            msg = "Category name already exist..";
                            return msg;
                        }
                    }

                }
                return msg;
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return string.Empty;
        }

        private string BusinessLogicValidationBiCategoryDetails(BICategoryDetail biCategoryDetail)
        {
            try
            {
                string msg = string.Empty;
                if (txtNameChild.Text.IsNullOrWhiteSpace())
                {
                    msg = "please enter name..";
                    return msg;
                }
                bool isNameExist = false;
                if (Session[sessBiCategoryChild] != null)
                {
                    List<BICategoryDetail> biCategoryDetailList = (List<BICategoryDetail>)Session[sessBiCategoryChild];
                    if (biCategoryDetailList.Any(x => x.Name == biCategoryDetail.Name))
                    {
                        isNameExist = true;
                    }
                }

                if (isNameExist)
                {
                    msg = "This name already exist in this category ..";
                    return msg;
                }
                return msg;
            }
            catch (Exception ex)
            {
                lblMessageChild.Text = "Error : " + ex.Message;
                lblMessageChild.ForeColor = System.Drawing.Color.Red;
            }
            return string.Empty;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("BICategoryDisplay");
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnCreateOrEditBiCategoryChild_OnClick(object sender, EventArgs e)
        {

            try
            {
                BICategoryDetail biCategoryDetail = CreateBiCategoryDetail();
                var msg = BusinessLogicValidationBiCategoryDetails(biCategoryDetail);
                if (msg.IsNullOrWhiteSpace())
                {
                    if (Session[sessBiCategoryChild] == null)
                    {
                        Session[sessBiCategoryChild] = new List<BICategoryDetail>();
                    }
                    List<BICategoryDetail> biCategoryDetailList = (List<BICategoryDetail>)Session[sessBiCategoryChild];
                    biCategoryDetailList.Add(biCategoryDetail);
                    Session[sessBiCategoryChild] = biCategoryDetailList;
                    ShowBiCategoryDetailData();
                    ClearDetailData();

                    lblMessageChild.Text = "Information has been inserted successfully.";
                    lblMessageChild.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMessageChild.Text = msg;
                    lblMessageChild.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMessageChild.Text = "Error : " + ex.Message;
                lblMessageChild.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ClearDetailData()
        {
            txtNameChild.Text = string.Empty;
            txtNoteChild.Text = string.Empty;
        }

        protected void btnCancelBiCategoryChild_Click(object sender, EventArgs e)
        {
            try
            {
                ClearDetailData();
            }
            catch (Exception ex)
            {
                lblMessageChild.Text = "Error : " + ex.Message;
                lblMessageChild.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void lnkbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                List<BICategoryDetail> biCategoryDetailList = (List<BICategoryDetail>)Session[sessBiCategoryChild];
                if (biCategoryDetailList.Count > 0)
                {
                    biCategoryDetailList.Remove(biCategoryDetailList.FirstOrDefault(x => x.Name == linkButton.CommandArgument));
                    Session[sessBiCategoryChild] = biCategoryDetailList;
                    ShowBiCategoryDetailData();

                    lblMessageChild.Text = "Information has been removed successfully.";
                    lblMessageChild.ForeColor = System.Drawing.Color.Green;

                }

            }
            catch (Exception ex)
            {
                lblMessageChild.Text = "Error : " + ex.Message;
                lblMessageChild.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}