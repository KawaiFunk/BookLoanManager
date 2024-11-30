using LibraryManagementSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<BorrowingRecord> BorrowingRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Member>().ToTable("Member");
            modelBuilder.Entity<BorrowingRecord>().ToTable("BorrowingRecord");
            modelBuilder.Entity<Book>().Property(b => b.BookID).ValueGeneratedOnAdd();
        }
    }
}
