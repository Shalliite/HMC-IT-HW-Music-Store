namespace HMCMusicStore.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Linq;

    public class PaymentModel
    {
        [Required]
        [RegularExpression("[a-zA-Z/'/-]+", ErrorMessage = "Enter valid name. Allowed characters: (A-z).")]
        [MaxLength(30, ErrorMessage = "Maximum name length is 30 characters.")]
        [Display(Name = "Name")]
        public string? Name { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Enter valid e-mail address.")]
        [MaxLength(50, ErrorMessage = "Maximum e-mail length is 50 characters.")]
        [Display(Name = "E-mail")]
        public string? Email { get; set; }
    }
}
