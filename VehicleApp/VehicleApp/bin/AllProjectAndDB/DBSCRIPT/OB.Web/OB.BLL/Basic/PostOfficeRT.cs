using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OB.DAL;


namespace OB.BLL.Basic
{
    public class PostOfficeRT : IDisposable
    {
        public PostOfficeRT()
        {
        }
        public bool IsPostOfficeCodeExists(string PostOfficeCode, int PoliceStationID)
        {
            try
            {
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<PostOffice> PostOfficeCodeList = new List<PostOffice>();
                PostOfficeCodeList = dbContext.PostOffices.Where(d => d.IsRemoved == false && d.Code == PostOfficeCode && d.DistrictID == PoliceStationID).ToList();
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
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
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
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<PostOffice> PostOfficeNameList = new List<PostOffice>();
                PostOfficeNameList = dbContext.PostOffices.Where(d => d.IsRemoved == false && d.Name == PostOfficeName && d.DistrictID == PoliceStationID).ToList();
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
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                //DivisionOrState divisionOrState = new DivisionOrState();
                var postOfficeList = dbContext.GetAllFromPostOffice();
                return postOfficeList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public bool IsPostOfficeCodeExistInOtherRows(long id, string code, long districtID)
        {
            try
            {
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
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
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
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
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
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
                OiiOBookDCDataContext msDC = DatabaseHelper.GetDataModelDataContext();
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
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                PostOffice PostOffc = new PostOffice();
                PostOffc = dbContext.PostOffices.Single(d => d.IID == PostoffcID );

                dbContext.Dispose();
                return PostOffc;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }
}
