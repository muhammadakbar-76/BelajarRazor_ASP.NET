using BelajarRazor.Models;

namespace BelajarRazor.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> option) : base(option) { }
        public DbSet<Category> Category { get; set; }
    }
}
