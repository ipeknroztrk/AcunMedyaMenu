using System.ComponentModel.DataAnnotations;

namespace AcunMedyaMenu.Models
{
    public class MessageViewModel
    {
        [Required(ErrorMessage = "Lütfen adınızı ve soyadınızı giriniz.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen e-posta adresinizi giriniz.")]
        [EmailAddress(ErrorMessage = "Geçersiz e-posta adresi formatı.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen konuyu giriniz.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Lütfen mesajınızı giriniz.")]
        public string Content { get; set; }
    }
}
