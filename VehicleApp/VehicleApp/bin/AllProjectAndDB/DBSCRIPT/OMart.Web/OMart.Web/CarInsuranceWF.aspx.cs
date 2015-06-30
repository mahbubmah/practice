using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;
using DAL;
using Utilities;


namespace OMart.Web
{
    public partial class CarInsuranceWF : System.Web.UI.Page
    {
        private readonly CarInsuranceRT _carInsuranceRT;
        private string _pageLogPath;

        public CarInsuranceWF()
        {
            this._carInsuranceRT = new CarInsuranceRT();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    loadAllInsuranceTypes();
                    loadInsuranceCarNews();
                    loadInsuranceCompaniesLogo();

                }
 
            }

            catch(Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
           

        }

        private void loadInsuranceCompaniesLogo()
        {
            try
            {
                rptInsuranceCompanyLogo.DataSource = _carInsuranceRT.GetAllInsuranceCompanies();
                rptInsuranceCompanyLogo.DataBind();
                
            }
            catch(Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void loadInsuranceCarNews()
        {
            try
            {
                rptInsuranceCarNews.DataSource = _carInsuranceRT.GetAllInsuranceCarNews();
                rptInsuranceCarNews.DataBind();

            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
            
            
        }

        private void loadAllInsuranceTypes()
        {
            try
            {
              //  List<InsuranceCar> InsuranceList = new List<InsuranceCar>();
                //var  InsuranceList = EnumHelper.EnumCamelSpaceToList<EnumCollection.BusinessInsuranceType>();
               // var enumList = GetEnumData();
                var insurance = _carInsuranceRT.GetAllInsuranceTypesForCarInsurance();
                rptInsuranceTypes.DataSource = insurance;
                rptInsuranceTypes.DataBind();

            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private List<EnumModifier> GetEnumData()
        {
            try
            {
                var list = Utilities.EnumHelper.EnumToList<Utilities.EnumCollection.BusinessInsuranceType>();

                List<EnumModifier> enumModifierList = new List<EnumModifier>();

                foreach (var enumMember in list)
                {
                    EnumModifier enumModifier = new EnumModifier();
                    string enumDisplayMember = enumMember.ToString();

                    string name = string.Empty;
                    string value = string.Empty;
                    switch (enumDisplayMember)
                    {
                        case "BusinessInsurance":
                            name = "BusinessInsurance";
                            value = "1";
                            break;
                        case "LifeInsurance":
                            name = "LifeInsurance";
                            value = "2";
                            break;
                        case "CarInsurance":
                            name = "CarInsurance";
                            value = "3";
                            break;
                        case "HomeInsurance":
                            name = "HomeInsurance";
                            value = "4";
                            break;
                        case "PersonalLoan":
                            name = "PersonalLoan";
                            value = "5";
                            break;
                        case "HouseLoan":
                            name = "HouseLoan";
                            value = "6";
                            break;
                    }
                    enumModifier.Name = name;
                    enumModifier.Value = value;
                    enumModifierList.Add(enumModifier);
                }
                return enumModifierList;
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
            return null;
        }
    }
}