using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Brand
    {
        [Display(Name = "ID")]
        public int BrandId { get; set; }
        [Required(ErrorMessage = "İSİM ALANI BOŞ GEÇİLEMEZ.")]
        [Display(Name = "Ad")]
        public string Name { get; set; }

        public IList<Book> Book { get; set; }
      
    }
}
