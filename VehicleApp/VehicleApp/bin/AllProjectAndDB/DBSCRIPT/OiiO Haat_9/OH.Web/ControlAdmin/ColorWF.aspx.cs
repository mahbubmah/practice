using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OH.BLL.Basic;
using OH.DAL;

namespace OH.Web.ControlAdmin
{
    public partial class ColorWF : System.Web.UI.Page
    {
        private const string sessColor = "seColor";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    LoadColor();
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

        private Color CreateColor()
        {
            Session["UserID"] = "1";
            Color color = new Color();
            try
            {
                if (hdIsEdit.Value == "true")
                {
                    color.IID = Convert.ToInt32(hdColorID.Value.ToString());
                }
                color.Name = txtName.Text.Trim();
                color.Code = txtCode.Text.Trim();


                if (color.IID <= 0)
                {
                    color.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    color.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    Color cat = (Color)Session[sessColor];
                    color.CreatedBy = cat.CreatedBy; ;
                    color.CreatedDate = cat.CreatedDate;
                    color.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    color.ModifiedDate = GlobalRT.GetServerDateTime();
                }
                if (hdIsDelete.Value != "true")
                {
                    color.IsRemoved = false;
                }
                else
                {
                    color.IsRemoved = true;
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return color;
        }

        private void LoadColor()
        {
            try
            {
                using (ColorRT receiverTransfer = new ColorRT())
                {
                    lvColor.DataSource = receiverTransfer.GetAllColorForListView(); ;
                    lvColor.DataBind();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }


        private void FillClolorForEdit(Color color)
        {
            labelMessage.Text = "";
            try
            {
                if (color != null)
                {
                    txtName.Text = color.Name;
                    txtCode.Text = color.Code;
                   

                    Session[sessColor] = color;
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
            txtCode.Text = string.Empty;
        

            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnCancel.Visible = false;
            
        }

        #endregion private Methods



        #region protected Events

        protected void lvColor_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditColor")
            {
                try
                {
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnCancel.Visible = true;
                    int colorID = Convert.ToInt32(e.CommandArgument);
                    hdColorID.Value = colorID.ToString();
                    using (ColorRT receiverTransfer = new ColorRT())
                    {
                        Color color = receiverTransfer.GetColorByID(colorID);
                        FillClolorForEdit(color);
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

        protected void dataPagerColor_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadColor();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvColor_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //labelMessage.Text = string.Empty;
                using (ColorRT receiverTransfer = new ColorRT())
                {
                    List<Color> colorList = new List<Color>();
                    colorList = receiverTransfer.GetColorByName(txtName.Text);
                    if (colorList != null && colorList.Count > 0)
                    {
                        string msg = "Color Name  " + txtName.Text + " Already Exists!";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                        //string alertScript =
                        //String.Format("alert('{0}');", msg);
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "Key", alertScript, true);

                        labelMessage.Text = msg;
                        return;
                    }

                    Color color = CreateColor();
                    receiverTransfer.AddColor(color);
                    if (color.IID > 0)
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
                LoadColor();
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
               
                using (ColorRT receiverTransfer = new ColorRT())
                {
                    List<Color> color1 = new List<Color>();
                    color1 = receiverTransfer.GetColorByName(txtName.Text.Trim());
                    if (color1.Count == 0)
                    {
                        hdIsEdit.Value = "true";
                        hdIsDelete.Value = "false";
                        Color color = CreateColor();


                        if (color != null)
                        {
                            receiverTransfer.UpdateColor(color);
                            labelMessage.Text = "Data successfully updated..." ;
                            labelMessage.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            labelMessage.Text = "Data not updated..." ; 
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                    {
                        labelMessage.Text =  "Color Name  " + txtName.Text + " Already Exists!";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
                ClearField();
                LoadColor();
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
             
                using (ColorRT receiverTransfer = new ColorRT())
                {
                    hdIsDelete.Value = "true";
                    hdIsEdit.Value = "true";
                    Color color = CreateColor();

                    if (color != null)
                    {
                        receiverTransfer.UpdateColor(color);
                        labelMessage.Text = "Data successfully deleted...";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        labelMessage.Text = "Data not deleted...";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
                LoadColor();
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
            labelMessage.Text = string.Empty;
        }
        #endregion protected Events
    }
}