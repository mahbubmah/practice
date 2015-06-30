using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Utilities;

namespace BLL.Basic
{
    public class CompanyInfoRT : IDisposable
    {

        private readonly OiiOMartDBDataContext _OiiOMartDBDataContext;
        public CompanyInfoRT()
        {
            this._OiiOMartDBDataContext = DatabaseHelper.GetDataModelDataContext();
        }

        public void AddCompanyInfo(CompanyInfo company)
        {
            try
            {
                DatabaseHelper.Insert<CompanyInfo>(company);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message, ex); }
        }

        public void UpdateCompanyInfo(CompanyInfo company)
        {
            try
            {
                CompanyInfo companyNew = _OiiOMartDBDataContext.CompanyInfos.SingleOrDefault(d => d.IID == company.IID);

                DatabaseHelper.Update<CompanyInfo>(_OiiOMartDBDataContext, company, companyNew);

                //_OiiOMartDBDataContext.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public CompanyInfo GetCompanyInfoByIID(long companyID)
        {
            try
            {
                CompanyInfo company = _OiiOMartDBDataContext.CompanyInfos.SingleOrDefault(d => d.IID == companyID);
                //_OiiOMartDBDataContext.Dispose();
                return company;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public CompanyInfo GetCompanyInfoByIIDAndBusinessTypeInsurance(long companyID)
        {
            try
            {
                CompanyInfo company = _OiiOMartDBDataContext.CompanyInfos.SingleOrDefault(d => d.IID == companyID && d.BussinessTypeID==4);
                //_OiiOMartDBDataContext.Dispose();
                return company;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<CompanyInfo> GetCompanyInfoName(string comName)
        {
            try
            {
                var Companies = (from tr in _OiiOMartDBDataContext.CompanyInfos.OrderBy(x => x.Name)
                                 where tr.Name.StartsWith(comName)
                                 select tr).ToList();
                return Companies;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<CompanyInfo> GetAllCompanyInfos()
        {
            try
            {
                List<CompanyInfo> companies = _OiiOMartDBDataContext.CompanyInfos.OrderBy(x => x.Name).ToList();

                return companies;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public List<CompanyInfo> GetAllCompanyInfosForCards()
        {
            try
            {
                List<CompanyInfo> companies = _OiiOMartDBDataContext.CompanyInfos.Where(x => x.IsRemoved == false && x.BussinessTypeID == Convert.ToInt32(EnumCollection.BussinessType.Banking)).OrderBy(x => x.Name).ToList();

                return companies;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }






        public List<CompanyInfo> GetAllMobileCompanyInfos()
        {
            List<CompanyInfo> companies = (from tr in _OiiOMartDBDataContext.CompanyInfos.OrderBy(x => x.Name)
                                           where tr.BussinessTypeID == Convert.ToInt32(EnumCollection.BussinessType.MobilePhone)
                                           select tr).ToList();

            return companies;
        }
        public List<CompanyInfo> GetAllMobileCompanyInfosBusinessTypeInsurance()
        {
            List<CompanyInfo> companies = (from tr in _OiiOMartDBDataContext.CompanyInfos.OrderBy(x => x.Name)
                                           where tr.BussinessTypeID == Convert.ToInt32(EnumCollection.BussinessType.Insurance)
                                           select tr).ToList();

            return companies;
        }

        public object GetAllCompanyInformations()
        {
            try
            {
                // List<CompanyInfo> companies = _OiiOMartDBDataContext.CompanyInfos.OrderBy(x => x.Name).ToList();

                OiiOMartDBDataContext dbContext = DatabaseHelper.GetDataModelDataContext();

                var companies = (from company in dbContext.CompanyInfos
                                 join country in dbContext.Countries
                                 on company.OriginCountryID equals country.IID
                                 where company.IsRemoved != null
                                 select new CompanyInformation
                                 {
                                     IID = company.IID,
                                     Name = company.Name,
                                     BussinessDescription = company.BussinessDescription,
                                     Address = company.Address,
                                     WebAddress = company.WebAddress,
                                     OriginCountryName = country.Name,
                                     BussinessTypeID = company.BussinessTypeID,
                                     TotalCountryBussCover = company.TotalCountryBussCover,
                                     IsRemoved = company.IsRemoved
                                 }).OrderBy(x => x.Name).ToList();

                return companies;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
        public List<CompanyInfo> GetCompanyInfoByBusinessTypeID (int businessTypeID)
        {
            try
            {
                var compnayInfo= _OiiOMartDBDataContext.CompanyInfos.Where(t => t.BussinessTypeID == businessTypeID && t.IsRemoved==false);
                return compnayInfo.ToList();
                                              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
        public List<CompanyInfo> GetRandomCompanyInfoByBusinessTypeID(int businessTypeID)
        {
            try
            {
                var comInfo = _OiiOMartDBDataContext.ExecuteQuery<CompanyInfo>(@"SELECT  top 5 IID,LogoUrl, ISNULL (Name,' ')AS Name, WebAddress
FROM                                                                           [CompanyInfo] WHERE BussinessTypeID=" + businessTypeID + "AND IsRemoved=0" + "ORDER BY newid()");
                return comInfo.ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
        



        #region IDisposable Members
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members

        public List<CompanyInfo> GetAllCompanyForDropDown()
        {
            try
            {
                var companyListForDropDown = _OiiOMartDBDataContext.CompanyInfos.Where(x => x.IsRemoved == false);
                return companyListForDropDown.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<CompanyInfo> GetAllEnergyCompanyForDropDown()
        {
            try
            {
                var companyListForDropDown = _OiiOMartDBDataContext.CompanyInfos.Where(x => x.IsRemoved == false&&x.BussinessTypeID==Convert.ToInt32(EnumCollection.BussinessType.Energy));
                return companyListForDropDown.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<CompanyInfo> GetAllBroadBandCompanyForDropDown()
        {
            try
            {
                var companyListForDropDown = _OiiOMartDBDataContext.CompanyInfos.Where(x => x.BussinessTypeID == 8 && x.IsRemoved == false);
                return companyListForDropDown.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
