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
    
    public partial class AdGiverTracing
    {
        public long IID { get; set; }
        public long AdGiverID { get; set; }
        public Nullable<long> MaterialID { get; set; }
        public string IPAddress { get; set; }
        public string MACAddress { get; set; }
        public Nullable<int> BrowserNameID { get; set; }
        public string BrowsingTimeDuration { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public bool IsRemoved { get; set; }
    }
}
