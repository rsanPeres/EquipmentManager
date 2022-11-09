using EquipmentManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EquipmentManager.Infrastructure
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<EquipmentModel> EquipmentsModel { get; set; }
        public virtual DbSet<EquipmentModelStateHourlyEarning> EquipmentsModelStateHourlyEarning { get; set; }
        public virtual DbSet<EquipmentPositionHistory> EquipmentsPositionHistory { get; set; }
        public virtual DbSet<EquipmentState> EquipmentsState { get; set; }
        public virtual DbSet<EquipmentStateHistory> EquipmentsStateHistory { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> opt) : base(opt) {  }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {  }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
            modelBuilder.Ignore("Notification");
        }
    }
}