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
    
    public partial class CMSContent
    {
        public int IID { get; set; }
        public int CMSTypeID { get; set; }
        public string Title { get; set; }
        public string CMSDescription { get; set; }
        public string ImageUrl { get; set; }
        public long CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
