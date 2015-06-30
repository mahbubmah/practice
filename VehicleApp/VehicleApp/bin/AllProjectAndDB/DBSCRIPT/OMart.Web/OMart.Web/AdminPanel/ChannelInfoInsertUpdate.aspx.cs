using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;
using BLL;
using DAL;
using Utilities;

namespace OMart.Web.AdminPanel
{
    public partial class ChannelInfoInsertUpdate : System.Web.UI.Page
    {
       private readonly ChannelInfoRT _BDChannelInfoRT;
        
        private int IID = default(int);

        public ChannelInfoInsertUpdate()
        {
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
                if (!IsPostBack)
                {
                    
                    
                    var requestId = Request.QueryString["IID"];
                    int reqID = Convert.ToInt32( requestId);
                    bool reqIDIsValid = Int32.TryParse(requestId, out IID);
                    if (reqID != 0 )
                    {
                        ShowBDChannelInfoData();
                    }
                }
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
                BDChannelInfo BDChannelInfo = CreateBDChannelInfo();
                ChannelInfoRT channelRT = new ChannelInfoRT();
                bool reqIDIsValid = Int32.TryParse(Request.QueryString["IID"], out IID);
                string msg = (string)BusinessLogicValidation(BDChannelInfo);
                BDChannelInfo bdch = new BDChannelInfo();
                bdch = channelRT.GetChannelInfoName(BDChannelInfo.Name);
                var requestId = Request.QueryString["IID"];
                int reqID = Convert.ToInt32(requestId);
                if (string.IsNullOrEmpty(msg))
                {
                    if (IID <= 0)
                    {
                        BDChannelInfo.CreatedBy = Convert.ToInt64(Session["UserID"]);
                        BDChannelInfo.CreatedDate = DateTime.Now;
                        BDChannelInfo.IsRemoved = chkIsRemoved.Checked;
                        ChannelInfoRT loanRT = new ChannelInfoRT();
                        loanRT.AddChannelInfo(BDChannelInfo);
                        ClearData();

                        labelMessage.Text = "Information has been inserted successfully.";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        ChannelInfoRT loanRT = new ChannelInfoRT();
                        BDChannelInfo objBDChannelInfo = loanRT.GetChannelInfoByIID(IID);

                        if (objBDChannelInfo != null)
                        {
                            BDChannelInfo.CreatedBy = objBDChannelInfo.CreatedBy; 
                            BDChannelInfo.CreatedDate = objBDChannelInfo.CreatedDate;
                            //BDChannelInfo.IsRemoved = objBDChannelInfo.IsRemoved;
                            BDChannelInfo.IID = objBDChannelInfo.IID;

                            BDChannelInfo.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                            BDChannelInfo.ModifiedDate = DateTime.Now;
                            
                            loanRT.UpdateChannelInfo(BDChannelInfo);
                            ClearData();

                            labelMessage.Text = "Information has been updated successfully.";
                            labelMessage.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            labelMessage.Text = "Information has not been updated successfully.";
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
            //LoanAmntYrScdle ob = new LoanAmntYrScdle();
            //ob.showBDChannelInfoGrid();
        }

        private string BusinessLogicValidation(BDChannelInfo BDChannelInfo)
        {
            string message = string.Empty;
            bool reqIDIsValid = Int32.TryParse(Request.QueryString["IID"], out IID);


            if (string.IsNullOrEmpty(BDChannelInfo.Name))
            {
                return message = "BDChannelInfo name is required.";
            }
            if (string.IsNullOrEmpty(BDChannelInfo.SerialNo.ToString()))
            {
                return message = "BDChannelInfo name is required.";
            }
            if (IID <= 0)
            {
                ChannelInfoRT _BDChannelInfoRT2 = new ChannelInfoRT();
                BDChannelInfo objBDChannelInfoName = _BDChannelInfoRT2.GetChannelInfoName(BDChannelInfo.Name);
                if (objBDChannelInfoName != null)
                {
                    if (objBDChannelInfoName.Name == BDChannelInfo.Name)
                    {
                        return message = "BDChannelInfo name already exists.";
                    }
                }

                BDChannelInfo objBDChannelInfoCode = _BDChannelInfoRT2.GetChannelInfoSerialNo(BDChannelInfo.SerialNo);
                                          
                if (objBDChannelInfoCode != null)
                {
                    if (objBDChannelInfoCode.SerialNo == BDChannelInfo.SerialNo && BDChannelInfo.SerialNo.ToString() != "")
                    {
                        return message = "BDChannelInfo Serial No already exists.";
                    }
                }

                


            }
            else
            {
                ChannelInfoRT _BDChannelInfoRT2 = new ChannelInfoRT();
                BDChannelInfo BDChannelInfoName = (from tr in _BDChannelInfoRT2.GetAllChannelInfo()
                                          where tr.Name == BDChannelInfo.Name && tr.IID != IID
                                          select tr).SingleOrDefault();
                 if (BDChannelInfoName != null)
                {
                    if (BDChannelInfoName.Name == BDChannelInfo.Name)
                    {
                        return message = "BDChannelInfo name already exists.";
                    }
                }

                 BDChannelInfo objBDChannelInfoCode = (from tr in _BDChannelInfoRT2.GetAllChannelInfo()
                                          where tr.SerialNo == BDChannelInfo.SerialNo && tr.IID != IID
                                          select tr).SingleOrDefault();
                if (objBDChannelInfoCode != null)
                {
                    if (objBDChannelInfoCode.SerialNo == BDChannelInfo.SerialNo)
                    {
                        return message = "BDChannelInfo code already exists.";
                    }
                }

                
            }

            return message;
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/AdminPanel/ChannelInfoView");
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ShowBDChannelInfoData()
        {
            try
            {
                ChannelInfoRT loanRt = new ChannelInfoRT();
                BDChannelInfo objBDChannelInfo = loanRt.GetChannelInfoByIID(IID);
                if (objBDChannelInfo != null)
                {
                    
                    txtSerialNo.Text = objBDChannelInfo.SerialNo.ToString();
                    txtName.Text = objBDChannelInfo.Name.ToString();
                    txtNote.Text = objBDChannelInfo.Note.ToString();
                    txtContractPhone.Text = objBDChannelInfo.ContactPhone.ToString();
                    txtAddress.Text = objBDChannelInfo.Address.ToString();
                    txtWebAddress.Text = objBDChannelInfo.WebAddress.ToString();
                    chkIsRemoved.Checked = objBDChannelInfo.IsRemoved;


                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        //private string BusinessLogicValidation(BDChannelInfo BDChannelInfo)
        //{
        //    string message = string.Empty;
        //    bool reqIDIsValid = Int32.TryParse(Request.QueryString["IID"], out IID);

        //    if (IID <= 0)
        //    {
        //        BDChannelInfo objBDChannelInfoName = (from tr in _ChannelInfoRT.GetAllLoanAmntYrScdle()
        //                                              where tr.CompanyInfoID == BDChannelInfo.CompanyInfoID
        //                                              select tr).SingleOrDefault();
        //        if (BDChannelInfo != null)
        //        {
        //            if (objBDChannelInfoName.CompanyInfoID == BDChannelInfo.CompanyInfoID)
        //            {
        //                message = "BDChannelInfo name already exists.";
        //            }
        //        }

        //    }

        //    return message;
        //}

        private BDChannelInfo CreateBDChannelInfo()
        {
            Session["UserID"] = "1";
            BDChannelInfo objBDChannelInfo = new BDChannelInfo();
            try
            {
                objBDChannelInfo.SerialNo = Convert.ToInt32( txtSerialNo.Text) ;
                objBDChannelInfo.Name = txtName.Text.Trim();
                objBDChannelInfo.Note = txtNote.Text.Trim() ;
                objBDChannelInfo.ContactPhone =txtContractPhone.Text.Trim();
                objBDChannelInfo.Address = txtAddress.Text.Trim();
                objBDChannelInfo.WebAddress = txtWebAddress.Text.Trim();
                
                objBDChannelInfo.IsRemoved = chkIsRemoved.Checked  ;
                
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return objBDChannelInfo;
        }

        private void ClearData()
        {
            
            txtSerialNo.Text = string.Empty;
            txtName.Text = string.Empty;
            txtNote.Text = string.Empty;
            txtContractPhone.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtWebAddress.Text = string.Empty;
            
            chkIsRemoved.Checked = false;
            
        }

    }
}