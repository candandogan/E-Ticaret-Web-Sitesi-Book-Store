using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class CompleteShopping
    {
        [Required(ErrorMessage = "Lütfen adınızı giriniz.")]
        [Display(Name = "Ad-Soyad")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Lütfen adresinizi giriniz.")]
        [Display(Name = "Adres")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "Lütfen telefon numaranızı giriniz.")]
        [Display(Name = "Telefon Numarası")]
        [Phone(ErrorMessage ="Telefon numara formatı doğru değil!")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Lütfen mail aresinizi giriniz.")]
        [Display(Name = "Mail Adresi")]
        [EmailAddress(ErrorMessage ="E-Posta formatı doğru değil!")]
        public string EMail { get; set; }

        [Required(ErrorMessage = "Lütfen kartın üzerindeki ad-soyadı giriniz.")]
        [Display(Name = "Kart Ad-Soyad")]
        public string FullNameOnCard { get; set; }

        [Required(ErrorMessage = "Lütfen kartın üzerindeki numarayı giriniz.")]
        [Display(Name = "Kart Numarası")]
        [StringLength(16,ErrorMessage ="Kart numarası 16 haneli değil. ")]
        public string NumberOnCard { get; set; }

        [Required(ErrorMessage = "Lütfen kartın üzerindeki son kullanma tarihini giriniz.")]
        [Display(Name = "Kart Son Kullanma Tarihi")]
        public string DateOfCard { get; set; }

        [Required(ErrorMessage = "Lütfen kartın üzerindeki 3 haneli güvenlik kodunu giriniz.")]
        [Display(Name = "Kart Güvenlik Kodu")]
        [StringLength(3, ErrorMessage = "Kart numarası 3 haneli değil. ")]
        public string SCofCard { get; set; }

        
    }
}
