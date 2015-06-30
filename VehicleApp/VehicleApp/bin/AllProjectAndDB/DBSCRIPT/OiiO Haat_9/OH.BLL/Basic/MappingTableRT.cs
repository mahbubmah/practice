using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using OH.DAL;


namespace OH.BLL.Basic
{
    public class MappingTableRT : IDisposable
    {
        public MappingTableRT()
        {
        }

        #region Get methods

        public MappingTable GetMappingByIID(int mappingID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                MappingTable mappingTable = new MappingTable();
                mappingTable = dbContext.MappingTables.Single(d => d.IID == mappingID && d.IsRemoved == false);
                dbContext.Dispose();
                return mappingTable;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<MappingTable> GetMappingTableAll()
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<MappingTable> mappingTableList = new List<MappingTable>();
                mappingTableList = dbContext.MappingTables.Where(d => d.IsRemoved == false).ToList();
                dbContext.Dispose();
                return mappingTableList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }


        public List<MappingTable> GetAllMappingTableForListView()
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();

                List<MappingTable> mappingTables = dbContext.MappingTables.Where(C => C.IsRemoved == false).ToList();
                //dbContext.Dispose();
                return mappingTables;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public object GetMappingTableName(string mapName)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                //List<MappingTable> nameList = new List<MappingTable>();
                //nameList = dbContext.Countries.Where(c => c.IsRemoved == false && c.Name.StartsWith(conName)).ToList();
                ////dbContext.Dispose();
                var mappingTables = from mappingTableDB in dbContext.MappingTables select new { mappingTableDB.IID, mappingTableDB.Name };
                return mappingTables;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public bool IsMappingTableCodeExists(string mappingTableName)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<MappingTable> mappingTableList = new List<MappingTable>();
                mappingTableList = dbContext.MappingTables.Where(c => c.IsRemoved == false && c.Name.Contains(mappingTableName)).ToList();
                dbContext.Dispose();
                if (mappingTableList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public bool IsMappingTableNameExistOtherRows(int id, string name)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<MappingTable> mappingTableCodeList = new List<MappingTable>();
                mappingTableCodeList = dbContext.MappingTables.Where(c => c.IsRemoved == false && c.Name.Contains(name) && c.IID != id).ToList();
                dbContext.Dispose();
                if (mappingTableCodeList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
 
        }


        public bool IsMappingTableNameExists(string mappingTableName)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<MappingTable> mappingTableNameList = new List<MappingTable>();
                mappingTableNameList = dbContext.MappingTables.Where(c => c.IsRemoved == false && c.Name.Contains(mappingTableName)).ToList();
                dbContext.Dispose();
                if (mappingTableNameList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }


       
        public void AddMappingTable(MappingTable mappingTable)
        {
            try
            {
                DatabaseHelper.Insert<MappingTable>(mappingTable);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }


        public void UpdateMappingTable(MappingTable mappingTable)
        {
            try
            {
                // OiiOHRDataModelDataContext msDC = new OiiOHRDataModelDataContext();
                OiiOHaatDCDataContext msDC = DatabaseHelper.GetDataModelDataContext();

                MappingTable mappingTableNew = msDC.MappingTables.Single(d => d.IID == mappingTable.IID);
                DatabaseHelper.Update<MappingTable>(msDC, mappingTable, mappingTableNew);

                msDC.Dispose();
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        #endregion Get methods

        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members

        public string GetModelIDByName(int p)
        {
            try
            {
                string mappingName = string.Empty;
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                MappingTable mappingTable = new MappingTable();
                mappingTable = (from mapps in dbContext.MappingTables
                                 where mapps.IID == p
                                 select mapps).SingleOrDefault();
                if (mappingTable != null)
                {
                    mappingName = Convert.ToString(mappingTable.IID);
                }
                dbContext.Dispose();
                return mappingName;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }

           }
    }
}
