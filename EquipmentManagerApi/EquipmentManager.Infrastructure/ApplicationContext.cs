using EquipmentManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EquipmentManager.Infrastructure
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<EquipmentModel> EquipmentModel { get; set; }
        public virtual DbSet<EquipmentModelStateHourlyEarning> EquipmentModelStateHourlyEarning { get; set; }
        public virtual DbSet<EquipmentPositionHistory> EquipmentPositionHistory { get; set; }
        public virtual DbSet<EquipmentState> EquipmentState { get; set; }
        public virtual DbSet<EquipmentStateHistory> EquipmentStateHistory { get; set; }

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