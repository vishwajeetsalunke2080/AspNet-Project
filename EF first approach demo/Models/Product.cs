using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EF_first_approach_demo.Models
{
    public class Product
    {
        [Key]
        [Display(Name = "Product ID")]
        public long ProductID { get; set; }


        [Required]
        [RegularExpression(@"^[A-Za-z0-9 ]*$", ErrorMessage ="Alphabets Only")]
        [Display(Name = "Product Name")]
        [MaxLength(40, ErrorMessage ="Name should be within 40 characters")]
        [MinLength(2,ErrorMessage ="Name should be at least 2 characters long")]
        public string ProductName { get; set; }


        [Required]
        [Range(0,1000000, ErrorMessage ="Price should be less than 10,00,000")]
        [RegularExpression(@"^[0-9.]*$", ErrorMessage = "Invalid input only numbers accepted")]
        public Nullable<decimal> Price { get; set; }

        [Required]
        [Display(Name = "Invoice Date")]
        public Nullable<System.DateTime> DateOfPurchase { get; set; }


        [Display(Name = "Availability Status")]
        public string AvailabilityStatus { get; set; }

        [Required]
        [Display(Name = "Brand ID")]
        public long BrandID { get; set; }

        [Required]
        [Display(Name = "Category ID")]
        public long CategoryID { get; set; }
        
        public Nullable<bool> Active { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+$",ErrorMessage ="Invalid input only numbers accepted")]
        public Nullable<decimal> Quantity {  get; set; }
        
        public string Photo { get ; set; }

        public virtual Brand Brand {get; set;}
        public virtual Category Category { get; set; }

    }
}