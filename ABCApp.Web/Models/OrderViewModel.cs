using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ABCApp.Web.Models
{
    public class OrderViewModel
    {
        
        //
        [Required(ErrorMessage = "Customer Name Required")]
        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Country Required")]
        [DisplayName("Country")]
        public IList<SelectListItem> Countries { get; set; }
        [Required(ErrorMessage = "Region Required")]
        [DisplayName("Region")]
        public IList<SelectListItem> Regions { get; set; }

        //public IList<SelectListItem> Cities { get; set; }

       // public IList<SelectListItem> Products { get; set; }
        public int Quantity { get; set; }



    }
}
