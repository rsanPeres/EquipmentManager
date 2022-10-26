using EquipmentManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EquipmentManager.Infrastructure
{
    public interface IApplicationContext 
    {
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<EquipmentModel> EquipmentModel { get; set; }
        public DbSet<EquipmentModelStateHourlyEarning> EquipmentModelStateHourlyEarning { get; set; }
        public DbSet<EquipmentPositionHistory> EquipmentPositionHistory { get; set; }
        public DbSet<EquipmentState> EquipmentState { get; set; }
        public DbSet<EquipmentStateHistory> EquipmentStateHistory { get; set; }
        public DbSet<User> User { get; set; }
    }
}