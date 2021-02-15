using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Book
    {

        [Display(Name = "ID")]
        public int BookId { get; set; }
        [Required(ErrorMessage ="İSİM ALANI BOŞ GEÇİLEMEZ.")]
        [Display(Name = "Ad")]
        public string Name { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [Display(Name = "Puan")]
        public double Rating { get; set; }
        [Required(ErrorMessage = "FİYAT ALANI BOŞ GEÇİLEMEZ.")]
        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }
        [Display(Name = "İndirim")]
        public double Discount { get; set; }

        [Required(ErrorMessage = "IMAGE-URL ALANI BOŞ GEÇİLEMEZ.")]
        [Display(Name = "Resim")]
        public string ImageURL { get; set; }

        public Brand Brands { get; set; }

        //for use as fereignKey
        [Required(ErrorMessage = "YAYINEVİ ALANI BOŞ GEÇİLEMEZ.")]
        [Display(Name = "Yayınevi")]
        public int BrandId { get; set; }

        public Language Languages { get; set; }

        [Required(ErrorMessage = "BASIM DİLİ ALANI BOŞ GEÇİLEMEZ.")]
        [Display(Name = "Dili")]
        public int LanguageId { get; set; }

        //Bir kitabın birden çok yazarı olabilir

        public IList<AuthorBook> AuthorBooks { get; set; }

        //Bir kitap aynı anda hem korku hem gerilim türünde olabilir
        public IList<GenreBook> GenreBooks { get; set; }


    }
}
