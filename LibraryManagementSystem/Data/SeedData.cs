using LibraryManagementSystem.Models.Entities;
using System;
using System.Linq;

namespace LibraryManagementSystem.Data
{
    public static class SeedData
    {
        public static async Task SeedDatabase(LibraryContext context)
        {
            try
            {

                var members = new[]
                {
                    new Member { FirstName = "John", LastName = "Doe", Birthday = new DateTime(1990, 5, 14) },
                    new Member { FirstName = "Jane", LastName = "Smith", Birthday = new DateTime(1988, 8, 23) },
                    new Member { FirstName = "Alice", LastName = "Johnson", Birthday = new DateTime(1995, 2, 11) },
                    new Member { FirstName = "Bob", LastName = "Brown", Birthday = new DateTime(1982, 6, 1) },
                    new Member { FirstName = "Charlie", LastName = "Davis", Birthday = new DateTime(1992, 3, 17) },
                    new Member { FirstName = "David", LastName = "Miller", Birthday = new DateTime(1985, 12, 5) },
                    new Member { FirstName = "Eve", LastName = "Wilson", Birthday = new DateTime(1990, 4, 30) },
                    new Member { FirstName = "Frank", LastName = "Moore", Birthday = new DateTime(1987, 11, 21) },
                    new Member { FirstName = "Grace", LastName = "Taylor", Birthday = new DateTime(1993, 9, 10) },
                    new Member { FirstName = "Hank", LastName = "Anderson", Birthday = new DateTime(1996, 7, 18) },
                    new Member { FirstName = "Ivy", LastName = "Thomas", Birthday = new DateTime(1989, 2, 6) },
                    new Member { FirstName = "Jack", LastName = "Jackson", Birthday = new DateTime(1991, 1, 24) },
                    new Member { FirstName = "Kathy", LastName = "White", Birthday = new DateTime(1983, 5, 13) },
                    new Member { FirstName = "Liam", LastName = "Harris", Birthday = new DateTime(1994, 10, 2) },
                    new Member { FirstName = "Mona", LastName = "Martin", Birthday = new DateTime(1990, 12, 22) },
                    new Member { FirstName = "Nina", LastName = "Garcia", Birthday = new DateTime(1988, 8, 19) },
                    new Member { FirstName = "Oscar", LastName = "Martinez", Birthday = new DateTime(1992, 4, 10) },
                    new Member { FirstName = "Paul", LastName = "Rodriguez", Birthday = new DateTime(1987, 11, 15) },
                    new Member { FirstName = "Quincy", LastName = "Lee", Birthday = new DateTime(1985, 7, 30) },
                    new Member { FirstName = "Rachel", LastName = "Gonzalez", Birthday = new DateTime(1993, 6, 3) },
                    new Member { FirstName = "Sam", LastName = "Perez", Birthday = new DateTime(1991, 1, 8) },
                    new Member { FirstName = "Tina", LastName = "Clark", Birthday = new DateTime(1986, 2, 16) },
                    new Member { FirstName = "Ursula", LastName = "Lewis", Birthday = new DateTime(1994, 12, 11) },
                    new Member { FirstName = "Victor", LastName = "Walker", Birthday = new DateTime(1987, 9, 25) },
                    new Member { FirstName = "Wendy", LastName = "Young", Birthday = new DateTime(1990, 3, 6) },
                    new Member { FirstName = "Xander", LastName = "King", Birthday = new DateTime(1995, 5, 14) },
                    new Member { FirstName = "Yara", LastName = "Scott", Birthday = new DateTime(1992, 8, 9) },
                    new Member { FirstName = "Zane", LastName = "Adams", Birthday = new DateTime(1993, 11, 17) },
                };

                context.Members.AddRange(members);

                var books = new[]
                {
                    new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Publisher = "Scribner", PublishYear = new DateTime(1925, 1, 1), IsAvailable = true },
                    new Book { Title = "1984", Author = "George Orwell", Publisher = "Secker & Warburg", PublishYear = new DateTime(1949, 1, 1), IsAvailable = true },
                    new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee", Publisher = "J.B. Lippincott & Co.", PublishYear = new DateTime(1960, 1, 1), IsAvailable = true },
                    new Book { Title = "Pride and Prejudice", Author = "Jane Austen", Publisher = "T. Egerton", PublishYear = new DateTime(1813, 1, 1), IsAvailable = true },
                    new Book { Title = "The Catcher in the Rye", Author = "J.D. Salinger", Publisher = "Little, Brown and Company", PublishYear = new DateTime(1951, 1, 1), IsAvailable = true },
                    new Book { Title = "The Hobbit", Author = "J.R.R. Tolkien", Publisher = "George Allen & Unwin", PublishYear = new DateTime(1937, 1, 1), IsAvailable = true },
                    new Book { Title = "Moby Dick", Author = "Herman Melville", Publisher = "Harper & Brothers", PublishYear = new DateTime(1851, 1, 1), IsAvailable = true },
                    new Book { Title = "War and Peace", Author = "Leo Tolstoy", Publisher = "The Russian Messenger", PublishYear = new DateTime(1869, 1, 1), IsAvailable = true },
                    new Book { Title = "Ulysses", Author = "James Joyce", Publisher = "Sylvia Beach", PublishYear = new DateTime(1922, 1, 1), IsAvailable = true },
                    new Book { Title = "Don Quixote", Author = "Miguel de Cervantes", Publisher = "Francisco de Robles", PublishYear = new DateTime(1605, 1, 1), IsAvailable = true },
                    new Book { Title = "Anna Karenina", Author = "Leo Tolstoy", Publisher = "The Russian Messenger", PublishYear = new DateTime(1878, 1, 1), IsAvailable = true },
                    new Book { Title = "The Divine Comedy", Author = "Dante Alighieri", Publisher = "Various", PublishYear = new DateTime(1320, 1, 1), IsAvailable = true },
                    new Book { Title = "Frankenstein", Author = "Mary Shelley", Publisher = "Lackington, Hughes, Harding, Mavor & Jones", PublishYear = new DateTime(1818, 1, 1), IsAvailable = true },
                    new Book { Title = "Dracula", Author = "Bram Stoker", Publisher = "Archibald Constable and Company", PublishYear = new DateTime(1897, 1, 1), IsAvailable = true },
                    new Book { Title = "Les Misérables", Author = "Victor Hugo", Publisher = "A. Lacroix, Verboeckhoven & Cie", PublishYear = new DateTime(1862, 1, 1), IsAvailable = true },
                    new Book { Title = "The Brothers Karamazov", Author = "Fyodor Dostoevsky", Publisher = "The Russian Messenger", PublishYear = new DateTime(1880, 1, 1), IsAvailable = true },
                    new Book { Title = "Crime and Punishment", Author = "Fyodor Dostoevsky", Publisher = "The Russian Messenger", PublishYear = new DateTime(1866, 1, 1), IsAvailable = true },
                    new Book { Title = "The Count of Monte Cristo", Author = "Alexandre Dumas", Publisher = "Maquet", PublishYear = new DateTime(1844, 1, 1), IsAvailable = true },
                    new Book { Title = "Catch-22", Author = "Joseph Heller", Publisher = "Simon & Schuster", PublishYear = new DateTime(1961, 1, 1), IsAvailable = true },
                    new Book { Title = "The Grapes of Wrath", Author = "John Steinbeck", Publisher = "The Viking Press", PublishYear = new DateTime(1939, 1, 1), IsAvailable = true },
                    new Book { Title = "The Old Man and the Sea", Author = "Ernest Hemingway", Publisher = "Charles Scribner's Sons", PublishYear = new DateTime(1952, 1, 1), IsAvailable = true },
                    new Book { Title = "The Stranger", Author = "Albert Camus", Publisher = "Gallimard", PublishYear = new DateTime(1942, 1, 1), IsAvailable = true },
                    new Book { Title = "One Hundred Years of Solitude", Author = "Gabriel García Márquez", Publisher = "Editorial Sudamericana", PublishYear = new DateTime(1967, 1, 1), IsAvailable = true },
                    new Book { Title = "The Catcher in the Rye", Author = "J.D. Salinger", Publisher = "Little, Brown and Company", PublishYear = new DateTime(1951, 1, 1), IsAvailable = true },
                };

                context.Books.AddRange(books);

                await context.SaveChangesAsync();

                Console.WriteLine("Seeding completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Seeding failed: {ex.Message}");
            }
        }
    }
}
