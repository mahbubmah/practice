using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Basic
{
   public class CompanyInformation
    {
        public Int64 IID { get; set; }

        public string Name { get; set; }
        public string OriginCountryName { get; set; }
        public string BussinessDescription { get; set; }
        public string Address { get; set; }
        public string WebAddress { get; set; }
        public Int32 BussinessTypeID { get; set; }
        public Int32 TotalCountryBussCover { get; set; }
        public bool IsRemoved { get; set; }
     
    }
}
