using FicticiousBookstore.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FicticiousBookstore.DAL
{
    public class BooksellersContext : DbContext
    {
        public BooksellersContext()
            : base("BooksellersContext")
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}