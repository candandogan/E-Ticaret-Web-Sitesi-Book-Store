using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Genre
    {
        
        [Display(Name = "ID")]
        public int GenreId { get; set; }

        [Required(ErrorMessage = "İSİM ALANI BOŞ GEÇİLEMEZ.")]
        [Display(Name = "Ad")]
        public string Name { get; set; }

        public IList<GenreBook> GenreBooks { get; set; }

    }
}
