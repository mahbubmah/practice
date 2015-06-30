using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OH.BLL.Basic;
using OH.DAL;
using OH.Utilities;

namespace OH.Web.ControlAdmin
{
    public partial class PostOfficeWF : System.Web.UI.Page
    {
        private const string sessPostOffice = "sePostOffice";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    LoadPostOfficeListView();
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnCancel.Visible = false;
                    chkPoliceStationActv.Enabled = false;
                    chkPoliceStationActv.Visible = false;
                }
                catch (Exception ex)
                {
                    labelMessagePostOffice.Text = "Error : " + ex.Message;
                    labelMessagePostOffice.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void LoadPostOfficeListView()
        {
            try
            {
                using (PostOfficeRT receiverTransfer = new PostOfficeRT())
                {
                    lvPostOffice.DataSource = receiverTransfer.GetPostOfficeAllForListView(); ;
                    lvPostOffice.DataBind();
                }
            }
            catch (Exception ex)
            {
                labelMessagePostOffice.Text = "Error : " + ex.Message;
                labelMessagePostOffice.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessagePostOffice.Text = string.Empty;
                int PoliceStationID = int.Parse(txtPoliceStationID.Text);
                using (PostOfficeRT receiverTransfer = new PostOfficeRT())
                {
                    if (receiverTransfer.IsPostOfficeCodeExists(txtPostOfficeCode.Text, PoliceStationID) && receiverTransfer.IsPostOfficeNameExists(txtPostOfficeName.Text, PoliceStationID))
                    {
                        labelMessagePostOffice.Text = "Post Office Code " + txtPostOfficeCode.Text + "& Name " + txtPostOfficeName.Text + " Already Exists!";
                        labelMessagePostOffice.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    else if (receiverTransfer.IsPostOfficeCodeExists(txtPostOfficeCode.Text))
                    {
                        labelMessagePostOffice.Text = "Post Office Code " + txtPostOfficeCode.Text + " Already Exists!";
                        labelMessagePostOffice.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    else if (receiverTransfer.IsPostOfficeCodeExists(txtPostOfficeCode.Text, PoliceStationID))
                    {
                        labelMessagePostOffice.Text = "Post Office Code " + txtPostOfficeCode.Text + " Already Exists!";
                        labelMessagePostOffice.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    else if (receiverTransfer.IsPostOfficeNameExists(txtPostOfficeName.Text, PoliceStationID))
                    {
                        labelMessagePostOffice.Text = "Post Office Name " + txtPostOfficeName.Text + " Already Exists!";
                        labelMessagePostOffice.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    hdSave.Value = "true";
                    PostOffice postOffice = CreatePostOffice();
                    receiverTransfer.AddPostOffice(postOffice);
                    if (postOffice.IID > 0)
                    {
                        labelMessagePostOffice.Text = "Data successfully saved...";
                        labelMessagePostOffice.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        labelMessagePostOffice.Text = "Data not saved...";
                        labelMessagePostOffice.ForeColor = System.Drawing.Color.Red;
                    }
                }

                ClearField();
                LoadPostOfficeListView();
                SetButton();
                // hdSave.Value = string.Empty;
            }
            catch (Exception ex)
            {
                labelMessagePostOffice.Text = "Error : " + ex.Message;
                labelMessagePostOffice.ForeColor = System.Drawing.Color.Red;
            }
        }

        private PostOffice CreatePostOffice()
        {
            Session["UserID"] = "1";
            PostOffice pOffice = new PostOffice();
            try
            {
                if (hdIsEdit.Value == "true")
                {
                    pOffice.IID = Convert.ToInt32(hdPostOfficeID.Value.ToString());
                }
                pOffice.Name = txtPostOfficeName.Text.Trim();
                pOffice.Code = txtPostOfficeCode.Text.Trim();
                //pStaion.CountryID = int.Parse(ddlCountry.SelectedValue);
                pOffice.CountryID = int.Parse(txtCountryID.Text);
                //pStaion.DivisionOrStateID = int.Parse(ddlDivisionOrState.SelectedValue);
                pOffice.DivisionOrStateID = int.Parse(txtDivOrStateID.Text);
                pOffice.DistrictID = int.Parse(txtDistrictID.Text);
                pOffice.PoliceStationID = int.Parse(txtPoliceStationID.Text);
                pOffice.IsRemoved = chkPoliceStationActv.Checked;
                if (pOffice.IID <= 0)
                {
                    pOffice.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    pOffice.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    PostOffice postOffice = (PostOffice)Session[sessPostOffice];
                    pOffice.CreatedBy = postOffice.CreatedBy; ;
                    pOffice.CreatedDate = postOffice.CreatedDate;
                    pOffice.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    pOffice.ModifiedDate = GlobalRT.GetServerDateTime();
                }
                //if ((hdIsEdit.Value != "true" && chkPoliceStationActv.Checked!=true)||(hdSave.Value=="true" &&chkPoliceStationActv.Checked!=true))
                //{
                //    pOffice.IsRemoved = false;
                //}
                //else if (hdSave.Value == "true" && chkPoliceStationActv.Checked == true)
                //{
                //    pOffice.IsRemoved = true;
                //}
               
                //hdSave.Value = false;
            }
            catch (Exception ex)
            {
                labelMessagePostOffice.Text = "Error : " + ex.Message;
                labelMessagePostOffice.ForeColor = System.Drawing.Color.Red;
            }
            return pOffice;
          
        }

        private void ClearField()
        {
            txtPostOfficeCode.Text = string.Empty;
            txtPostOfficeName.Text = string.Empty;
            txtCountryName.Text = string.Empty;
            txtDivOrStateName.Text = string.Empty;
            txtDistrictName.Text = string.Empty;
            txtPoliceStation.Text = string.Empty;
            chkPoliceStationActv.Checked = false;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessagePostOffice.Text = string.Empty;
                using (PostOfficeRT receiverTransfer = new PostOfficeRT())
                {
                    hdIsEdit.Value = "true";
                    hdIsDelete.Value = "false";
                    PostOffice postOffice = CreatePostOffice();

                    if (postOffice != null)
                    {

                        //Exit If Both Post Office Code & Name exist in Other rows
                        if ((receiverTransfer.IsPostOfficeCodeExistInOtherRows(postOffice.IID, postOffice.Code, postOffice.DistrictID)) && (receiverTransfer.IsPostOfficeNameExistInOtherRows(postOffice.IID, postOffice.Code, postOffice.DistrictID)))
                        {
                            labelMessagePostOffice.Text = "Post Office Code " + txtPostOfficeCode.Text + "& Name " + txtPostOfficeName.Text + " Already Exists!";
                            labelMessagePostOffice.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                        //Exit if Duplicate Police Station Code
                        else if (receiverTransfer.IsPostOfficeCodeExistsInOtherRows(postOffice.IID, postOffice.Code))
                        {
                            labelMessagePostOffice.Text = "Post Office Code " + txtPostOfficeCode.Text + " Already Exists!";
                            labelMessagePostOffice.ForeColor = System.Drawing.Color.Red;
                            return;
                        }

                        //Exit If Both Police Staion Code exist in Other rows
                        else if (receiverTransfer.IsPostOfficeCodeExistInOtherRows(postOffice.IID, postOffice.Code, postOffice.DistrictID))
                        {
                            labelMessagePostOffice.Text = "Post Office Code " + txtPostOfficeCode.Text + " Already Exists!";
                            labelMessagePostOffice.ForeColor = System.Drawing.Color.Red;
                            return;
                        }

                        //Exit If Both Police Staion Name exist in Other rows
                        else if (receiverTransfer.IsPostOfficeNameExistInOtherRows(postOffice.IID, postOffice.Name, postOffice.DistrictID))
                        {
                            labelMessagePostOffice.Text = "Post Office Name " + txtPostOfficeName.Text + " Already Exists!";
                            labelMessagePostOffice.ForeColor = System.Drawing.Color.Red;
                            return;
                        }

                        receiverTransfer.UpdatePostOffice(postOffice);
                        labelMessagePostOffice.Text = "Data successfully updated...";
                        labelMessagePostOffice.ForeColor = System.Drawing.Color.Green;
                        //hdIsEdit.Value = "";

                    }
                    else
                    {
                        labelMessagePostOffice.Text = "Data not updated...";
                        labelMessagePostOffice.ForeColor = System.Drawing.Color.Red;
                    }
                }
                ClearField();
              //  hdIsEdit.Value = string.Empty;
                SetButton();
                LoadPostOfficeListView();
            }
            catch (Exception ex)
            {
                labelMessagePostOffice.Text = "Error : " + ex.Message;
                labelMessagePostOffice.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvPostOffice_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditPostOffice")
            {
                try
                {
                    labelMessagePostOffice.Text = string.Empty;
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = false;
                    btnCancel.Visible = true;
                    chkPoliceStationActv.Visible = true;
                    int PostoffcID = Convert.ToInt32(e.CommandArgument);
                    hdPostOfficeID.Value = PostoffcID.ToString();
                    using (PostOfficeRT receiverTransfer = new PostOfficeRT())
                    {
                        PostOffice postOffice = receiverTransfer.GetPostOfficeByID(PostoffcID);
                        FillPostOfficeForEdit(postOffice);
                    }
                }
                catch (Exception ex)
                {
                    labelMessagePostOffice.Text = "Error : " + ex.Message;
                    labelMessagePostOffice.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void FillPostOfficeForEdit(PostOffice postOffice)
        {
            try
            {
                chkPoliceStationActv.Enabled = true;
                if (postOffice != null)
                {
                    txtPostOfficeName.Text = postOffice.Name;
                    txtPostOfficeCode.Text = postOffice.Code.ToString();
                    
                    txtCountryName.Text = new CountryRT().GetCountryByIID(postOffice.CountryID).Name;
                    txtCountryID.Text = postOffice.CountryID.ToString();
                    
                    txtDivOrStateName.Text = new DivisionOrStateRT().GetDivisionOrStateByID(postOffice.DivisionOrStateID).Name;
                    txtDivOrStateID.Text = postOffice.DivisionOrStateID.ToString();
                   
                    txtDistrictName.Text = new DistrictRT().GetDistrictByID(postOffice.DistrictID).Name;
                    txtDistrictID.Text = postOffice.DistrictID.ToString();

                    txtPoliceStation.Text = new PoliceStationRT().GetPoliceStationByID(postOffice.PoliceStationID).Name;
                    txtPoliceStationID.Text = postOffice.PoliceStationID.ToString();
                    if (postOffice.IsRemoved == true)
                    {

                        chkPoliceStationActv.Checked = true;

                    }
                    else
                    {
                        chkPoliceStationActv.Checked = false;
                    }
                    Session[sessPostOffice] = postOffice;
                }
            }
            catch (Exception ex)
            {
                labelMessagePostOffice.Text = "Error : " + ex.Message;
                labelMessagePostOffice.ForeColor = System.Drawing.Color.Red;
            }
        }
        int lvRowCount = 0;
        int currentPage = 0;
        protected void lvPostOffice_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void dataPagerPostOffice_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadPostOfficeListView();
                }
            }
            catch (Exception ex)
            {
                labelMessagePostOffice.Text = "Error : " + ex.Message;
                labelMessagePostOffice.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    labelMessagePostOffice.Text = string.Empty;
            //    using (PostOfficeRT receiverTransfer = new PostOfficeRT())
            //    {
            //        hdIsDelete.Value = "true";
            //        hdIsEdit.Value = "true";
            //        PostOffice postOffice = CreatePostOffice();

            //        if (postOffice != null)
            //        {
            //            receiverTransfer.UpdatePostOffice(postOffice);
            //            labelMessagePostOffice.Text = "Data successfully deleted...";
            //            labelMessagePostOffice.ForeColor = System.Drawing.Color.Green;
            //        }
            //        else
            //        {
            //            labelMessagePostOffice.Text = "Data not deleted...";
            //            labelMessagePostOffice.ForeColor = System.Drawing.Color.Red;
            //        }
            //    }
            //    LoadPostOfficeListView();
            //    //DohideButton();
            //    btnSave.Visible = true;
            //    ClearField();
            //}
            //catch (Exception ex)
            //{
            //    labelMessagePostOffice.Text = "Error : " + ex.Message;
            //    labelMessagePostOffice.ForeColor = System.Drawing.Color.Red;
            //}

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            labelMessagePostOffice.Text = string.Empty;
            SetButton();
            ClearField();
        }
        private void SetButton()
        {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnCancel.Visible = false;
            chkPoliceStationActv.Enabled = false;
            chkPoliceStationActv.Visible = false;
        }
    }
}