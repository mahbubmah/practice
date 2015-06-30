using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;
using DAL;
using Microsoft.Ajax.Utilities;

namespace OMart.Web.AdminPanel
{
    public partial class BIBusinessAgeInsertUpdate : System.Web.UI.Page
    {
        private readonly BIAgeRT _biAgeRt;
        private long IID = default(Int64);
        public BIBusinessAgeInsertUpdate()
        {
            _biAgeRt=new BIAgeRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    var requestId = Request.QueryString["IID"];
                    bool reqIDIsValid = Int64.TryParse(requestId, out IID);
                    if (reqIDIsValid)
                    {
                        ShowBIAgeData();
                    }
                }
            }

            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ShowBIAgeData()
        {
            try
            {
                if (IID>0)
                {
                    var biAge = _biAgeRt.GetBiAgeIntervalByIid(IID);
                    if (biAge!=null)
                    {
                        txtAgeInterval.Text = biAge.AgeInterval;
                        if (!biAge.Note.IsNullOrWhiteSpace())
                        {
                            txtNote.Text = biAge.Note;
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

        private BIBusinessAge CreateBiAmountRange()
        {
            try
            {
                BIBusinessAge biAge = new BIBusinessAge();

                biAge.AgeInterval = txtAgeInterval.Text;
                if (!txtNote.Text.IsNullOrWhiteSpace())
                {
                    biAge.Note = txtNote.Text;
                }

                biAge.IsRemoved = false;
                return biAge;
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
                BIBusinessAge biAge = CreateBiAmountRange();
                string msg = BusinessLogicValidation(biAge);
                if (msg.IsNullOrWhiteSpace())
                {
                    if (IID <= 0)
                    {
                       
                        biAge.CreatedBy = Convert.ToInt64(Session["UserID"]);
                        biAge.CreatedDate = GlobalRT.GetServerDateTime();
                        _biAgeRt.AddBusinessAge(biAge);

                        labelMessage.Text = "Information has been added successfully.";
                        labelMessage.ForeColor = System.Drawing.Color.Green;

                    }
                    else
                    {
                        if (_biAgeRt.GetBiAgeIntervalByIid(IID) != null)
                        {
                            BIBusinessAge biAgeNew = CreateBiAmountRange();
                            BIBusinessAge biAgeOld = _biAgeRt.GetBiAgeIntervalByIid(IID);
                            biAgeNew.IID = biAgeOld.IID;
                            biAgeNew.CreatedBy = biAgeOld.CreatedBy;
                            biAgeNew.CreatedDate = biAgeOld.CreatedDate;
                            biAgeNew.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                            biAgeNew.ModifiedDate = GlobalRT.GetServerDateTime();
                            _biAgeRt.UpdateBusinessAge(biAgeNew);

                            labelMessage.Text = "Information has been updated successfully.";
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

        private string BusinessLogicValidation(BIBusinessAge biBusinessAge)
        {
            string msg = string.Empty;
            try
            {
             
                if (txtAgeInterval.Text.IsNullOrWhiteSpace())
                {
                    msg = "Please enter business age interval";
                    return msg;
                }
                var businessAgeList = _biAgeRt.GetAllBusinessAgeListForListView().ToList();
                if (IID<=0 )
                {
                    
                    if (businessAgeList.Any(businessAge => businessAge.AgeInterval.ToLower() == biBusinessAge.AgeInterval.ToLower()))
                    {
                        msg = "Age interval already exist";
                        return msg;
                    }
                }
                else if (IID > 0)
                {
                    var objBiAgeThis = businessAgeList.SingleOrDefault(x => x.IID == IID);
                    if (objBiAgeThis!=null)
                    {
                        if (businessAgeList.Any(businessAge => businessAge.AgeInterval.ToLower() == biBusinessAge.AgeInterval.ToLower() && businessAge.IID != objBiAgeThis.IID))
                        {
                            msg = "Age interval already exist";
                            return msg;
                        }
                    }
                    
                }
                
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            
            return msg;
        }

        private void ClearData()
        {
            txtNote.Text = string.Empty;
            txtAgeInterval.Text = string.Empty;
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("BIBusinessAgeDisplay");
        }
    }
}