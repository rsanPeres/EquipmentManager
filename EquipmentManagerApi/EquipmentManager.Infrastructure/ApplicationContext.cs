using EquipmentManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EquipmentManager.Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<EquipmentModel> EquipmentModel { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> opt) : base(opt)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder
            //    .UseSqlServer(
            //        "Data source=(localdb)\\mssqllocaldb; Initial Catalog=EquipmentManager; Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
            modelBuilder.Ignore("Notification");


        }
    }
}