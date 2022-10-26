using EquipmentManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EquipmentManager.Infrastructure
{
    public interface IApplicationContext 
    {
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentModel> EquipmentsModel { get; set; }
        public DbSet<EquipmentModelStateHourlyEarning> EquipmentsModelStateHourlyEarning { get; set; }
        public DbSet<EquipmentPositionHistory> EquipmentsPositionHistory { get; set; }
        public DbSet<EquipmentState> EquipmentsState { get; set; }
        public DbSet<EquipmentStateHistory> EquipmentsStateHistory { get; set; }
        public DbSet<User> Users { get; set; }
    }
}