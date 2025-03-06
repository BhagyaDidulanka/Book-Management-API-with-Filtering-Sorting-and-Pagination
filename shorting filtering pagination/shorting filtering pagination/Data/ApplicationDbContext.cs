using Microsoft.EntityFrameworkCore;
using shorting_filtering_pagination.Models;

namespace shorting_filtering_pagination.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
