using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage="KULLANICI ADI BOŞ OLAMAZ!")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "KULLANICI ŞİFRESİ BOŞ OLAMAZ!")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

    }
}
