using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Basic
{
    public class NewsExtract : AllNews
    {
        int breakdownName;

        public int BreakdownName
        {
            get { return breakdownName; }
            set { breakdownName = value; }
        }


    }
}
