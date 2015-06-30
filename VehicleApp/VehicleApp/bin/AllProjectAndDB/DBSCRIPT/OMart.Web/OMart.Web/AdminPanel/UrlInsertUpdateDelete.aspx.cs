using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BLL.Basic;
using DAL;

namespace OMart.Web.AdminPanel
{

    public partial class UrlInsertUpdateDelete : System.Web.UI.Page
    {
        private int IID = default(int);
        UrlWFListRT receiveTransfer = new UrlWFListRT();
        private const string sessUrlWFList = "seUrlWFList";
        public UrlInsertUpdateDelete()
        {
           
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    var requestId = Request.QueryString["IID"];
                    bool reqIDIsValid = Int32.TryParse(requestId, out IID);
                    if (reqIDIsValid)
                    {
                        showUrlList();
                    }
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        public void showUrlList()
        {
            try
            {
                UrlWFList url = receiveTransfer.GetUrlWFListByID(IID);
                if(url != null)
                {
                    dropDownModuleName.Text = url.ModuleName.ToString();
                    txtUrlName.Text = url.UrlWFName.ToString();
                    txtUrlWFDisplayName.Text = url.UrlWFDisplayName.ToString();
                    txtUrlWFSerialNo.Text = url.ModuleSerialNo.ToString();
                    txtUrlWFSerialNo.Text = url.UrlWFSerialNo.ToString();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private UrlWFList CreateUrlList()
        {
            Session["UserID"] = "1";
            UrlWFList urlWFList = new UrlWFList();
            try
            {
                if (hdIsEdit.Value == "true")
                {
                    
                    urlWFList.IID = Convert.ToInt32(hdUrlListID.Value.ToString());
                }
                urlWFList.UrlWFName = txtUrlName.Text.Trim();
                urlWFList.UrlWFDisplayName = txtUrlWFDisplayName.Text.Trim();
                urlWFList.ModuleName = dropDownModuleName.SelectedItem.ToString();
                urlWFList.UrlWFSerialNo = Convert.ToInt32(txtUrlWFSerialNo.Text.Trim());
                urlWFList.ModuleSerialNo = Convert.ToInt32(txtModuleSerialNo.Text.Trim());
                if (urlWFList.IID <= 0)
                {
                    urlWFList.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    urlWFList.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    UrlWFList url = (UrlWFList)Session[sessUrlWFList];
                    urlWFList.CreatedBy = url.CreatedBy;
                    urlWFList.CreatedDate = url.CreatedDate;
                    urlWFList.ModifiedBy = url.ModifiedBy;
                    urlWFList.ModifiedDate = url.ModifiedDate;
                }

            }
            catch (Exception e)
            {
                labelMessage.Text = "Error: " + e.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return urlWFList;
        }

        private void ClearField()
        {
            txtUrlName.Text = string.Empty;
            txtUrlWFDisplayName.Text = string.Empty;
            dropDownModuleName.SelectedValue = null;
            //LoadDropDownModule(null);
            txtModuleSerialNo.Text = string.Empty;
            txtUrlWFSerialNo.Text = string.Empty;
        }
        protected void btn_CreateOrEdit_Click(object sender, EventArgs e)
        {
            try
            {
                using (UrlWFListRT receiveTransfer = new UrlWFListRT())
                {
                    List<UrlWFList> urlListList = new List<UrlWFList>();
                    urlListList = receiveTransfer.GetUrlWFListByNmae(txtUrlName.Text.Trim());
                    if (urlListList != null && urlListList.Count() > 0)
                    {
                        string msg = "...Url List already exist...";
                        labelMessage.Text = msg;
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                        ClearField();
                        return;
                    }

                    UrlWFList urlList = CreateUrlList();
                    receiveTransfer.AddUrlWFList(urlList);

                    if (urlList.IID > 0)
                    {
                        labelMessage.Text = "Url List Successffuly Inserted";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        labelMessage.Text = "Url did not Inserted";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                    }

                }
                ClearField();
                UrlWFListWF ur = new UrlWFListWF();
                ur.LoadUrlWFList();
               
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}