using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class BorrowBookViewModel
    {
        public int BookId { get; set; }
        public int CustomerId { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Genre { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Published { get; set; }
    }
}
