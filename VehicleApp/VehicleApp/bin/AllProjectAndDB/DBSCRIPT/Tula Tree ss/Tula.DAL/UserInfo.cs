//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tula.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserInfo
    {
        public long IID { get; set; }
        public int UserGroupID { get; set; }
        public string LoginName { get; set; }
        public string LoginPassword { get; set; }
        public string Salt { get; set; }
        public Nullable<long> AdGiverID { get; set; }
        public Nullable<bool> IsActiveUser { get; set; }
        public long CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public bool IsRemoved { get; set; }
        public Nullable<int> LeavingCausesID { get; set; }
        public string Comments { get; set; }
        public Nullable<bool> IsEmail { get; set; }
        public Nullable<bool> IsSMS { get; set; }
    
        public virtual UserGroup UserGroup { get; set; }
    }
}
