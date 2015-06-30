using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Basic
{
    public class PostOfficeRT : IDisposable
    {
        private readonly OiiOMartDBDataContext dbContext;
        public PostOfficeRT()
        {
            dbContext = DatabaseHelper.GetDataModelDataContext();
        }

        public bool IsPostOfficeCodeExists(string PostOfficeCode, int PoliceStationID)
        {
            try
            {
                List<PostOffice> PostOfficeCodeList = new List<PostOffice>();
                PostOfficeCodeList = dbContext.PostOffices.Where(d => d.IsRemoved == false && d.Code == PostOfficeCode && d.PoliceStationID == PoliceStationID).ToList();
                dbContext.Dispose();
                if (PostOfficeCodeList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public bool IsPostOfficeCodeExists(string code)
        {
            try
            {
              
                List<PostOffice> PostOfficeCodeList = new List<PostOffice>();
                PostOfficeCodeList = dbContext.PostOffices.Where(d => d.IsRemoved == false && d.Code.Contains(code)).ToList();
                dbContext.Dispose();
                if (PostOfficeCodeList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public bool IsPostOfficeNameExists(string postOfficeName, long districtId)
        {
            try
            {
                bool isPostOfficeNameExist = false;
                var postOfficeList = dbContext.PostOffices.Where(po => po.DistrictID == districtId && po.Name == postOfficeName).ToList();
                if (postOfficeList.Count>0)
                {
                    isPostOfficeNameExist = true;

                }
                return isPostOfficeNameExist;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        /// <summary>
        /// Hasan Add 2015.03.12 For Checking Is Post Office Active Under a Police Station
        /// </summary>
        /// <param name="PoliceStationID"></param>
        /// <returns></returns>
        public bool IsPostOfficeExistsInPoliceStation(int PoliceStationID)
        {
            try
            {
               
                List<PostOffice> PostOfficeNameList = new List<PostOffice>();
                PostOfficeNameList = dbContext.PostOffices.Where(d => d.IsRemoved == false && d.PoliceStationID == PoliceStationID).ToList();
                dbContext.Dispose();
                if (PostOfficeNameList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void AddPostOffice(PostOffice postOffice)
        {
            try
            {
                DatabaseHelper.Insert<PostOffice>(postOffice);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

       

        public object GetPostOfficeAllForListView()
        {
            try
            {


                var postOfficeList = dbContext.SP_GetAllPostOfficeForListView();
                return postOfficeList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public bool IsPostOfficeCodeExistInOtherRows(long id, string code, long districtID)
        {
            try
            {
             
                List<PostOffice> postOfficeCodeList = new List<PostOffice>();
                postOfficeCodeList = dbContext.PostOffices.Where(d => d.IsRemoved == false && d.IID != id && d.Code == code && d.DistrictID == districtID).ToList();
                dbContext.Dispose();
                if (postOfficeCodeList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public bool IsPostOfficeNameExistInOtherRows(long id, string name, long districtID)
        {
            try
            {
              
                List<PostOffice> postOfficeNameList = new List<PostOffice>();
                postOfficeNameList = dbContext.PostOffices.Where(d => d.IsRemoved == false && d.IID != id && d.Name == name && d.DistrictID == districtID).ToList();
                dbContext.Dispose();
                if (postOfficeNameList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public bool IsPostOfficeCodeExistsInOtherRows(long id, string code)
        {
            try
            {
              
                List<PostOffice> postOfficeCodeList = new List<PostOffice>();
                postOfficeCodeList = dbContext.PostOffices.Where(d => d.IsRemoved == false && d.IID != id && d.Code == code).ToList();
                dbContext.Dispose();
                if (postOfficeCodeList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void UpdatePostOffice(PostOffice postOffice)
        {
            try
            {

                PostOffice postOff = dbContext.PostOffices.Single(d => d.IID == postOffice.IID);
                DatabaseHelper.Update<PostOffice>(dbContext, postOffice, postOff);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public PostOffice GetPostOfficeByID(long PostoffcID)
        {
            try
            {
                PostOffice PostOffc = new PostOffice();
                PostOffc = dbContext.PostOffices.Single(d => d.IID == PostoffcID);
                return PostOffc;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        #region IDisposable Members
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members

        public List<PostOffice> GetPostOfficesByDistrictId(long policeStaionId)
        {
            try
            {
                var postOfficeList = dbContext.PostOffices.Where(po => po.PoliceStationID == policeStaionId).ToList();
                return postOfficeList;
            }
            catch (Exception exception)
            {
                
                throw new Exception(exception.Message,exception);
            }
        }

        public bool IsPostCodeAlreadyExist(string postCode, int countryId)
        {
            try
            {
                bool isPostCodeAlreadyExist = false;
                var postOfficeList =
                    dbContext.PostOffices.Where(po => po.CountryID == countryId && po.Code == postCode).ToList();
                if (postOfficeList.Count>0)
                {
                    isPostCodeAlreadyExist = true;
                }
                return isPostCodeAlreadyExist;
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message, exception);
            }
        }

        public bool IsDistrictAlreadyExists(long districtId)
        {
            try
            {
                bool isDistrictAlreadyExistForPostOffice = false;
                var postOfficeList =
                    dbContext.PostOffices.Where(
                        po =>
                            po.DistrictID == districtId && po.IsRemoved == false && po.PoliceStationID == null &&
                            po.Name == null).ToList();
                if (postOfficeList.Count>0)
                {
                    isDistrictAlreadyExistForPostOffice=true;
                }
                return isDistrictAlreadyExistForPostOffice;
            }
            catch (Exception exception)
            {
                
                throw new Exception(exception.Message,exception);
            }
        }

        public bool IsPoliceStationAlreadyExists(long policeStaionId)
        {
            try
            {
                bool isPoliceStaionAlreadyExistForPostOffice = false;
                var postOfficeList =
                    dbContext.PostOffices.Where(
                        po =>
                            po.PoliceStationID == policeStaionId && po.IsRemoved == false && po.Name == null).ToList();
                if (postOfficeList.Count > 0)
                {
                    isPoliceStaionAlreadyExistForPostOffice = true;
                }
                return isPoliceStaionAlreadyExistForPostOffice;
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message, exception);
            }
        }
    }
}
