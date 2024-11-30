using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Models.Entities
{
    public class BorrowingRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BorrowingRecordID { get; set; }
        [Required]
        [ForeignKey("Book")]
        public int BookID { get; set; }
        [Required]
        [ForeignKey("Member")]
        public int MemberID { get; set; }
        [Required]
        public DateTime BorrowDate { get; set; }
        [Required]
        public bool IsReturned { get; set; }

        public Book Book { get; set; }
        public Member Member { get; set; }
    }
}
