using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class GenreBook
    {
        
        [Display(Name = "Kitap")]
        public int BookId { get; set; }
        public Book Book { get; set; }

      
        [Display(Name = "Tür")]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
