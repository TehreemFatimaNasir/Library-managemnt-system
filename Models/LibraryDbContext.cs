using librarymanagement.Models;
using Microsoft.EntityFrameworkCore;

namespace librarymanagement.Models
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<IssueBook> IssuedBooks { get; set; }
        public DbSet<ReturnBook> ReturnedBooks { get; set; }
        public DbSet<FineRecord> FineRecords { get; set; }

    }
}
