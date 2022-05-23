using System.ComponentModel.DataAnnotations;

namespace dotnet5_webpack_encore.Models
{
    public class ContactViewModel
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        [Required(ErrorMessage = "Please enter a subject.")]
        public string Subject { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 20)]
        [Required(ErrorMessage = "Please enter a message.")]
        public string Message { get; set; }
    }
}