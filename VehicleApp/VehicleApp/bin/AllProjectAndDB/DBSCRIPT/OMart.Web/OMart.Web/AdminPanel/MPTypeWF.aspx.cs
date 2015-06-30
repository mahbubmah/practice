using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL.Basic;
using Utilities;

namespace OMart.Web.AdminPanel
{
    public partial class MPTypeWF : System.Web.UI.Page
    {
        private readonly MPTypeRT _MPTypeRT;
        private int IID = default(int);

        public MPTypeWF()
        {
            this._MPTypeRT = new MPTypeRT();
        }

        private void LoadDropDownCompanyInfo(int? companyID)
        {
            try
            {
                using (CompanyInfoRT receverTransfer = new CompanyInfoRT())
                {
                    List<CompanyInfo> companyInfoList = new List<CompanyInfo>();
                    if (companyID != null)
                    {
                        companyInfoList.Add(receverTransfer.GetCompanyInfoByIID((int)companyID));
                    }
                    else
                    {
                        companyInfoList = receverTransfer.GetAllMobileCompanyInfos();
                    }
                    DropDownListHelper.Bind<CompanyInfo>(dropDownCompanyInfoID, companyInfoList, "Name", "IID", EnumCollection.ListItemType.Company);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        private void ShowMobileData()
        {
            try
            {
                MPType  objMobile = _MPTypeRT.GetMobileByIID(IID);
                if (objMobile != null)
                {
                    txtTypeName.Text = objMobile.TypeName;
                    dropDownCompanyInfoID.SelectedValue = objMobile.CompanyInfoID.ToString();
                   
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private MPType CreateMPType()
        {
           MPType mobile = new MPType();
            try
            {
                mobile.TypeName = txtTypeName.Text.Trim();
                mobile.CompanyInfoID = Convert.ToInt32(dropDownCompanyInfoID.SelectedValue);
                mobile.IsRemoved = false;
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return mobile;
        }

        private string BusinessLogicValidation(MPType mobile)
        {
            string message = string.Empty;
            bool reqIDIsValid = Int32.TryParse(Request.QueryString["IID"], out IID);

            if (IID <= 0)
            {
               MPType objTypeName = (from tr in _MPTypeRT.GetAllMobiles()
                                     where tr.TypeName.ToLower() == mobile.TypeName.ToLower() 
                                          select tr).SingleOrDefault();
                if (objTypeName != null)
                {
                    if ( objTypeName.TypeName.ToLower() == mobile.TypeName.ToLower())
                    {
                        message = "Mobile name already exists.";
                    }
                }

               }
            else
            {
                MPType objTypeName = (from tr in _MPTypeRT.GetAllMobiles()
                                      where tr.TypeName.ToLower() == mobile.TypeName.ToLower()  && tr.IID != IID
                                          select tr).SingleOrDefault();
                if (objTypeName != null)
                {
                    if (objTypeName.TypeName.ToLower() == mobile.TypeName.ToLower())
                    {
                        message = "Mobile name already exists.";
                    }
                }
        
            }

            return message;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    var requestId = Request.QueryString["IID"];
                    bool reqIDIsValid = Int32.TryParse(requestId, out IID);
                    LoadDropDownCompanyInfo(null);
                    if (reqIDIsValid)
                    {
                        ShowMobileData();
                    }
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
            txtTypeName.Text = string.Empty;
            dropDownCompanyInfoID.SelectedValue = "-1";
          
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("MPTypeDisplay");
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btn_CreateOrEdit_Click(object sender, EventArgs e)
        {
            try
            {
                MPType mobile = CreateMPType();
                bool reqIDIsValid = Int32.TryParse(Request.QueryString["IID"], out IID);
                var msg = BusinessLogicValidation(mobile);

                if (string.IsNullOrEmpty(msg))
                {
                    if (IID <= 0)
                    {
                        mobile.CreatedBy = Convert.ToInt64(Session["UserID"]);
                        mobile.CreatedDate = DateTime.Now;
                        

                        _MPTypeRT.AddMobile(mobile);
                        ClearData();

                        labelMessage.Text = "Information has been inserted successfully.";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                       MPType objmobile = _MPTypeRT.GetMobileByIID(IID);

                        if (objmobile != null)
                        {
                            mobile.CreatedBy = objmobile.CreatedBy; ;
                            mobile.CreatedDate = objmobile.CreatedDate;
                            mobile.IsRemoved = objmobile.IsRemoved;
                            mobile.IID = objmobile.IID;

                            mobile.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                            mobile.ModifiedDate = DateTime.Now;

                            _MPTypeRT.UpdateMobilePhone(mobile);
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
    }
}