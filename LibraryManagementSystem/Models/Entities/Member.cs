namespace LibraryManagementSystem.Models.Entities
{
    public class Member
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime Birthday { get; set; }

        public ICollection<BorrowingRecord> BorrowingRecords { get; set; }
    }
}
