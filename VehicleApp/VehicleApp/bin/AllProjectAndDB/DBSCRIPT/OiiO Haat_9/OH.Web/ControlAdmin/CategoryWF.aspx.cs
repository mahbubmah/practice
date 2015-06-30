using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using OH.BLL.Basic;
using OH.DAL;

namespace OH.Web.ControlAdmin
{
    public partial class CategoryWF : System.Web.UI.Page
    {
        private const string sessCategory = "seCategory";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    LoadCategory();
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnCancel.Visible = false;
                }
                catch (Exception ex)
                {
                    labelMessage.Text = "Error : " + ex.Message;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }


        #region private Methods

        private Category CreateCategory()
        {
            Session["UserID"] = "1";
            Category category = new Category();
            try
            {
                if (hdIsEdit.Value == "true")
                {
                    category.IID = Convert.ToInt32(hdCategoryID.Value.ToString());
                }
                category.Name = txtName.Text.Trim();
                category.SerialNo = Convert.ToInt32( txtSerialNo.Text.Trim());
                if (category.ParentID!=null)
                {
                    category.ParentID = Convert.ToInt32(txtParentID.Text);
                }
               
               
                if (category.IID <= 0)
                {
                    category.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    category.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    Category cat = (Category)Session[sessCategory];
                    category.CreatedBy = cat.CreatedBy; ;
                    category.CreatedDate = cat.CreatedDate;
                    category.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    category.ModifiedDate = GlobalRT.GetServerDateTime();
                }
                if (hdIsDelete.Value != "true")
                {
                    category.IsRemoved= false;
                }
                else
                {
                    category.IsRemoved = true;
                    hdIsDelete.Value = "false";
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return category;
        }

        private void LoadCategory()
        {
            try
            {
                using (CategoryRT receiverTransfer = new CategoryRT())
                {
                    lvCategory.DataSource = receiverTransfer.GetAllCategoryForListView(); ;
                    lvCategory.DataBind();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        
        private void FillCategoryForEdit(Category category)
        {
            try
            {
                if (category != null)
                {
                    
                    txtName.Text = category.Name;
                    txtSerialNo.Text = category.SerialNo.ToString();
                    using (CategoryRT receiverTransfer=new CategoryRT())
                    {
                        if (category.ParentID!=null)
                        {
                            var cat =
                                receiverTransfer.GetCategoryByID(category.ParentID != null
                                    ? Convert.ToInt64(category.ParentID)
                                    : 0);
                            txtParentCategoryID.Text = cat.Name;
                            txtParentID.Text = category.ParentID != null ? Convert.ToString(category.ParentID) : string.Empty;
                        }
                        else
                        {
                            txtParentCategoryID.Text = string.Empty;
                            txtParentID.Text = string.Empty;
                        }
                        
                    }
                    
                    Session[sessCategory] = category;
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
            txtName.Text = string.Empty;
            txtParentCategoryID.Text = string.Empty;
            txtSerialNo.Text = string.Empty;
            txtParentID.Text = string.Empty;

            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnCancel.Visible = false;
        }

        #endregion private Methods



        #region protected Events

        protected void lvCategory_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditCategory")
            {
                try
                {
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnCancel.Visible = true;
                    Int64 categoryID = Convert.ToInt64(e.CommandArgument);
                    hdCategoryID.Value = categoryID.ToString();
                    using (CategoryRT receiverTransfer = new CategoryRT())
                    {
                        Category category = receiverTransfer.GetCategoryByID(categoryID);
                        FillCategoryForEdit(category);
                    }
                    labelMessage.Text = string.Empty;
                }
                catch (Exception ex)
                {
                    labelMessage.Text = "Error : " + ex.Message;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

         int lvRowCount = 0;
        int currentPage = 0;

        protected void dataPagerCategory_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadCategory();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvCategory_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //labelMessage.Text = string.Empty;
                using (CategoryRT receiverTransfer = new CategoryRT())
                {
                    List<Category> categorieList = new List<Category>();
                    categorieList = receiverTransfer.GetCategoryByName(txtName.Text);
                    bool IsParentIdSame = false;
                    foreach (var cat in categorieList)
                    {
                        if (cat.ParentID==Convert.ToInt32(txtParentID.Text))
                        {
                            IsParentIdSame = true;
                        }
                    }

                    if (IsParentIdSame)
                    {
                        string msg = "Category Name  " + txtName.Text + " Already Exists in this parent category!";
                        //string alertScript =
                        //String.Format("alert('{0}');", msg);
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "Key", alertScript, true);

                        labelMessage.Text = msg;
                        return;
                    }

                    Category category = CreateCategory();
                    receiverTransfer.AddCategory(category);
                    if (category.IID > 0)
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
                LoadCategory();
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
                // labelMessage.Text = string.Empty;
                using (CategoryRT receiverTransfer = new CategoryRT())
                {
                    List<Category> categorieList = new List<Category>();
                    categorieList = receiverTransfer.GetCategoryByName(txtName.Text);
                    bool IsParentIdSame = false;
                    foreach (var cat in categorieList)
                    {
                        if (cat.ParentID == Convert.ToInt32(txtParentID.Text))
                        {
                            IsParentIdSame = true;
                        }
                    }

                    if (IsParentIdSame)
                    {
                        string msg = "Category Name  " + txtName.Text + " Already Exists in this parent category!";
                        //string alertScript =
                        //String.Format("alert('{0}');", msg);
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "Key", alertScript, true);

                        labelMessage.Text = msg;
                        return;
                    }

                    hdIsEdit.Value = "true";
                    Category category = CreateCategory();


                    if (category != null)
                    {
                        receiverTransfer.UpdateCategory(category);
                        labelMessage.Text = "Data successfully updated...";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        labelMessage.Text = "Data not updated...";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
                ClearField();
                LoadCategory();
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
                // labelMessage.Text = string.Empty;
                using (CategoryRT receiverTransfer = new CategoryRT())
                {
                    List<Category> catagory = new List<Category>();

                    catagory = receiverTransfer.GetAllCategoryByParentID(Convert.ToInt32(hdCategoryID.Value.ToString()));
                    if (catagory.Count == 0)
                    {
                        hdIsDelete.Value = "true";
                        hdIsEdit.Value = "true";
                        Category category = CreateCategory();
                        
                        if (category != null)
                        {
                            receiverTransfer.UpdateCategory(category);
                            labelMessage.Text = "Data successfully deleted...";
                            labelMessage.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            labelMessage.Text = "Data not deleted...";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                    {
                        labelMessage.Text = "Data not deleted. Please Delete the sub category frist.....";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                    }
                    
                   
                }
                LoadCategory();
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
        
        #endregion protected Events
    }
}