using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Models.Entities
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishYear { get; set; }

        public ICollection<BorrowingRecord> BorrowingRecords { get; set; }
    }
}
