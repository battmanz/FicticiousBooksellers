using FicticiousBookstore.Attributes;
using Foolproof;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace FicticiousBookstore.Models
{
    public class Book
    {
        [Key]
        [Required]
        [Display(Name = "ISBN 13")]
        public string ISBN13 { get; set; }

        [Required]
        [Display(Name = "ISBN 10")]
        public string ISBN10 { get; set; }

        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Author { get; set; }
        
        [Required]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Publication Date")]
        public DateTime PublicationDate { get; set; }

        [RequiredIfEmpty("ImageName")]
        [NotMapped]
        [HttpPostedFileExtensionsAttribute(Extensions = "jpg, jpeg, png, gif")]
        public HttpPostedFileBase Image { get; set; }

        public string ImageName { get; set; }
        
        [Required]
        public decimal Price { get; set; }
        
        [Required]
        public int Stock { get; set; }
    }
}