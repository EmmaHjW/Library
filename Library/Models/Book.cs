using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Book id")]
        public int BookId { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(50)]
        public string Author { get; set; }
        [StringLength(50)]
        public string Genre { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Published { get; set; }
        [NotMapped]
        public string BookDisplay => $"{Title} - {Author}";
        public bool IsBorrowed { get; set; } = false;
        public virtual ICollection<BorrowList>? BorrowLists { get; set; }
    }
}
