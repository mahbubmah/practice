using OB.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OB.BLL.Basic
{
    public class BookOrderRT:IDisposable
    {
     private readonly OiiOBookDCDataContext _OiiOBookDCDataContext;
        public BookOrderRT()
        {
            this._OiiOBookDCDataContext = DatabaseHelper.GetDataModelDataContext();
        }

        public void AddBookOrder(BookOrder BookOrder)
        {
            try
            {
                DatabaseHelper.Insert<BookOrder>(BookOrder);
            }
            catch (Exception ex) 
            { throw new Exception(ex.Message, ex); }
        }

        public void UpdateBookOrder(BookOrder BookOrder)
        {
            try
            {
                BookOrder BookOrderNew = _OiiOBookDCDataContext.BookOrders.SingleOrDefault(d => d.IID == BookOrder.IID);

                DatabaseHelper.Update<BookOrder>(_OiiOBookDCDataContext, BookOrder, BookOrderNew);

                //_OiiOBookDCDataContext.Dispose();
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message, ex); 
            }
        }

        public BookOrder GetBookOrderByIID(Int64 BookOrderID)
        {
            try
            {
                BookOrder BookOrder = _OiiOBookDCDataContext.BookOrders.SingleOrDefault(d => d.IID == BookOrderID);
                //_OiiOBookDCDataContext.Dispose();
                return BookOrder;
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message, ex);
            }
        }

        //public List<BookOrder> GetBookOrderName(string Name)
        //{
        //    try
        //    {
        //        var BookOrders = (from tr in _OiiOBookDCDataContext.BookOrders.OrderBy(x => x.OrderName)
        //                         where tr.OrderName.StartsWith(Name)
        //                         select tr).ToList();
        //        return BookOrders;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }
        //}

        public List<BookOrder> GetAllBookOrders()
        {
            try
            {
                List<BookOrder> BookOrders = _OiiOBookDCDataContext.BookOrders.OrderBy(x=>x.IID).ToList();
                return BookOrders;
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
