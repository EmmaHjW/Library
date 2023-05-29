using System.Reflection.Metadata.Ecma335;

namespace Library.Models
{
    public class SearchViewModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int BookId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int BorrowListId { get; set; }
    }
}
