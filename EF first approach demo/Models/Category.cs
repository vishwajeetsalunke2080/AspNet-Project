using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EF_first_approach_demo.Models
{
    public class Category
    {
        [Key]
        [Display(Name = "Category ID")]
        public long CategoryID { get; set; }
        [Display(Name ="Category Name")]
        public string CategoryName { get; set; }
    }
}