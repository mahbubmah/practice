using System;
using System.Collections.Generic;
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
    public partial class BIAmountRangeInsertUpdate : System.Web.UI.Page
    {
        private readonly BIAmountRangeRT _amountRangeRt;
        private long IID = default(Int64);
        public BIAmountRangeInsertUpdate()
        {
            _amountRangeRt = new BIAmountRangeRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadDropDownForBusinessAmountType();
                    var requestId = Request.QueryString["IID"];
                    bool reqIDIsValid = Int64.TryParse(requestId, out IID);
                    if (reqIDIsValid)
                    {
                        ShowBIAmountRangeData();
                    }
                }
            }

            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void LoadDropDownForBusinessAmountType()
        {
            try
            {
                ddlType.Items.Clear();
                ddlType.Items.Add(new ListItem("--Select--", "-1"));
                DropDownListHelper.Bind(ddlType, EnumHelper.EnumCamelSpaceToList<EnumCollection.BIAmountType>());
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }

        }

        private void ShowBIAmountRangeData()
        {
            try
            {
                if (IID > 0)
                {
                    var biAmountRange = _amountRangeRt.GetBiAbmountRangeByIid(IID);
                    if (biAmountRange != null)
                    {
                        txtEndAmount.Text = biAmountRange.AmountEnd.ToString("0.##");
                        ddlType.SelectedValue = biAmountRange.TypeID.ToString();
                        if (biAmountRange.AmountStart != null)
                        {
                            txtStartAmount.Text = biAmountRange.AmountStart.ToString();
                        }
                        if (!biAmountRange.Note.IsNullOrWhiteSpace())
                        {
                            txtNote.Text = biAmountRange.Note;
                        }

                    }
                    else
                    {
                        labelMessage.Text = "Information is not found";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }

            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private string BusinessLogicValidation()
        {
            string msg = string.Empty;
            if (txtEndAmount.Text.IsNullOrWhiteSpace())
            {
                msg = "Please enter maximum amount..";
                return msg;
            }
            if (ddlType.SelectedValue.IsNullOrWhiteSpace() || ddlType.SelectedValue == "-1")
            {
                msg = "please select amount type..";
                return msg;
            }
            return msg;

        }

        private BIAmountRange CreateBiAmountRange()
        {
            try
            {
                BIAmountRange biAmountRange = new BIAmountRange();

                biAmountRange.AmountEnd = Convert.ToDecimal(txtEndAmount.Text);
                biAmountRange.TypeID = Convert.ToInt32(ddlType.SelectedValue);
                if (!txtStartAmount.Text.IsNullOrWhiteSpace())
                {
                    biAmountRange.AmountStart = Convert.ToDecimal(txtStartAmount.Text);
                    biAmountRange.AmountDetail = txtStartAmount.Text + " to " + txtEndAmount.Text;
                }
                else
                {
                    biAmountRange.AmountDetail = "Upto " + txtEndAmount.Text;
                }
                if (!txtNote.Text.IsNullOrWhiteSpace())
                {
                    biAmountRange.Note = txtNote.Text;
                }

                biAmountRange.IsRemoved = false;
                return biAmountRange;
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return null;
        }

        protected void btnCreateOrEdit_OnClick(object sender, EventArgs e)
        {
            try
            {
                var requestId = Request.QueryString["IID"];
                bool reqIDIsValid = Int64.TryParse(requestId, out IID);
                string msg = BusinessLogicValidation();
                if (msg.IsNullOrWhiteSpace())
                {
                    if (IID <= 0)
                    {
                        BIAmountRange biAmountRange = CreateBiAmountRange();
                        biAmountRange.CreatedBy = Convert.ToInt64(Session["UserID"]);
                        biAmountRange.CreatedDate = GlobalRT.GetServerDateTime();
                        _amountRangeRt.AddAmountRange(biAmountRange);
                        labelMessage.Text = "Information saved Successfully";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        if (_amountRangeRt.GetBiAbmountRangeByIid(IID) != null)
                        {
                            BIAmountRange biAmountRangeNew = CreateBiAmountRange();
                            BIAmountRange biAmountRangeOld = _amountRangeRt.GetBiAbmountRangeByIid(IID);
                            biAmountRangeNew.IID = biAmountRangeOld.IID; 
                            biAmountRangeNew.CreatedBy = biAmountRangeOld.CreatedBy;
                            biAmountRangeNew.CreatedDate = biAmountRangeOld.CreatedDate;
                            biAmountRangeNew.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                            biAmountRangeNew.ModifiedDate = GlobalRT.GetServerDateTime();
                            _amountRangeRt.UpdateAmountRange(biAmountRangeNew);
                            labelMessage.Text = "Inforamtion updated Successfully";
                            labelMessage.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            labelMessage.Text = "Update failed. Information not found";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    ClearData();
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
            txtEndAmount.Text = string.Empty;
            txtNote.Text = string.Empty;
            txtStartAmount.Text = string.Empty;
            ddlType.SelectedValue = "-1";
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("BIAmountRangeDisplay");
        }
    }
}