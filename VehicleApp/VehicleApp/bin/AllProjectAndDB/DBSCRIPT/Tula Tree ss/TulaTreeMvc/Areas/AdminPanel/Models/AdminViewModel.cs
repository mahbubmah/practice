using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Razor.Editor;
using System.Web.UI.WebControls;

namespace TulaTreeMvc.Areas.AdminPanel.Models
{
    public class AdminViewModel
    {
    }

    public class ColorViewModel
    {
        [Display(Name = "Color code")]
        public string Code { get; set; }

        [Display(Name = "Color name")]
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }
        [Display(Name = "Is Removed")]
        public bool IsRemoved { get; set; }

      }

    public class BrandViewModel
    {
        [Display(Name = "Eastblish year")]
        public int? EastblishYear { get; set; }

        [Display(Name = "Origin")]
        public int? Origin { get; set; }

        [Display(Name = "Brand name")]
        public string Name { get; set; }

        [Display(Name = "Is Removed")]
        public bool IsRemoved { get; set; }

    }

    public class CountryViewModel
    {
     
       
        [Required(ErrorMessage = "Please Enter Code")]
        public string Code { get; set; }

        [Display(Name = "Country name")]
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }

        [Display(Name = "ISD Code")]
        public string ISDCode { get; set; }

        [Display(Name = "Is Removed")]
        public bool IsRemoved { get; set; }

    }

    public class PostOfficeViewModel
    {
        [Display(Name = "Select country")]
        [Required(ErrorMessage = "Please select country"), Range(1, Int32.MaxValue)]
        public int CountryID  { get; set; }

        [Required(ErrorMessage = "Please select division/state"), Range(1, Int64.MaxValue, ErrorMessage = "Please select division/state")]
        [Display(Name = "Select Division/State")]
        public long DivisionOrStateID { get;set; }

        [Display(Name = "Select district")]
        [Required(ErrorMessage = "Please select district"), Range(1, Int64.MaxValue, ErrorMessage = "Please select district")]
        public long DistrictID { get; set; }

        [Display(Name = "Select police station")]
        [Required(ErrorMessage = "Please select police station"), Range(1, Int64.MaxValue, ErrorMessage = "Please select police station")]
        public long PoliceStationID { get; set; }

        [Display(Name = "Post office name")]
        public string Name { get; set; }

        [Display(Name = "Post code")]
        [Required(ErrorMessage = "Please enter code")]
        public string Code { get; set; }


        [Display(Name = "Is Removed?")]
        public bool IsRemoved { get; set; }
    }
}