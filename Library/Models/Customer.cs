using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Library.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Customer id")]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(35)]
        [DisplayName("First name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Last name")]
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        [Required]
        [StringLength(45)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }
        [Required]
        [StringLength(30)]
        public string City { get; set; }
        [Required]
        [MinLength(9), MaxLength(20)]
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }
        
    }
}
