using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OH.DAL;

namespace OH.BLL.Basic
{
    public class PostOfficeRT : IDisposable
    {
        /// <summary>
        /// Created By : Asiful Islam
        /// </summary>
        public PostOfficeRT()
        {
        }
        public bool IsPostOfficeCodeExists(string PostOfficeCode, int PoliceStationID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
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
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
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

        public bool IsPostOfficeNameExists(string PostOfficeName, int PoliceStationID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<PostOffice> PostOfficeNameList = new List<PostOffice>();
                PostOfficeNameList = dbContext.PostOffices.Where(d => d.IsRemoved == false && d.Name == PostOfficeName && d.PoliceStationID == PoliceStationID).ToList();
                dbContext.Dispose();
                if (PostOfficeNameList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        /// <summary>
        /// Hasan Add 2015.03.12 For Checking Is Post Office Active Under a Police Station
        /// </summary>
        /// <param name="PoliceStationID"></param>
        /// <returns></returns>
        public bool IsPoliceStationExistsInPostOffice(int PoliceStationID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
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

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public object GetPostOfficeAllForListView()
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();

                var postOfficeList = from Postoffice in dbContext.PostOffices
                                     join country in dbContext.Countries on Postoffice.CountryID equals country.IID
                                     join division in dbContext.DivisionOrStates on Postoffice.DivisionOrStateID equals division.IID
                                     join district in dbContext.Districts on Postoffice.DistrictID equals district.IID
                                     join policeStation in dbContext.PoliceStations on Postoffice.PoliceStationID equals policeStation.IID
                                     //where Postoffice.IsRemoved==false
                                 select new { Postoffice.IID, PostOfficeName=Postoffice.Name, Postoffice.Code,CounrtyName=country.Name,Division=division.Name,districtName=district.Name,policeStation=policeStation.Name,Postoffice.IsRemoved };

                //var postofficeList = dbContext.PostOffices.Where(d=>d.IsRemoved == false).ToList();
                //dbContext.Dispose();
                //return usrGrpList;
                //var postOfficeList = dbContext.GetAllFromPostOffice();
                return postOfficeList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public bool IsPostOfficeCodeExistInOtherRows(long id, string code, long districtID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
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
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
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
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
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
                OiiOHaatDCDataContext msDC = DatabaseHelper.GetDataModelDataContext();
                PostOffice postOff = msDC.PostOffices.Single(d => d.IID == postOffice.IID);
                DatabaseHelper.Update<PostOffice>(msDC, postOffice, postOff);

                msDC.Dispose();
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public PostOffice GetPostOfficeByID(int PostoffcID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                PostOffice PostOffc = new PostOffice();
                PostOffc = dbContext.PostOffices.Single(d => d.IID == PostoffcID);

                dbContext.Dispose();
                return PostOffc;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }
}
