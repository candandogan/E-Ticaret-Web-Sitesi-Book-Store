using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Author
    {

        
        [Display(Name = "ID")]
        public int AuthorId { get; set; }
        [Required(ErrorMessage = "İSİM ALANI BOŞ GEÇİLEMEZ.")]
        [Display(Name = "Ad")]
        public string Name { get; set; }
        [Required(ErrorMessage = "SOYAD ALANI BOŞ GEÇİLEMEZ.")]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }

        public IList<AuthorBook> AuthorBooks { get; set; }


    }
}
