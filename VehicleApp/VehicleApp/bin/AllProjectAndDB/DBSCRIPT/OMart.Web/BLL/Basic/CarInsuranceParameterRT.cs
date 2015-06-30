using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL.Basic
{
    public class CarInsuranceParameterRT : IDisposable
    {
        //private readonly OiiOMartDBDataContext _OiiOMartDBDataContext=new OiiOMartDBDataContext();
        private readonly OiiOMartDBDataContext _OiiOMartDBDataContext;
        public CarInsuranceParameterRT()
        {
            _OiiOMartDBDataContext = DatabaseHelper.GetDataModelDataContext();
        }



        public void AddCarInsuranceParameter(CarInsuranceParameter CarInsuranceParameterObj)
        {
            try
            {
                OiiOMartDBDataContext ob = DatabaseHelper.GetDataModelDataContext();
                DatabaseHelper.Insert<CarInsuranceParameter>(CarInsuranceParameterObj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void UpdateCarInsuranceParameter(CarInsuranceParameter CarInsuranceParameterObj)
        {
            try
            {
                CarInsuranceParameter CarInsuranceParameterObjNew = _OiiOMartDBDataContext.CarInsuranceParameters.SingleOrDefault(d => d.IID == CarInsuranceParameterObj.IID);

                DatabaseHelper.Update<CarInsuranceParameter>(_OiiOMartDBDataContext, CarInsuranceParameterObj, CarInsuranceParameterObjNew);
                _OiiOMartDBDataContext.Dispose();

                //_OiiOMartDBDataContext.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        public CarInsuranceParameter GetCarInsuranceParameterByIID(int CarInsuranceParameterID)
        {
            try
            {
                CarInsuranceParameter CarInsuranceParameterObj = _OiiOMartDBDataContext.CarInsuranceParameters.SingleOrDefault(d => d.IID == CarInsuranceParameterID);
                //_OiiOMartDBDataContext.Dispose();
                return CarInsuranceParameterObj;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        //public CarInsuranceParameter GetCarInsuranceParameterName(string conName)
        //{
        //    try
        //    {

        //        var CarInsuranceParameterObj = (from tr in _OiiOMartDBDataContext.CarInsuranceParameters
        //                              where tr.Name == conName
        //                              select tr).SingleOrDefault();
        //        return CarInsuranceParameterObj;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }
        //}
        public List<CarInsuranceParameter> GetAllCarInsuranceParameter()
        {
            try
            {
                List<CarInsuranceParameter> Countries = _OiiOMartDBDataContext.CarInsuranceParameters.ToList();
                return Countries;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<CarInsuranceParameter> SearchCarInsuranceParameter1(CarInsuranceParameter objCarInsuranceParameter)
        {

            try
            {
                var carInsuPar = (from x in _OiiOMartDBDataContext.CarInsuranceParameters
                                  where x.CarTypeID == objCarInsuranceParameter.CarTypeID
                                      && x.CarConditionID == objCarInsuranceParameter.CarConditionID && x.MinCarValueAmount >= objCarInsuranceParameter.MinCarValueAmount
                                      && x.MaxCarValueAmount <= objCarInsuranceParameter.MaxCarValueAmount
                                  select x).ToList();
                return carInsuPar;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public List<CarInsuranceParameter> SearchCarInsuranceParameter2(CarInsuranceParameter objCarInsuranceParameter)
        {

            try
            {
                var carInsuPar = (from x in _OiiOMartDBDataContext.CarInsuranceParameters
                                  where x.CarTypeID == objCarInsuranceParameter.CarTypeID
                                      && x.CarConditionID == objCarInsuranceParameter.CarConditionID && x.MinCarValueAmount >= objCarInsuranceParameter.MinCarValueAmount

                                  select x).ToList();
                return carInsuPar;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public List<CarInsuranceParameter> SearchCarInsuranceParameter3(CarInsuranceParameter objCarInsuranceParameter)
        {

            try
            {
                var carInsuPar = (from x in _OiiOMartDBDataContext.CarInsuranceParameters
                                  where x.CarTypeID == objCarInsuranceParameter.CarTypeID
                                      && x.CarConditionID == objCarInsuranceParameter.CarConditionID
                                      && x.MaxCarValueAmount <= objCarInsuranceParameter.MaxCarValueAmount
                                  select x).ToList();
                return carInsuPar;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public List<CarInsuranceParameter> SearchCarInsuranceParameter4(CarInsuranceParameter objCarInsuranceParameter)
        {

            try
            {
                var carInsuPar = (from x in _OiiOMartDBDataContext.CarInsuranceParameters
                                  where x.CarTypeID == objCarInsuranceParameter.CarTypeID
                                      && x.CarConditionID == objCarInsuranceParameter.CarConditionID
                                  select x).ToList();
                return carInsuPar;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        //public List<CardPurchase> GetCardPurchaseName(string conName)
        //{
        //    try
        //    {
        //        var cardPurchase = (from tr in _OiiOMartDBDataContext.CardPurchases.OrderBy(x => x.Name)
        //                         where tr.Name.StartsWith(conName)
        //                         select tr).ToList();
        //        return cardPurchase;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }
        //}

        public object GetAllCarInsuranceParameterForListView()
        {
            var carInsuranceParameter = from obj in _OiiOMartDBDataContext.CarInsuranceParameters
                                        select new { obj.CarConditionID, obj.CarTypeID, obj.Duration, obj.IID, obj.IsRemoved, obj.MaxCarAge, obj.MaxCarValueAmount, obj.MaxRun, obj.MinCarAge, obj.MinCarValueAmount, obj.MinRun, obj.PremiumTotalPercent }; //diviionOrState.Name

            return carInsuranceParameter;
        }
        public string BindForSearchResult(int id)
        {
            try
            {
                CarInsuranceParameter carInsuPar =  _OiiOMartDBDataContext.CarInsuranceParameters.SingleOrDefault(d => d.IID == id);
                string st = Enum.GetName(typeof(Utilities.EnumCollection.CarType), carInsuPar.CarTypeID) + ", " +
                    Enum.GetName(typeof(Utilities.EnumCollection.CarCondition), carInsuPar.CarConditionID) + ", " +
                    carInsuPar.MinCarValueAmount.ToString() + ", " + carInsuPar.MaxCarValueAmount.ToString();

                return st;
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





    }
}


