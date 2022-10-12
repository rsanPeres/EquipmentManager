using EquipmentManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EquipmentManager.Infrastructure
{
    public interface IApplicationContext
    {
        DbSet<Equipment> Equipment { get; set; }
        DbSet<EquipmentModel> EquipmentModel { get; set; }
        DbSet<EquipmentModelStateHourlyEarning> EquipmentModelStateHourlyEarning { get; set; }
        DbSet<EquipmentPositionHistory> EquipmentPositionHistory { get; set; }
        DbSet<EquipmentState> EquipmentState { get; set; }
        DbSet<EquipmentStateHistory> EquipmentStateHistory { get; set; }
        DbSet<User> User { get; set; }

        public virtual void OnConfiguring(DbContextOptionsBuilder optionsBuilder);
        public virtual void OnModelCreating(ModelBuilder modelBuilder);

    }
}