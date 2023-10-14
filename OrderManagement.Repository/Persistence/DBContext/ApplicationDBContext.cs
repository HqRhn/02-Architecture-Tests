using Microsoft.EntityFrameworkCore;
using OrderManagement.Repository.Persistence.Mappings;

namespace OrderManagement.Repository.Persistence.DBContext
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.ApplyConfiguration(new OrderMapping());
        }
    }
}
