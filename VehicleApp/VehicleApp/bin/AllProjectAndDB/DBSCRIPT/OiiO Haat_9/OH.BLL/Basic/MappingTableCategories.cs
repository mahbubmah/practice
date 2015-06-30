using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class MappingTableCategories
    {
        public Int64 IID { get; set; }
      
        public string CategoryName { get; set; }
        public Int32 CategoryID { get; set; }
        public string MappingTableName { get; set; }
        public string MappingTableDescription { get; set; }
     
    }
}

