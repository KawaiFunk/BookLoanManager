using LibraryManagementSystem.Models.Entities;

namespace LibraryManagementSystem.Data
{
    public static class DbInitialize
    {
        public static void Initialize(LibraryContext context) 
        {
            context.Database.EnsureCreated();

            if (context.Books.Any())
            {
                return;
            }

            var members = new Member[]
            {
                new Member { LastName = "Doe", FirstName = "John", Birthday = DateTime.Parse("1990-01-01") },
                new Member { LastName = "Smith", FirstName = "Jane", Birthday = DateTime.Parse("1995-01-01") },
                new Member { LastName = "Johnson", FirstName = "James", Birthday = DateTime.Parse("2000-01-01") },
                new Member { LastName = "Williams", FirstName = "Mary", Birthday = DateTime.Parse("2005-01-01") },
                new Member { LastName = "Brown", FirstName = "Patricia", Birthday = DateTime.Parse("2010-01-01") },
                new Member { LastName = "Jones", FirstName = "Robert", Birthday = DateTime.Parse("2015-01-01") },
                new Member { LastName = "Garcia", FirstName = "Linda", Birthday = DateTime.Parse("2020-01-01") },
                new Member { LastName = "Miller", FirstName = "Michael", Birthday = DateTime.Parse("2025-01-01") }
            };

            foreach (Member m in members)
            {
                context.Members.Add(m);
            }

            context.SaveChanges();

            var books = new Book[]
{
                new Book {BookID = 1001, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Publisher = "J.K. Rowlings", PublishYear = DateTime.Parse("1990-01-01") },
                new Book {BookID = 1002, Title = "To Kill a Mockingbird", Author = "Harper Lee", Publisher = "Lippincott & Co.", PublishYear = DateTime.Parse("1960-07-11") },
                new Book {BookID = 1003, Title = "1984", Author = "George Orwell", Publisher = "Secker & Warburg", PublishYear = DateTime.Parse("1949-06-08") },
                new Book {BookID = 1004, Title = "Pride and Prejudice", Author = "Jane Austen", Publisher = "T. Egerton", PublishYear = DateTime.Parse("1813-01-28") },
                new Book {BookID = 1005, Title = "Moby-Dick", Author = "Herman Melville", Publisher = "Harper & Brothers", PublishYear = DateTime.Parse("1851-10-18") },
                new Book {BookID = 1006, Title = "The Catcher in the Rye", Author = "J.D. Salinger", Publisher = "Little, Brown and Company", PublishYear = DateTime.Parse("1951-07-16") },
                new Book {BookID = 1007, Title = "The Hobbit", Author = "J.R.R. Tolkien", Publisher = "George Allen & Unwin", PublishYear = DateTime.Parse("1937-09-21") },
                new Book {BookID = 1008, Title = "Brave New World", Author = "Aldous Huxley", Publisher = "Chatto & Windus", PublishYear = DateTime.Parse("1932-08-30") },
                new Book {BookID = 1009, Title = "War and Peace", Author = "Leo Tolstoy", Publisher = "The Russian Messenger", PublishYear = DateTime.Parse("1869-01-01") },
                new Book {BookID = 1010, Title = "Crime and Punishment", Author = "Fyodor Dostoevsky", Publisher = "The Russian Messenger", PublishYear = DateTime.Parse("1866-01-01") },
                new Book {BookID = 1011, Title = "The Alchemist", Author = "Paulo Coelho", Publisher = "HarperOne", PublishYear = DateTime.Parse("1988-01-01") }
            };

            foreach (Book b in books)
            {
                context.Books.Add(b);
            }

            context.SaveChanges();

        }
    }
}
