using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Code_Academy___Conference_Management_System.Models
{
    public class ProfileVM
    {
        [Required]
        [Display(Name = "Tam Ad")]
        public string FullName { get; set; }

        [Display(Name = "İstifadəçi Adı")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-poçt Ünvanı")]
        public string Email { get; set; }

        [Display(Name = "Yeni Profil Şəkli")]
        public IFormFile ProfileImageFile { get; set; }

        public string ProfilePictureUrl { get; set; }

        public ChangePasswordVM ChangePassword { get; set; }
    }

   
}
