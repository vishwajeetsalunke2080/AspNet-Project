using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EF_first_approach_demo.Models
{
    public class Brand
    {
        [Key]
        [Display(Name = "Brand ID")]
        public long BrandID { get; set; }
        [Display(Name = "Brand Name")]
        public string BrandName { get; set; }
    }
}