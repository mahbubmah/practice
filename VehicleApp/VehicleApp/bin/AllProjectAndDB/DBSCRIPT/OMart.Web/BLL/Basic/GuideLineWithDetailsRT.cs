using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Basic;


namespace BLL.Basic
{
    public class GuideLineWithDetailsRT : IDisposable
    {
        private readonly OiiOMartDBDataContext _OiiOMartDBDataContext;
        public GuideLineWithDetailsRT()
        {
            this._OiiOMartDBDataContext = DatabaseHelper.GetDataModelDataContext();
        }
        public object GetAllguideLineForDisplay()
        {
            try
            {
                var guideLine = _OiiOMartDBDataContext.GuideLines.Where(d => d.IsRemoved == false);
                return guideLine;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static int InsertGuideLineDetailChildXML(string objectXML)
        {
            try
            {
                return GuideLineDetailDA.InsertGuideLineDetailChildXML(objectXML);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        
        public GuideLine GetguideLineByIID(int guideLineID)
        {
            try
            {
                GuideLine loan = _OiiOMartDBDataContext.GuideLines.SingleOrDefault(d => d.IID == guideLineID);
               // _OiiOMartDBDataContext.Dispose();
                return loan;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

      
        public void UpdateguideLine(GuideLine guideLine)
        {
            try
            {
                GuideLine guideLineNew = _OiiOMartDBDataContext.GuideLines.SingleOrDefault(d => d.IID == guideLine.IID);
                DatabaseHelper.Update<GuideLine>(_OiiOMartDBDataContext, guideLine, guideLineNew);
                OiiOMartDBDataContext db = DatabaseHelper.GetDataModelDataContext();
                db.DeleteGuideLineDetailByLoanIID(guideLine.IID);
               // _OiiOMartDBDataContext.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public void UpdateguideLineAndGuideLineDetail(GuideLine guideLine, List<GuideLineDetail> featureList)
        {
            try
            {
                OiiOMartDBDataContext db = DatabaseHelper.GetDataModelDataContext();
                GuideLine guideLineNew = db.GuideLines.SingleOrDefault(d => d.IID == guideLine.IID);
                DatabaseHelper.Update<GuideLine>(db, guideLine, guideLineNew);
               
                //OiiOMartDBDataContext db = DatabaseHelper.GetDataModelDataContext();
                db.DeleteGuideLineDetailByGuideLineIID(guideLine.IID);
                db.Dispose();
                foreach (GuideLineDetail feature in featureList)
                {
                    feature.GuideLineID = guideLine.IID;
                    feature.IsRemoved = false;
                    DatabaseHelper.Insert<GuideLineDetail>(feature);
                }
                // _OiiOMartDBDataContext.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<GuideLineDetail> GetAllDetailByGuidLineIID(Int64? loanIID)
        {
            List<GuideLineDetail> featureList = new List<GuideLineDetail>();
            try
            {   
                featureList = _OiiOMartDBDataContext.GuideLineDetails.Where(d => d.GuideLineID == loanIID && d.IsRemoved==false).ToList();
               // _OiiOMartDBDataContext.Dispose();
                return featureList;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
     
        public List<GuideLine> GetAllGuideLine()
        {
            try
            {
                List<GuideLine> GuideLine = _OiiOMartDBDataContext.GuideLines.OrderBy(x => x.Title).ToList();
                return GuideLine;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public GuideLine GetGuideLineByIID(int GuideLineID)
        {
            try
            {
                GuideLine GuideLine = _OiiOMartDBDataContext.GuideLines.SingleOrDefault(d => d.IID == GuideLineID);
                //_OiiOMartDBDataContext.Dispose();
                return GuideLine;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public List<GuideLineDetail> GetAllGuideLineWithDetail()
        {
            try
            {
                List<GuideLineDetail> GuideLineWithDetail = _OiiOMartDBDataContext.GuideLineDetails.OrderBy(x => x.Title).ToList();
                return GuideLineWithDetail;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public GuideLineDetail GetGuideLineWithDetailsByIID(int GuideLineWithDetailID)
        {
            try
            {
                GuideLineDetail GuideLinedetail = _OiiOMartDBDataContext.GuideLineDetails.SingleOrDefault(d => d.IID == GuideLineWithDetailID);
                //_OiiOMartDBDataContext.Dispose();
                return GuideLinedetail;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void AddguideLineAndFeature(GuideLine guideLine,List<GuideLineDetail> featureList)
        {
            try
            {
                DatabaseHelper.Insert<GuideLine>(guideLine);
                foreach(GuideLineDetail feature in featureList)
                {
                    feature.GuideLineID = guideLine.IID;
                    DatabaseHelper.Insert<GuideLineDetail>(feature);
                }
            }
            catch (Exception ex)
            { throw new Exception(ex.Message, ex); }
        
        }
    
        #region IDisposable Members
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members


        #region Author: Asiful Islam
        public void UpdateGuidelinedetail(GuideLineDetail Guidelinedetail)
        {
            try
            {

                GuideLineDetail GuidelineDetailIn = _OiiOMartDBDataContext.GuideLineDetails.Single(d => d.IID == Guidelinedetail.IID);
                DatabaseHelper.Update<GuideLineDetail>(_OiiOMartDBDataContext, Guidelinedetail, GuidelineDetailIn);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public static int InsertGuidelinedetailAndAllChildCardFeatuerXML(string GuidelinedetailWithAllChildCardFeatureXML)
        {
            try
            {
                return GuideLineDetailDA.InsertGuideLineDetailChildXML(GuidelinedetailWithAllChildCardFeatureXML);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<GuideLineDetailMore> GetAllGuidelinedetailMoreByGuidelinedetailId(long GuideLineDetailID)
        {
            try
            {
                var GuideLineDetailMoreList = _OiiOMartDBDataContext.GuideLineDetailMores.Where(x => x.GuideLineDetailID == GuideLineDetailID && x.IsRemoved == false).ToList();
                return GuideLineDetailMoreList;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public void UpdateGuidelinedetailMore(GuideLineDetailMore Guidelinedetailmore)
        {
            try
            {

                GuideLineDetailMore cardFea = _OiiOMartDBDataContext.GuideLineDetailMores.Single(d => d.IID == Guidelinedetailmore.IID);
                DatabaseHelper.Update<GuideLineDetailMore>(_OiiOMartDBDataContext, Guidelinedetailmore, cardFea);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void AddGuidelinedetailmore(GuideLineDetailMore Guidelinedetailmore)
        {
            try
            {
                DatabaseHelper.Insert<GuideLineDetailMore>(Guidelinedetailmore);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public object GetguideLineDetailForListView()
        {
            try
            {

                var guideLineDetailList = from gLD in _OiiOMartDBDataContext.GuideLineDetails
                                          join gL in _OiiOMartDBDataContext.GuideLines on gLD.GuideLineID equals gL.IID
                                   where gLD.IsRemoved == false
                                   select new
                                   {
                                       gLD.IID,
                                       guideLine = gL.Title,
                                       gLD.Description,
                                       GuideLineDetail=gLD.Title,
                                       gLD.ImageUrl,
                                       gLD.IsRemoved,
                                     
                                   };

                return guideLineDetailList;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }



        public GuideLineDetail GetGuideLineDetailsByIID(long GuideLineDetailID)
        {
            try
            {
                var guidelineDetail = _OiiOMartDBDataContext.GuideLineDetails.Single(d => d.IID == GuideLineDetailID);
                return guidelineDetail;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public static int InsertGuidelinedetailAndDetailMoreXML(string GuidelinedetailWithAllChildCardFeatureXML)
        {
            try
            {
                return GuideLineDetailDA.InsertGuidelinedetailAndAllFreatureChildXML(GuidelinedetailWithAllChildCardFeatureXML);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void UpdateGuidelinedetailMore(GuideLineDetail Guidelinedetail, List<GuideLineDetailMore> GuideLineDetailMoreList)
        {
            try
            {
                GuideLineDetail guidelinedetail = _OiiOMartDBDataContext.GuideLineDetails.Single(d => d.IID == Guidelinedetail.IID);
                DatabaseHelper.Update<GuideLineDetail>(_OiiOMartDBDataContext, Guidelinedetail, guidelinedetail);

                _OiiOMartDBDataContext.UpadateInterestRateTypeByMortgageID(Guidelinedetail.IID);
                _OiiOMartDBDataContext.Dispose();

                foreach (GuideLineDetailMore rate in GuideLineDetailMoreList)
                {
                    rate.GuideLineDetailID = Guidelinedetail.IID;
                    DatabaseHelper.Insert<GuideLineDetailMore>(rate);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public object GetguideLineDetailMoreForListView()
        {
            try
            {

                var guideLineDetailList = from gLDM in _OiiOMartDBDataContext.GuideLineDetailMores
                                          join gLD in _OiiOMartDBDataContext.GuideLineDetails on gLDM.GuideLineDetailID equals gLD.IID
                                          where gLDM.IsRemoved == false
                                          select new
                                          {
                                              gLDM.IID,
                                              guideLineDetail = gLD.Title,
                                              gLDM.Description,
                                              GuideLineDetailMore = gLDM.Title,
                                              gLDM.ImageUrl,
                                              gLDM.IsRemoved,

                                          };

                return guideLineDetailList;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public GuideLineDetailMore GetGuideLineDetailsMoreByIID(long GuideLineDetailMoreID)
        {
            try
            {
                var guidelineDetail = _OiiOMartDBDataContext.GuideLineDetailMores.Single(d => d.IID == GuideLineDetailMoreID);
                return guidelineDetail;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public bool IsExistGuideLineDetailMoreByTitle(string GuideLineDetailMoreTitle)
        {
            try
            {
                var guideLinedetail = _OiiOMartDBDataContext.GuideLineDetailMores.Where(d => d.Title == GuideLineDetailMoreTitle).ToList();
                if (guideLinedetail.Count > 0)
                    return true;
                else return false;             
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        #endregion
    }
}
