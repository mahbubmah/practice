using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication4
{
    class StudentInfo
    {
        public string regNo;
        public string fistName;
        public string lastName;

        public string GetFullName()

        {
            return fistName + " " + lastName;
            
         
        }
    }

   
}
