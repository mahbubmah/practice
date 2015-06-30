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
    public partial class ProfessionInsertUpdate : System.Web.UI.Page
    {
        private readonly ProfessionRT _ProfessionRT;
        
        private int IID = default(int);

        public ProfessionInsertUpdate()
        {
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
                if (!IsPostBack)
                {
                    LoadDropDownPremiumPolicyID(null);
                    var requestId = Request.QueryString["IID"];
                    int reqID = Convert.ToInt32( requestId);
                    bool reqIDIsValid = Int32.TryParse(requestId, out IID);
                    if (reqID != 0 )
                    {
                        ShowProfessionData();
                    }
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void LoadDropDownPremiumPolicyID(int? LoanAmntYrScdleOb)
        {
            try
            {

                
                {
                    DropDownType.Items.Add(new ListItem("Select Type ", "-1"));
                    foreach (Utilities.EnumCollection.type r in Enum.GetValues(typeof(Utilities.EnumCollection.type)))
                    {
                        ListItem item = new ListItem(Enum.GetName(typeof(Utilities.EnumCollection.type), r), r.ToString());
                        DropDownType.Items.Add(item);
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        protected void btn_CreateOrEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Profession lis = new Profession();
                ProfessionRT LisRT = new ProfessionRT();
               
                Profession Profession = CreateProfession();
               
                bool reqIDIsValid = Int32.TryParse(Request.QueryString["IID"], out IID);
                 // (string)BusinessLogicValidation(Profession);
                
               
                    if (IID <= 0)
                    {
                        Profession.CreatedBy = Convert.ToInt64(Session["UserID"]);
                        Profession.CreatedDate = DateTime.Now;
                        Profession.IsRemoved = chkIsRemoved.Checked;
                        ProfessionRT loanRT = new ProfessionRT();
                        loanRT.AddProfession(Profession);
                        ClearData();

                        labelMessage.Text = "Information has been inserted successfully.";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        ProfessionRT loanRT = new ProfessionRT();
                        Profession objProfession = loanRT.GetAddProfessionsByIID(IID);

                        if (objProfession != null)
                        {
                            Profession.CreatedBy = objProfession.CreatedBy; 
                            Profession.CreatedDate = objProfession.CreatedDate;
                            //Profession.IsRemoved = objProfession.IsRemoved;
                            Profession.IID = objProfession.IID;

                            Profession.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                            Profession.ModifiedDate = DateTime.Now;
                            
                            loanRT.UpdateProfessions(Profession);
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
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            //LoanAmntYrScdle ob = new LoanAmntYrScdle();
            //ob.showProfessionGrid();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/AdminPanel/ProfessionView");
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ShowProfessionData()
        {
            try
            {
                ProfessionRT loanRt = new ProfessionRT();
                Profession objProfession = loanRt.GetAddProfessionsByIID(IID);
                if (objProfession != null)
                {
                    txtNote.Text = objProfession.Note ;
                    txtName.Text = objProfession.Name ;

                    DropDownType.SelectedValue =  Enum.GetName(typeof(Utilities.EnumCollection.type), objProfession.Type);
                    chkIsRemoved.Checked = objProfession.IsRemoved;

                   


                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        //private string BusinessLogicValidation(Profession Profession)
        //{
        //    string message = string.Empty;
        //    bool reqIDIsValid = Int32.TryParse(Request.QueryString["IID"], out IID);

        //    if (IID <= 0)
        //    {
        //        Profession objProfessionName = (from tr in _ProfessionRT.GetAllLoanAmntYrScdle()
        //                                              where tr.CompanyInfoID == Profession.CompanyInfoID
        //                                              select tr).SingleOrDefault();
        //        if (Profession != null)
        //        {
        //            if (objProfessionName.CompanyInfoID == Profession.CompanyInfoID)
        //            {
        //                message = "Profession name already exists.";
        //            }
        //        }

        //    }

        //    return message;
        //}

        private Profession CreateProfession()
        {
            Session["UserID"] = "1";
            Profession objProfession = new Profession();
            try
            {
                
                objProfession.Note = txtNote.Text ;
                objProfession.Name = txtName.Text ;
                
                objProfession.Type = (Int32)Enum.Parse(typeof(Utilities.EnumCollection.type), DropDownType.SelectedValue.ToString());
                objProfession.IsRemoved = chkIsRemoved.Checked ;
                
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return objProfession;
        }

        private void ClearData()
        {
            txtNote.Text = string.Empty;
            txtName.Text = string.Empty;

           
            DropDownType.SelectedIndex = -1 ;
        }

    }
}