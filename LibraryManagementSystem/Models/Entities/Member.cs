using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models.Entities
{
    public class Member
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public DateTime Birthday { get; set; }

        public ICollection<BorrowingRecord> BorrowingRecords { get; set; }
    }
}
