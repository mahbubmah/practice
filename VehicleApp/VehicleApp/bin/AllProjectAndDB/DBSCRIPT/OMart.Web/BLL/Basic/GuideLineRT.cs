using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace BLL.Basic
{
    public class GuideLineRT : IDisposable
    {
        private readonly OiiOMartDBDataContext _OiiOMartDBDataContext;
        public GuideLineRT()
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

        public List<GuideLineDetail> GetAllDetailByGuidLineIID(Int64 IID)
        {
            List<GuideLineDetail> featureList = new List<GuideLineDetail>();
            try
            {
                featureList = _OiiOMartDBDataContext.GuideLineDetails.Where(d => d.GuideLineID == IID && d.IsRemoved == false).ToList();
                return featureList;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    
        #region IDisposable Members
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members

        public List<GuideType> GetAllGuideType()
        {
            try
            {
                List<GuideType> _GuideType = new List<GuideType>();
                var guideTypeList = _OiiOMartDBDataContext.SP_SP_GetAllGuideType().ToList();
                foreach (var guideType in guideTypeList)
                {
                    var guideTypeDisplay = new GuideType();
                    guideTypeDisplay.IID = guideType.IID;
                    guideTypeDisplay.GuideTypeTitle = guideType.GuideTypeTitle;
                    guideTypeDisplay.GuideTypeDescription = guideType.GuideTypeDescription;
                    guideTypeDisplay.GuideTypeImage = guideType.GuideTypeImage;
                    //switch (guideType.IID) Comment By hasan 2015.05.04
                    switch (guideType.GuideTypeBusinessTypeID)
                    {
                        case 1:
                            guideTypeDisplay.BussinessTypeName = "Energy Guides";
                            break;
                        case 2:
                            guideTypeDisplay.BussinessTypeName = "Banking Guides";
                            break;
                        case 3:
                            guideTypeDisplay.BussinessTypeName = "Travel Guides";
                            break;
                        case 4:
                            guideTypeDisplay.BussinessTypeName = "Insurance Guides";
                            break;
                        case 5:
                            guideTypeDisplay.BussinessTypeName = "Shopping Guides";
                            break;
 		                case 6:
                            guideTypeDisplay.BussinessTypeName = "Mobile Guides";
                            break;
                        case 7:
                            guideTypeDisplay.BussinessTypeName = "Network Provider";
                            break;
                        case 8:
                            guideTypeDisplay.BussinessTypeName = "BroadBand Guides";
                            break;
 		                case 9:
                            guideTypeDisplay.BussinessTypeName = "News Community";
                            break;
                        case 10:
                            guideTypeDisplay.BussinessTypeName = "Construction";
                            break;
                        case 11:
                            guideTypeDisplay.BussinessTypeName = "Medicine Guides";
                            break;
                    }

                   _GuideType.Add(guideTypeDisplay);
                }
                return _GuideType ;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

        }
    
        public class GuideType
        {
            public Int64 IID { get; set; }
            public string BussinessTypeName { get; set; }
            public string GuideTypeTitle { get; set; }
            public string GuideTypeDescription { get; set; }

            public string GuideTypeImage { get; set; }
        }



        //public GuideType GetBankingGuidesAllType(Int64 guideIID)
        //{
        //    try
        //    {
        //        GuideType objGT = new GuideType();
        //        var obj = (from tr in _OiiOMartDBDataContext.SP_SP_GetAllGuideType()
        //                           where tr.GuideTypeBusinessTypeID == guideIID
        //                           select tr).First();
        //       // foreach(GuideType obj in objGT){}
        //        if (obj != null) {
        //            objGT.IID = obj.GuideTypeBusinessTypeID;
        //            objGT.BussinessTypeName = "Banking Guides";
        //            objGT.GuideTypeTitle = obj.GuideTypeTitle;
        //            objGT.GuideTypeDescription = obj.GuideTypeDescription;
        //            objGT.GuideTypeImage = obj.GuideTypeImage;
                   
        //        }

        //        return objGT;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }

        //}
        public GuideType GetOneGuidesAllType(Int64 guideIID)
        {
            try
            {
                GuideType objGT = (from tr in GetAllGuideType()
                                   where tr.IID == guideIID
                                   select tr).SingleOrDefault();

                return objGT;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        /// <summary>
        /// Hasan Add 2015.04.22 
        /// </summary>
        /// <param name="businessTypeID"></param>
        /// <returns></returns>
        public List <GuideLine> GetAllrowsForBusinessTypeID( int businessTypeID)
        {
            try
            { 
                IEnumerable<GuideLine> guides = _OiiOMartDBDataContext.ExecuteQuery<GuideLine>(@"SELECT  top 4 IID,
                                                                                               BusinessTypeID,
                                                                                               ISNULL (Title,' ')AS Title , 
                                                                                               ISNULL ([Description],'') AS [Description], 
                                                                                               ImageUrl
                                                                                               FROM [GuideLine]
                                                                                               WHERE BusinessTypeID=" + businessTypeID + "AND IsRemoved=0" + "ORDER BY newid()"); 
                return guides.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public List<SP_GetAllRandomGuideLineRowsByBusenessTypeIDResult> GetRandomGuideLineByBusinessTypeID(int BusinessTypeID)
        {
            try
            {
                var spResult = _OiiOMartDBDataContext.SP_GetAllRandomGuideLineRowsByBusenessTypeID(BusinessTypeID);
                return spResult.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// Hasan Add 2015.05.04
        /// </summary>
        /// <param name="guideLineDetailID"></param>
        /// <returns></returns>

        public string GetTitleByGuideLineDetailsIID(long guideLineDetailID )
        {
            try
            {
                var title = _OiiOMartDBDataContext.GuideLineDetails.FirstOrDefault(x => x.IsRemoved == false && x.IID == guideLineDetailID).Title;

                return title;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        public List <GuideLineDetailMore> GetAllGuideLineMoreDetailsByGuideLineDetailID(long guideLineDetailID  )
        {
            try
            {
                var result = _OiiOMartDBDataContext.GuideLineDetailMores.Where(m => m.GuideLineDetailID == guideLineDetailID && m.IsRemoved == false);
                return result.ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// Hasan Add 2015.05.05
        /// </summary>
        /// <param name="IID"></param>
        /// <param name="startRowIndex"></param>
        /// <param name="maxRowNumber"></param>
        /// <returns></returns>
        public List<GuideLineDetail> GetSortedAllGuileDetailByGuidLineIID (Int64 IID ,int startRowIndex, int maxRowNumber)
        {
            List<GuideLineDetail> featureList = new List<GuideLineDetail>();
            try
            {
                featureList = _OiiOMartDBDataContext.GuideLineDetails.Where(d => d.GuideLineID == IID && d.IsRemoved == false).ToList();
                return featureList;
            }
            catch (Exception ex)
            {
                return null;
            }

        }




        //public List<GuideType> GetTypesAll(long IID)
        //{
        //    try
        //    {
        //        List<GuideType> objGT = (from tr in GetAllGuideType()
        //                           where tr.IID == IID 
        //                           select tr).ToList();

        //        return objGT;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }

        //}

    }
}
