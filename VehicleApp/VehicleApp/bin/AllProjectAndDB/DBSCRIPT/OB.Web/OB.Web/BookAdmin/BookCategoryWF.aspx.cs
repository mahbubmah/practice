using OB.BLL.Basic;
using OB.DAL;
using OB.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OB.Web.BookAdmin
{
    public partial class BookCategoryWF : System.Web.UI.Page
    {
        private const string sessCategory = "seCategory";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    LoadCategory();
                    LoadDropDownParentCategory();
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
        private void LoadDropDownParentCategory()
        {
            try
            {
                DropDownListHelper.Bind(dropDownParentCategory, EnumHelper.EnumToList<EnumCollection.ParentCategory>(), EnumCollection.ListItemType.ParentCategory);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        private BooKCategory CreateCategory()
        {
            Session["UserID"] = "1";
            BooKCategory category = new BooKCategory();
            try
            {
                if (hdIsEdit.Value == "true")
                {
                    category.IID = Convert.ToInt32(hdCategoryID.Value.ToString());
                }
                category.CategoryName = txtName.Text.Trim();
                category.DisplayOrder = Convert.ToInt32(txtSerialNo.Text.Trim());
                category.ParentCategoryID = Convert.ToInt32(dropDownParentCategory.SelectedValue);
                category.LastUpdatedDate = Convert.ToDateTime(txtLastUpdateDate.Text.Trim());
                category.CategoryDescription = txtDescription.Text.Trim();

                if (category.IID <= 0)
                {
                    category.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    category.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    BooKCategory cat = (BooKCategory)Session[sessCategory];
                    category.CreatedBy = cat.CreatedBy; ;
                    category.CreatedDate = cat.CreatedDate;
                    category.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    category.ModifiedDate = GlobalRT.GetServerDateTime();
                }
                if (hdIsDelete.Value != "true")
                {
                    category.IsRemoved = false;
                }
                else
                {
                    category.IsRemoved = true;
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
                using (BookCategoryRT receiverTransfer = new BookCategoryRT())
                {
                    lvCategory.DataSource = receiverTransfer.GetAllBookCategoryForListView(); ;
                    lvCategory.DataBind();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }


        private void FillCategoryForEdit(BooKCategory category)
        {
            try
            {
                if (category != null)
                {

                    txtName.Text = category.CategoryName;
                    txtSerialNo.Text = category.DisplayOrder.ToString();
                    dropDownParentCategory.SelectedValue = Convert.ToString(category.ParentCategoryID);
                    txtDescription.Text = category.CategoryDescription.ToString();
                    txtLastUpdateDate.Text = category.LastUpdatedDate.ToString();

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
            dropDownParentCategory.SelectedValue = "-1";
            txtSerialNo.Text = string.Empty;

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
                    int categoryID = Convert.ToInt32(e.CommandArgument);
                    hdCategoryID.Value = categoryID.ToString();
                    using (BookCategoryRT receiverTransfer = new BookCategoryRT())
                    {
                        BooKCategory category = receiverTransfer.GetBookCategoryByID(categoryID);
                        FillCategoryForEdit(category);
                    }
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
                using (BookCategoryRT receiverTransfer = new BookCategoryRT())
                {
                    List<BooKCategory> categorieList = new List<BooKCategory>();
                    categorieList = receiverTransfer.GetBookCategoryByName(txtName.Text);
                    if (categorieList != null && categorieList.Count > 0)
                    {
                        string msg = "Book Category Name  " + txtName.Text + " Already Exists!";
                        //string alertScript =
                        //String.Format("alert('{0}');", msg);
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "Key", alertScript, true);

                        labelMessage.Text = msg;
                        return;
                    }

                    BooKCategory category = CreateCategory();
                    receiverTransfer.AddBooKCategory(category);
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
                using (BookCategoryRT receiverTransfer = new BookCategoryRT())
                {
                    hdIsEdit.Value = "true";
                    BooKCategory category = CreateCategory();


                    if (category != null)
                    {
                        receiverTransfer.UpdateBooKCategory(category);
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
                using (BookCategoryRT receiverTransfer = new BookCategoryRT())
                {
                    
                        hdIsDelete.Value = "true";
                        hdIsEdit.Value = "true";

                        BooKCategory category = CreateCategory();
                        if (category != null)
                        {
                            receiverTransfer.UpdateBooKCategory(category);
                            labelMessage.Text = "Data successfully deleted...";
                            labelMessage.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            labelMessage.Text = "Data not deleted...";
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