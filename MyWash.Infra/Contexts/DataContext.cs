using Microsoft.EntityFrameworkCore;
using MyWash.Model.Entity;

namespace MyWash.Infra.Contexts
{
    public class DataContext : DbContext
    {
         public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}