using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Interfaces.Repository;
using EquipmentManager.Infrastructure;

namespace EquipmentManager.Repository.Repositories
{
    public class EquipmentPositionHistoryRepository : IEquipmentPositionHistoryRepository
    {
        private readonly ApplicationContext _appContext;
        public EquipmentPositionHistoryRepository(ApplicationContext appContext)
        {
            _appContext = appContext;
        }

        public void Create(EquipmentPositionHistory equipment)
        {
            _appContext.Add(equipment);
        }

        public EquipmentPositionHistory Get(int id)
        {
            var equipmentPositionHistory = _appContext.Find<EquipmentPositionHistory>(id);
            return equipmentPositionHistory;
        }

        public List<EquipmentPositionHistory> GetMany()
        {
            var equipmentPositionHistory = _appContext.EquipmentsPositionHistory.ToList();
            return equipmentPositionHistory;
        }

        public void Delete(int id)
        {
            var equipmentPositionHistory = Get(id);
            _appContext.Remove<EquipmentPositionHistory>(equipmentPositionHistory);
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
