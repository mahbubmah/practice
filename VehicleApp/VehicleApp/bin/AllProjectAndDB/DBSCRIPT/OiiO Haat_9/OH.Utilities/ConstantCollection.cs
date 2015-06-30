using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OH.Utilities
{
    public class ConstantCollection
    {
        public const string LOGINUSERID = "LoginUserID";
        public const string LOGINUSERNAME = "LoginUserName";

        public string noImageUrl
        {
            get { return "App_Themes/Default/images/interface/no-picture.png"; }
        }
    }
}
