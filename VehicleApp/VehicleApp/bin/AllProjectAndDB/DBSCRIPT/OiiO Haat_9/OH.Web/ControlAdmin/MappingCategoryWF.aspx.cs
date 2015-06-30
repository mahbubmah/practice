using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using OH.BLL.Basic;
using OH.DAL;
using System.Web.UI.HtmlControls;


namespace OH.Web.ControlAdmin
{
    public partial class MappingCategoryWF : System.Web.UI.Page
    {
  
       private const string sessMappingCategory = "seMappingCategory";
       static string sLastCategory = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    LoadMappingCategory();
                  
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnCancel.Visible = false;
                    LoadMappingCategoryList();
                }
                catch (Exception ex)
                {
                    labelMessage.Text = "Error : " + ex.Message;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        #region private Methods

       
        private void LoadMappingCategory()
        {
            try
            {
                using (MappingCategoryRT receiverTransfer = new MappingCategoryRT())
                {
                    lvMappingCategory.DataSource = receiverTransfer.GetAllMappingTableForListView(); ;
                    lvMappingCategory.DataBind();                   
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void LoadMappingCategoryList()
        {
            try
            {
                using (MappingCategoryRT receiverTransfer = new MappingCategoryRT())
                {
                    lvMapCategoryList.DataSource = receiverTransfer.GetAllMappingCategoryTableForListView(); ;
                    lvMapCategoryList.DataBind();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        ////
        private MappingCategory CreateMappingCategory(Int32 CatID,Int32 MapID)
        {
            Session["UserID"] = "1";
            MappingCategory mappingCategory = new MappingCategory();
            try
            {
                if (hdIsEdit.Value == "true")
                {
                    mappingCategory.IID = Convert.ToInt32(hdMappingCategoryID.Value.ToString());
                }
                         mappingCategory.CategoryID = CatID;
                         mappingCategory.MappingTableID = MapID;
                        if (mappingCategory.IID <= 0)
                        {
                            mappingCategory.CreatedBy = Convert.ToInt64(Session["UserID"]);
                            mappingCategory.CreatedDate = GlobalRT.GetServerDateTime();
                        }
                        else
                        {
                           
                            MappingCategory mapping = (MappingCategory)Session[sessMappingCategory];
                            mappingCategory.CreatedBy = mapping.CreatedBy;
                            mappingCategory.CreatedDate = mapping.CreatedDate;
                            mappingCategory.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                            mappingCategory.ModifiedDate = GlobalRT.GetServerDateTime();
                        }
                if (hdIsDelete.Value != "true")
                {
                    mappingCategory.IsRemoved = false;
                }
                else
                {
                    mappingCategory.IsRemoved = true;
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return mappingCategory;
        }

        private void FillMappingCategoryForEdit(MappingCategory mappingCategory)
        {
            try
            {
                MappingCategoryRT receiverTransfer = new MappingCategoryRT();
                if (mappingCategory != null)
                {
                    txtParentID.Text = Convert.ToString(mappingCategory.CategoryID);
                    string catName=receiverTransfer.GetMappingCategoryByName(Convert.ToInt32(mappingCategory.CategoryID));
                    txtCategoryID.Text = Convert.ToString(catName);

                  List<MappingCategory> mappingCategoryList = new List<MappingCategory>();
                  mappingCategoryList = receiverTransfer.GetMappingCategoryByTableID(Convert.ToInt32(mappingCategory.CategoryID));
                  if (mappingCategoryList != null && mappingCategoryList.Count > 0)
                    {
                        foreach (MappingCategory mappCategory in mappingCategoryList)
                        {
                            for (int rowCounter = 0; rowCounter < lvMappingCategory.Items.Count(); rowCounter++)
                            {
                                CheckBox checkBox = (CheckBox)lvMappingCategory.Items[rowCounter].FindControl("chkModel");
                                Label lblMappingTableIID = (Label)lvMappingCategory.Items[rowCounter].FindControl("lblMappingTableIID");

                                if (Convert.ToInt32(lblMappingTableIID.Text) == mappCategory.MappingTableID)
                                {
                                    checkBox.Checked = true;
                                }
                            }
                        }
                       
                    }
                

                    Session[sessMappingCategory] = mappingCategory;
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ClearField()
        {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnCancel.Visible = false;
            txtCategoryID.Text = string.Empty;
            for (int rowCounter = 0; rowCounter < lvMappingCategory.Items.Count(); rowCounter++)
            {
                CheckBox checkBox = (CheckBox)lvMappingCategory.Items[rowCounter].FindControl("chkModel");
                Label lblMappingTableIID = (Label)lvMappingCategory.Items[rowCounter].FindControl("lblMappingTableIID");
                checkBox.Checked = false;
            }
        }

        #endregion private Methods



        #region protected Events
        
        protected void chkModelAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox chkAll = (CheckBox)sender;             
                if (chkAll.Checked)
                {
                    for (int rowCounter = 0; rowCounter < lvMappingCategory.Items.Count(); rowCounter++)
                    {
                        CheckBox checkBox = (CheckBox)lvMappingCategory.Items[rowCounter].FindControl("chkModel");
                        checkBox.Checked = true;
                    }
                }
                else
                {
                    for (int rowCounter = 0; rowCounter < lvMappingCategory.Items.Count(); rowCounter++)
                    {
                        CheckBox checkBox = (CheckBox)lvMappingCategory.Items[rowCounter].FindControl("chkModel");
                        checkBox.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
            }
        }
          
        
       protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                MappingCategory mappingCategory = new MappingCategory();
                using ( MappingCategoryRT receiverTransfer = new MappingCategoryRT())
                {
                 List<MappingCategory> mappingCategoryList = new List<MappingCategory>();
                 for (int rowCounter = 0; rowCounter < lvMappingCategory.Items.Count(); rowCounter++)
                  {
                   CheckBox checkBox = (CheckBox)lvMappingCategory.Items[rowCounter].FindControl("chkModel");
                    Label lblMappingTableIID = (Label)lvMappingCategory.Items[rowCounter].FindControl("lblMappingTableIID");
                 
                    if (checkBox.Checked)
                    {                       
                        mappingCategory = CreateMappingCategory(Convert.ToInt32(txtParentID.Text), Convert.ToInt32(lblMappingTableIID.Text));
                        receiverTransfer.AddMappingCategory(mappingCategory);
                    }                                       
                  }                   
                    if (mappingCategory.IID > 0)
                    {
                        labelMessage.Text = "Data successfully saved...";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        labelMessage.Text = "Data not saved...";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }

                ClearField();
                LoadMappingCategoryList();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                hdIsEdit.Value = "true";
                using (MappingCategoryRT receiverTransfer = new MappingCategoryRT())
                {
                    List<MappingCategory> mappingCategoryList = new List<MappingCategory>();
                    MappingCategory mappingCategory =new MappingCategory();
                    if (!string.IsNullOrEmpty(txtParentID.Text))
                    {
                        mappingCategoryList = receiverTransfer.GetMappingCategoryByTableID(Convert.ToInt32(txtParentID.Text));
                        if (mappingCategoryList != null && mappingCategoryList.Count > 0)
                        {
                            foreach (MappingCategory mappCategory in mappingCategoryList)
                            {
                                mappCategory.IsRemoved = true;
                                receiverTransfer.UpdateMappingCategory(mappCategory);

                            }
                        } 

                              for (int rowCounter = 0; rowCounter < lvMappingCategory.Items.Count(); rowCounter++)
                                {
                                    CheckBox checkBox = (CheckBox)lvMappingCategory.Items[rowCounter].FindControl("chkModel");
                                    Label lblMappingTableIID = (Label)lvMappingCategory.Items[rowCounter].FindControl("lblMappingTableIID");
                                   
                                    if (checkBox.Checked)
                                    {                                  
                                                                             
                                        mappingCategory = CreateMappingCategory(Convert.ToInt32(txtParentID.Text), Convert.ToInt32(lblMappingTableIID.Text));
                                        receiverTransfer.AddMappingCategory(mappingCategory);                                       
                                    }
                                }
                                labelMessage.Text = "Data successfully Updated...";
                                labelMessage.ForeColor = System.Drawing.Color.Green;
                            }                      
                        else
                        {
                            labelMessage.Text = "Data not Updated...";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                        }
                  }
               
                ClearField();
                LoadMappingCategoryList();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (MappingCategoryRT receiverTransfer = new MappingCategoryRT())
                {
                       hdIsDelete.Value = "true";
                        hdIsEdit.Value = "true";
                             if (!string.IsNullOrEmpty(txtParentID.Text))
                             {
                                 List<MappingCategory> mappingCategoryList = new List<MappingCategory>();
                                 mappingCategoryList = receiverTransfer.GetMappingCategoryByTableID(Convert.ToInt32(txtParentID.Text));
                                 if (mappingCategoryList != null && mappingCategoryList.Count > 0)
                                    {
                                        foreach (MappingCategory mappCategory in mappingCategoryList)
                                        {                                            
                                            mappCategory.IsRemoved = true;                                             
                                            receiverTransfer.UpdateMappingCategory(mappCategory);
                              
                                        }
                                        labelMessage.Text = "Data successfully deleted...";
                                        labelMessage.ForeColor = System.Drawing.Color.Green;
                                         
                                 }  
                               }
                             
                                else
                                {
                                    labelMessage.Text = "Data not deleted...";
                                    labelMessage.ForeColor = System.Drawing.Color.Red;
                                }
                              
                }
                       
                LoadMappingCategoryList();
                ClearField();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearField();
        }

        int lvRowCount = 0;
        int currentPage = 0;
        protected void dataPagerMapCategoryList_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadMappingCategoryList();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }


        protected void lvMapCategoryList_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void lvMapCategoryList_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditMappinCategoryList")
            {
                try
                {
                   // ClearField();
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    int mappingCategoryID = Convert.ToInt32(e.CommandArgument);
                    hdMappingCategoryID.Value = mappingCategoryID.ToString();
                    using (MappingCategoryRT receiverTransfer = new MappingCategoryRT())
                    {
                        MappingCategory mappingCategory = receiverTransfer.GetMappingCategoryByID(mappingCategoryID);
                        FillMappingCategoryForEdit(mappingCategory);
                    }
              }
                catch (Exception ex)
                {
                    labelMessage.Text = "Error : " + ex.Message;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

            //----------------------------------------GroupView--Method Return a Single Row with grouping -------------------------------------\\
        //----------------------------------------Added By Marzia-24-02-15(called in Item Template->aspx Page) -------------------------------------\\
      
        protected string fGroupingRowIfNewCategory()
        {
           
            String sCurrentCategory = (string)Eval("CategoryName");
            if (sCurrentCategory == " ")
                sCurrentCategory = "Unassigned Category";
            else
                sCurrentCategory = "" + sCurrentCategory;
            if (sLastCategory != sCurrentCategory)
            {
               sLastCategory = sCurrentCategory;
               return String.Format("<tr class='group' style='background-color:#FFCCFF;color:Red;font-size:100%'><asp:LinkButton> " + "<td colspan='6'><b>{0}</td></asp:LinkButton></tr>", sCurrentCategory);
            }
            else
            {     
                return String.Empty;     
            }
        }

        //--------------------------------------------------------GroupView -------------------------------------\\

        #endregion protected Events        
    }
}