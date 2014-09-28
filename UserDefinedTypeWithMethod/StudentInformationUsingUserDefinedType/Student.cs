using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInformationUsingUserDefinedType
{
    class Student
    {
        public string regNo;
        public string firstName;
        public string lastName;

        public string GetFullName()
        {
            string fullName = firstName + " " + lastName;
            return fullName;
        }

    }
}
