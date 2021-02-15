using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class AuthorBook
    {
        
        [Display(Name = "KİTAP")]
        public int BookId { get; set; }
        public Book Book { get; set; }

        
        [Display(Name = "YAZAR")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
