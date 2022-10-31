using EquipmentManager.Domain.Entities;

namespace EquipmentManager.Repository.Repositories
{
    public interface IEquipmentModelStateHourlyEarning
    {
        public void Create(EquipmentModelStateHourlyEarning hourlyEarning);
        public void Delete(EquipmentModelStateHourlyEarning equipmentHourlyEarning);
        public void EnsureCreatedDatabase();
        public EquipmentModelStateHourlyEarning Get(EquipmentModelStateHourlyEarning hourlyEarning);
        public List<EquipmentModelStateHourlyEarning> GetMany();
        public void SaveChanges();

    }
}