using EquipmentManager.Domain.Entities;

namespace EquipmentManager.Repository.Repositories
{
    public interface IEquipmentModelStateHourlyEarningRepository
    {
        public void Create(EquipmentModelStateHourlyEarning hourlyEarning);
        public void Delete(EquipmentModelStateHourlyEarning equipmentHourlyEarning);
        public void EnsureCreatedDatabase();
        public EquipmentModelStateHourlyEarning Get(EquipmentModelStateHourlyEarning hourlyEarning);
        public List<Dictionary<decimal, string>> GetMany();
        public void SaveChanges();

    }
}