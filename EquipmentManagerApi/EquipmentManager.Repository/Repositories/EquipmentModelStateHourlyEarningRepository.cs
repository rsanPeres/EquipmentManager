using EquipmentManager.Domain.Entities;
using EquipmentManager.Infrastructure;

namespace EquipmentManager.Repository.Repositories
{

    public class EquipmentModelStateHourlyEarningRepository : IEquipmentModelStateHourlyEarningRepository
    {
        private readonly ApplicationContext _appContext;

        public EquipmentModelStateHourlyEarningRepository(ApplicationContext appContext)
        {
            _appContext = appContext;
        }

        public void Create(EquipmentModelStateHourlyEarning hourlyEarning)
        {
            _appContext.Add(hourlyEarning);
        }

        public EquipmentModelStateHourlyEarning Get(EquipmentModelStateHourlyEarning hourlyEarning)
        {
            var equipmentHourlyEarning = _appContext.Find<EquipmentModelStateHourlyEarning>(hourlyEarning);
            return equipmentHourlyEarning;
        }

        public List<EquipmentModelStateHourlyEarning> GetMany()
        {
            var equipmentHourlyEarning = _appContext.EquipmentsModelStateHourlyEarning.ToList();
            return equipmentHourlyEarning;
        }
        public void Delete(EquipmentModelStateHourlyEarning equipmentHourlyEarning)
        {
            var equipmentEarning = Get(equipmentHourlyEarning);
            _appContext.Remove<EquipmentModelStateHourlyEarning>(equipmentEarning);
        }
        public void SaveChanges()
        {
            _appContext.SaveChanges();
        }
        public void EnsureCreatedDatabase()
        {
            try
            {
                _appContext.Database.EnsureCreated();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
