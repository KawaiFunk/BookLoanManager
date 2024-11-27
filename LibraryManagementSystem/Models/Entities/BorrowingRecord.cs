namespace LibraryManagementSystem.Models.Entities
{
    public class BorrowingRecord
    {
        public int BorrowingRecordID { get; set; }
        public int BookID { get; set; }
        public int MemberID { get; set; }
        public DateTime BorrowDate { get; set; }
        public bool IsReturned { get; set; }

        public Book Book { get; set; }
        public Member Member { get; set; }
    }
}
