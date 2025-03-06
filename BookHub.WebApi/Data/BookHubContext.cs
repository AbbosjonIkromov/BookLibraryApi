using System.Reflection;
using BookHub.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookHub.WebApi.Data
{
    public class BookHubContext : DbContext
    {
        public BookHubContext(DbContextOptions options) : base(options) { }

    
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
