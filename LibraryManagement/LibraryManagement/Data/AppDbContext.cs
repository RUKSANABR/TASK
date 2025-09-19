using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Data
{
    public class AppDbContext : DbContext  //manage connection,trackchanges
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }

        //used to configure model configure entity bhvr
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Book>()
                .HasIndex(b => b.ISBN) //create index b=>one book variable
                .IsUnique();  // for unique ISBN
        }
    }
}