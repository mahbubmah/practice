using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
  
   public class CommunityNewsRT: IDisposable
    {

        private readonly OiiOMartDBDataContext _OiiOMartDBDataContext;
        public CommunityNewsRT()
        {
            this._OiiOMartDBDataContext = DatabaseHelper.GetDataModelDataContext();
        }

        public void AddCommunityNews(CommunityNew _CommunityNew)
        {
            try
            {
                DatabaseHelper.Insert<CommunityNew>(_CommunityNew);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message, ex); }
        }

        public void UpdateCommunityNews(CommunityNew _CommunityNew)
        {
            try
            {
                CommunityNew communityNew = _OiiOMartDBDataContext.CommunityNews.SingleOrDefault(d => d.IID == _CommunityNew.IID);

                DatabaseHelper.Update<CommunityNew>(_OiiOMartDBDataContext, _CommunityNew, communityNew);

                //_OiiOMartDBDataContext.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
     
        

        public List<CommunityNew> GetAllCommunityNews()
        {
            try
            {
                List<CommunityNew> CommunityNewColl = _OiiOMartDBDataContext.CommunityNews.OrderBy(x => x.IID).ToList();
                return CommunityNewColl;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public List<CommunityNew> GetAllCommunitySportsNews()
        {
            try
            {
                List<CommunityNew> CommunityNewColl = (from ci in _OiiOMartDBDataContext.CommunityNews
                                                        where ci.NewsTypeID==Convert.ToInt32(Utilities.EnumCollection.NewsType.Sports)
                                                        select ci).OrderByDescending(x => x.IID).ToList();
                return CommunityNewColl;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public List<CommunityNew> GetAllCommunityVideos()
        {
            try
            {

                List<CommunityNew> communityNewColl = (from ci in _OiiOMartDBDataContext.CommunityNews
                                       where ci.IsRemoved == false && ci.VideoLink!=null
                                                           select ci).OrderByDescending(x => x.IID).ToList();
                return communityNewColl;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
        public List<CommunityNew> GetAllCommunityEducations()
        {
            try
            {

                List<CommunityNew> communityNewColl = (from ci in _OiiOMartDBDataContext.CommunityNews
                                                       where ci.IsRemoved == false &&  
                                                       ci.NewsTypeID==Convert.ToInt32(Utilities.EnumCollection.NewsType.Education)
                                                     
                                                       select ci).OrderByDescending(x => x.IID).ToList();
                return communityNewColl;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
        public List<CommunityNew> GetAllCommunityRecreation()
        {
            try
            {

                List<CommunityNew> communityNewColl = (from ci in _OiiOMartDBDataContext.CommunityNews
                                                       where ci.IsRemoved == false &&
                                                       ci.NewsTypeID == Convert.ToInt32(Utilities.EnumCollection.NewsType.Recreation)

                                                       select ci).OrderByDescending(x => x.IID).ToList();
                return communityNewColl;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public List<CommunityNew> GetAllCommunityMostPopularGuide()
        {
            try
            {

                List<CommunityNew> communityNewColl = (from ci in _OiiOMartDBDataContext.CommunityNews
                                                       where ci.IsRemoved == false &&
                                                       ci.NewsTypeID == Convert.ToInt32(Utilities.EnumCollection.NewsType.PopularGuide)

                                                       select ci).OrderByDescending(x => x.IID).ToList();
                return communityNewColl;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public List<SP_GetAllNewsCommunityTypeResult> GetAllCommunityNewsType()
        {
            try
            {               
                return _OiiOMartDBDataContext.SP_GetAllNewsCommunityType().ToList(); ;
           
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
        public class CommunityNews
       {   
            public Int64 IID { get; set; }
            public string NewsType { get; set; }
            public string Image { get; set; }
            public string VideoLink { get; set; }
            public string HeadLine { get; set; }
            public string NewsDescription { get; set; }
            public DateTime? PublishDate { get; set; }    

        }

       
        public List<CommunityNew> GetNewsType(long IID)
        {
            try
            {

                List<CommunityNew> communityNewColl = (from ci in _OiiOMartDBDataContext.CommunityNews
                                                       where ci.IsRemoved == false &&
                                                       ci.IID == IID 
                                                       select ci).OrderByDescending(x => x.IID).ToList();

                return communityNewColl;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public object GetAllDetailByNewsTypeIID(Int64? newsTypeIID)
        {
            try
            {
                var objNewsType = (from ci in _OiiOMartDBDataContext.CommunityNews
                                   where ci.IsRemoved == false &&
                                   ci.IID == newsTypeIID
                                   select ci).SingleOrDefault();

                var newsList = (from ci in _OiiOMartDBDataContext.CommunityNews
                                where ci.IsRemoved == false &&
                                ci.NewsTypeID == (objNewsType != null ? objNewsType.NewsTypeID : default(int))
                                select ci).ToList();
                return newsList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public CommunityNew GetCommunityNewsByIID(long IID)
        {
            try
            {
                CommunityNew CommunityNewID = _OiiOMartDBDataContext.CommunityNews.SingleOrDefault(d => d.IID == IID);
                //_OiiOMartDBDataContext.Dispose();
                return CommunityNewID;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }



       
    }
}