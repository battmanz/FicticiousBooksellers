using System.ComponentModel.DataAnnotations;

namespace FicticiousBookstore.Models
{
    public class ContactViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Subject { get; set; }

        [Required]
        [StringLength(800)]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
    }
}