using LibraryManagementSystem.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Models.DTOs
{
    public class BookDTO
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishYear { get; set; }
    }
}
