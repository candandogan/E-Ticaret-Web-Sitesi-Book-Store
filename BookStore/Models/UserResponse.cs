using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class UserResponse
    {
        [Required(ErrorMessage ="Lütfen adınızı giriniz.")]
        [Display(Name = "Ad-Soyad")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Lütfen mail adresinizi giriniz.")]
        [EmailAddress(ErrorMessage ="E-posta formatınız doğru değil!")]
        [Display(Name = "E-Posta")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen görüş/öneri ya da şikayetinizi belirtiniz")]

        [Display(Name = "Mesaj")]
        public string Message { get; set; }

        [Required(ErrorMessage = "Görüşleriniz bizim için çok değerli, lütfen bu alanı boş geçmeyin.")]
        [Display(Name = "Memnuniyet")]
        public bool IsAccepted { get; set; }
       

    }
}
