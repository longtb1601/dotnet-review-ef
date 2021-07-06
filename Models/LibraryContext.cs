using Microsoft.EntityFrameworkCore;

namespace Library_System.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().Property(a => a.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Book>().Property(b => b.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Client>().Property(c => c.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Client>().HasMany(c => c.Book).WithOne(b => b.Client);
            modelBuilder.Entity<Book>().HasMany(b => b.Author);
            modelBuilder.Entity<Author>().HasMany(a => a.Book);   

            //seeding
            modelBuilder.Entity<Author>().HasData(new Author
            {
                Id = 1,
                AuthorName = "Author 1",
            });
            modelBuilder.Entity<Client>().HasData(new Client
            {
                Id = 1,
                ClientName = "Client 1",
            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 1,
                BookName = "Book 1",
                ClientId = 1,
            });
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}