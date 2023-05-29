using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        //public string FullName { get; set; }
        //public string Email { get; set; }
        //public string PhoneNumber { get; set; }
        [ForeignKey("Customers")]
        public int FK_CustomerId { get; set; }
        public virtual Customer Customers { get; set; }
        //public string Title { get; set; }
        //public string Author { get; set; }
        [ForeignKey("Books")]
        public int FK_BookId { get; set; }
        public virtual Book Books { get; set; }
        //public DateTime BorrowDate { get; set; }
        //public DateTime ReturnDate { get; set; }
        [ForeignKey("BorrowLists")]
        public int BorrowListId { get; set; }
        public virtual BorrowList BorrowLists { get; set; }
    }
}
