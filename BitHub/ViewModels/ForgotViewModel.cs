using System.ComponentModel.DataAnnotations;

namespace BitHub.ViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Adres e-mail")]
        public string Email { get; set; }
    }
}
