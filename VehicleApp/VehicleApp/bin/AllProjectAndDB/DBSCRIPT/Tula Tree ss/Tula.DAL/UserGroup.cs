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
    
    public partial class UserGroup
    {
        public UserGroup()
        {
            this.UserInfoes = new HashSet<UserInfo>();
            this.UserWFPermissions = new HashSet<UserWFPermission>();
        }
    
        public int IID { get; set; }
        public string Name { get; set; }
        public Nullable<int> TypeID { get; set; }
        public long CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public bool IsRemoved { get; set; }
    
        public virtual ICollection<UserInfo> UserInfoes { get; set; }
        public virtual ICollection<UserWFPermission> UserWFPermissions { get; set; }
    }
}
