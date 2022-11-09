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

         

        public List<Dictionary<decimal, string>> GetMany()
        {
            var equipment = _appContext.EquipmentsModelStateHourlyEarning.Join(_appContext.EquipmentsState,
                equipment => equipment.EquipmentState.Id,
                equipmentModel => equipmentModel.Id,
                (equipment, equipmentModel) => new Dictionary<decimal, string>()
                {
                    { equipment.EarnedValueByHourState,
                    equipmentModel.StateName }
                }).ToList();
            return equipment;
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
