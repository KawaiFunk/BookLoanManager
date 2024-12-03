using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models.DTOs
{
    public class BorrowingRecordDTO
    {
        public int BookID { get; set; }
        [Required]
        public int MemberID { get; set; }
        public string BookTitle { get; set; }

    }
}
