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
    
    public partial class SP_GetAllLatestAds_Result
    {
        public long IID { get; set; }
        public string Code { get; set; }
        public string TitleName { get; set; }
        public string Description { get; set; }
        public Nullable<long> AdGiverID { get; set; }
        public string AdDate { get; set; }
        public Nullable<System.DateTime> AdDisplayLastDate { get; set; }
        public int CategoryID { get; set; }
        public decimal Price { get; set; }
        public Nullable<int> TotalVisitor { get; set; }
        public string CurrentLocation { get; set; }
        public string CategoryName { get; set; }
        public string ModelName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public string ColorCode { get; set; }
        public string ImageUrl { get; set; }
        public Nullable<bool> IsExpired { get; set; }
        public Nullable<bool> IsFeatured { get; set; }
        public Nullable<bool> IsSpotlight { get; set; }
        public Nullable<bool> IsUrgent { get; set; }
    }
}
