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
    
    public partial class Country
    {
        public Country()
        {
            this.Brands = new HashSet<Brand>();
            this.Districts = new HashSet<District>();
            this.DivisionOrStates = new HashSet<DivisionOrState>();
            this.Locations = new HashSet<Location>();
            this.PoliceStations = new HashSet<PoliceStation>();
            this.PostOffices = new HashSet<PostOffice>();
        }
    
        public int IID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ISDCode { get; set; }
        public long CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public bool IsRemoved { get; set; }
    
        public virtual ICollection<Brand> Brands { get; set; }
        public virtual ICollection<District> Districts { get; set; }
        public virtual ICollection<DivisionOrState> DivisionOrStates { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<PoliceStation> PoliceStations { get; set; }
        public virtual ICollection<PostOffice> PostOffices { get; set; }
    }
}
