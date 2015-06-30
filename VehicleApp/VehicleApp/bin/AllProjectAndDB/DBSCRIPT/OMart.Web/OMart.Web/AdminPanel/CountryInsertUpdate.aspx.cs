using BLL.Basic;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMart.Web.AdminPanel
{
    public partial class CountryInsertUpdate : System.Web.UI.Page
    {
        private readonly CountryRT _countryRT;
        private int IID = default(int);

        public CountryInsertUpdate()
        {
            this._countryRT = new CountryRT();
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
                        ShowCountryData();
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
                Country country = CreateCountry();
                bool reqIDIsValid = Int32.TryParse(Request.QueryString["IID"], out IID);
                var msg = BusinessLogicValidation(country);

                if (string.IsNullOrEmpty(msg))
                {
                    if (IID <= 0)
                    {
                        country.CreatedBy = Convert.ToInt64(Session["UserID"]);
                        country.CreatedDate = DateTime.Now;
                       
                        _countryRT.AddCountry(country);
                        ClearData();

                        labelMessage.Text = "Information has been inserted successfully.";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        Country objCountry = _countryRT.GetCountryByIID(IID);

                        if (objCountry != null)
                        {
                            country.CreatedBy = objCountry.CreatedBy; ;
                            country.CreatedDate = objCountry.CreatedDate;
                            country.IID = objCountry.IID;

                            country.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                            country.ModifiedDate = DateTime.Now;

                            _countryRT.UpdateCountry(country);
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
                Response.Redirect("~/AdminPanel/CountryDisplay");
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ShowCountryData()
        {
            try
            {
                Country objCountry = _countryRT.GetCountryByIID(IID);
                if (objCountry != null)
                {
                    txtCountryName.Text = objCountry.Name;
                    txtCode.Text = objCountry.Code;
                    txtISDCode.Text = objCountry.ISDCode;
                    chkIsRemoved.Checked = objCountry.IsRemoved;
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private string BusinessLogicValidation(Country country)
        {
            string message = string.Empty;
            bool reqIDIsValid = Int32.TryParse(Request.QueryString["IID"], out IID);


            if(string.IsNullOrEmpty(country.Name))
            {
                return message = "Country name is required.";
            }

            if (IID <= 0)
            {
                Country objCountryName = (from tr in _countryRT.GetAllCountries()
                                          where tr.Name == country.Name
                                          select tr).SingleOrDefault();
                if (objCountryName != null)
                {
                    if (objCountryName.Name == country.Name)
                    {
                        return message = "Country name already exists.";
                    }
                }

                Country objCountryCode = (from tr in _countryRT.GetAllCountries()
                                          where tr.Code == country.Code
                                          select tr).SingleOrDefault();
                if (objCountryCode != null)
                {
                    if (objCountryCode.Code == country.Code && country.Code != "")
                    {
                        return message = "Country code already exists.";
                    }
                }

                Country objCountryISDCode = (from tr in _countryRT.GetAllCountries()
                                             where tr.ISDCode == country.ISDCode
                                             select tr).SingleOrDefault();
                if (objCountryISDCode != null)
                {
                    if (objCountryISDCode.ISDCode == country.ISDCode && country.ISDCode != "")
                    {
                        return message = "Country ISD code already exists.";
                    }
                }


            }
            else
            {
                Country objCountryName = (from tr in _countryRT.GetAllCountries()
                                          where tr.Name == country.Name && tr.IID != IID
                                          select tr).SingleOrDefault();
                if (objCountryName != null)
                {
                    if (objCountryName.Name == country.Name)
                    {
                        return message = "Country name already exists.";
                    }
                }

                Country objCountryCode = (from tr in _countryRT.GetAllCountries()
                                          where tr.Code == country.Code && tr.IID != IID
                                          select tr).SingleOrDefault();
                if (objCountryCode != null)
                {
                    if (objCountryCode.Code == country.Code)
                    {
                        return message = "Country code already exists.";
                    }
                }

                Country objCountryISDCode = (from tr in _countryRT.GetAllCountries()
                                             where tr.ISDCode == country.ISDCode && tr.IID != IID
                                             select tr).SingleOrDefault();
                if (objCountryISDCode != null)
                {
                    if (objCountryISDCode.ISDCode == country.ISDCode)
                    {
                        return message = "Country ISD code already exists.";
                    }
                }
            }

            return message;
        }

        private Country CreateCountry()
        {
            Session["UserID"] = "1";
            Country country = new Country();
            try
            {
                country.Name = txtCountryName.Text.Trim();
                country.Code = txtCode.Text.Trim();
                country.ISDCode = txtISDCode.Text.Trim();
                country.IsRemoved = chkIsRemoved.Checked;
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return country;
        }

        private void ClearData()
        {
            txtCountryName.Text = string.Empty; ;
            txtCode.Text = string.Empty; ;
            txtISDCode.Text = string.Empty; ;
        }

    }
}