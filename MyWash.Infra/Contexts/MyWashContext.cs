using Microsoft.EntityFrameworkCore;
using MyWash.Model.Entity;

namespace MyWash.Infra.Contexts
{
    public class MyWashContext : DbContext
    {
         public MyWashContext(DbContextOptions<MyWashContext> opt) : base(opt)
        {
            
        }
        public DbSet<User> Users { get; set; }

    }
}
