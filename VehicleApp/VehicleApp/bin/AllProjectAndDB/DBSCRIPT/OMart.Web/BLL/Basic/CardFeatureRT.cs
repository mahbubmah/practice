using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Basic
{
    public class CardFeatureRT:IDisposable
    {
         private readonly OiiOMartDBDataContext dbContext;
         public CardFeatureRT()
        {
            dbContext = DatabaseHelper.GetDataModelDataContext();
        }

        
        #region IDisposable Members
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members

        public object GetCardFeatureForListView()
        {
            try
            {
                var cardFeatureList = from cf in dbContext.CardFeatures
                    join ci in dbContext.CardInfos on cf.CardInfoID equals ci.IID
                    where cf.IsRemoved == false
                    select new
                    {
                        cf.IID,
                        cf.Description,
                        CardInfo = ci.Name
                    };
                return cardFeatureList;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message,ex);
            }
        }


        public void UpdateCardFeature(CardFeature cardFeature)
        {
            try
            {

                CardFeature cardFea = dbContext.CardFeatures.Single(d => d.IID == cardFeature.IID);
                DatabaseHelper.Update<CardFeature>(dbContext, cardFeature, cardFea);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public CardFeature GetCardFeatureByID(long cardFeatureId)
        {
            try
            {
              var  cardFeature = dbContext.CardFeatures.Single(d => d.IID == cardFeatureId);
                return cardFeature;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<CardFeature> GetAllCardFeaturesByCardInfoId(long cardInfoId)
        {
            try
            {
                var cardFeatureList = dbContext.CardFeatures.Where(x=>x.CardInfoID==cardInfoId && x.IsRemoved==false).ToList();
                return cardFeatureList;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message,ex);
            }
        }

        public List<CardInfo> GetAllCardInfo()
        {
            try
            {
                var cardInfoList = dbContext.CardInfos.ToList();
                return cardInfoList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }


        public void AddCardFeature(CardFeature cardFeature)
        {
            try
            {
                DatabaseHelper.Insert<CardFeature>(cardFeature);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void DeleteCardFeatureById(long cardFeatureId)
        {
            try
            {
                CardFeature cardFeature = dbContext.CardFeatures.SingleOrDefault(x => x.IID == cardFeatureId);
                DatabaseHelper.Delete(dbContext, cardFeature);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
    }
}
