using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Language
    {
        [Display(Name = "ID")]
        public int LanguageId { get; set; }
        [Required(ErrorMessage = "İSİM ALANI BOŞ GEÇİLEMEZ.")]
        [Display(Name = "Ad")]
        public string Name { get; set; }
        public IList<Book> Book { get; set; }
       
    }
}
