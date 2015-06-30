using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OB.BLL.Basic;
using OB.DAL;

namespace OB.Web.BookAdmin
{
    public partial class OrderInsertUpdate : System.Web.UI.Page
    {
        private readonly BookOrderRT _BookOrderRT;
        private long IID = default(Int64);

        public OrderInsertUpdate()
        {
            this._BookOrderRT = new BookOrderRT();
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
                        ShowOrderData();
                       
                    }
                   
                   // LoadDropDownCountry(null);
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        //private void LoadDropDownCountry(int? countryID)
        //{
        //    try
        //    {
        //        using (CountryRT receverTransfer = new CountryRT())
        //        {
        //            List<Country> countryList = new List<Country>();
        //            if (countryID != null)
        //            {
        //                countryList.Add(receverTransfer.GetCountryByIID((int)countryID));
        //            }
        //            else
        //            {
        //                countryList = receverTransfer.GetAllCountryForListView();
        //            }
        //            DropDownListHelper.Bind<Country>(dropdownCountry, countryList, "Name", "IID", EnumCollection.ListItemType.Country);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }
        //}

       

        protected void btn_CreateOrEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string OrderName = string.Empty;

                BookOrder Order = CreateBookOrder();
                bool reqIDIsValid = Int64.TryParse(Request.QueryString["IID"], out IID);
                var msg = BusinessLogicValidation(Order); 
                if (string.IsNullOrEmpty(msg))
                {
                    if (IID <= 0)
                    {
                        Order.CreatedBy = Convert.ToInt64(Session["UserID"]);
                        Order.CreatedDate = DateTime.Now;
                        Order.IsRemoved = false;

                        _BookOrderRT.AddBookOrder(Order);
                        ClearData();

                        labelMessage.Text = "Information has been inserted successfully.";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        BookOrder objOrder = _BookOrderRT.GetBookOrderByIID(IID);

                        if (objOrder != null)
                        {
                            Order.CreatedBy = objOrder.CreatedBy; ;
                            Order.CreatedDate = objOrder.CreatedDate;
                            Order.IsRemoved = objOrder.IsRemoved;
                            Order.IID = objOrder.IID;

                            Order.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                            Order.ModifiedDate = DateTime.Now;

                            _BookOrderRT.UpdateBookOrder(Order);
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/BookAdmin/OrderDisplay");
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ShowOrderData()
        {
            try
            {
                BookOrder objOrder = _BookOrderRT.GetBookOrderByIID(IID);
                if (objOrder != null)
                {
                    txtQuantity.Text = objOrder.Quantity.ToString();
                    txtShippingAddress.Text = objOrder.ShippingAddress;
                    dropdownShippingStatus.Text = Convert.ToString(objOrder.ShippingStatusID);
                    dropdownPStatus.Text = Convert.ToString(objOrder.PaymentStatusID);
                    txtShippingCosts.Text = objOrder.ShippingCost.ToString();
                    txtTotalPrice.Text = objOrder.TotalPrice.ToString();
                // txtShippingDate.Text= objOrder.ShippingDate.ToString();
                    txtOrderDate.Text = objOrder.OrderDate.ToString();
                    txtUserComment.Text = objOrder.UserComment;
                    chkIsRemoved.Checked = objOrder.IsRemoved;
                   
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private string BusinessLogicValidation(BookOrder bookOrder)
        {
            string message = string.Empty;
            bool reqIDIsValid = Int64.TryParse(Request.QueryString["IID"], out IID);

            if (IID <= 0)
            {
                BookOrder objCompanyName = (from tr in _BookOrderRT.GetAllBookOrders()
                                         where tr.IID == bookOrder.IID
                                          select tr).SingleOrDefault();
                if (objCompanyName != null)
                {
                    if (objCompanyName.IID == bookOrder.IID)
                    {
                        message = "Order already Placed.";
                    }
                }

          
            }

            return message;
        }

        private BookOrder CreateBookOrder()
        {
            Session["UserID"] = "1";
            BookOrder Order = new BookOrder();
            try
            {
                Order.Quantity = Convert.ToInt32(txtQuantity.Text.Trim());
                Order.ShippingAddress =  txtShippingAddress.Text .Replace(Environment.NewLine, "<br/>");
               // (!dropdownShippingStatus.SelectedValue.IsNullOrWhiteSpace())
                if (dropdownShippingStatus.SelectedValue != "-1")
                {
                     Order.ShippingStatusID = Convert.ToInt32(dropdownShippingStatus.SelectedValue);
                }
                if (dropdownPStatus.SelectedValue != "-1")
                {
                     Order.PaymentStatusID = Convert.ToInt32(dropdownPStatus.SelectedValue);
                }
               
                Order.ShippingCost = Convert.ToInt32(txtShippingCosts.Text.Trim());
                Order.TotalPrice = Convert.ToInt32(txtTotalPrice.Text);
               // Order.Payment = Convert.ToInt32(txt.Text);
                Order.OrderDate = Convert.ToDateTime(txtOrderDate.Text);
                Order.UserComment =txtUserComment.Text.Replace(Environment.NewLine, "<br/>");;
                Order.IsRemoved = chkIsRemoved.Checked;

               
             
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return Order;
        }

        private void ClearData()
        {
           
                    txtQuantity.Text =string.Empty;
                    txtShippingAddress.Text =string.Empty;
                    dropdownShippingStatus.SelectedValue = "-1";
                    dropdownPStatus.SelectedValue = "-1";
                    txtShippingCosts.Text = string.Empty;
                    txtTotalPrice.Text = string.Empty;
                // txtShippingDate.Text= objOrder.ShippingDate.ToString();
                    txtOrderDate.Text = string.Empty;
                    txtUserComment.Text =string.Empty;
                    chkIsRemoved.Checked = false;
          
        }

      

    }
}