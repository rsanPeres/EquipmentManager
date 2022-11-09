using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Interfaces.Repository;
using EquipmentManager.Infrastructure;

namespace EquipmentManager.Repository.Repositories
{
    public class EquipmentStateHistoryRepository : IEquipmentStateHistoryRepository
    {
        private readonly ApplicationContext _appContext;
        public EquipmentStateHistoryRepository(ApplicationContext appContext)
        {
            _appContext = appContext;
        }

        public void Create(EquipmentStateHistory StateHistory)
        {
            _appContext.Add(StateHistory);
        }

        public void Update(EquipmentStateHistory StateHistory)
        {
            _appContext.Update(StateHistory);
        }

        public EquipmentStateHistory Get(int id)
        {
            var StateHistory = _appContext.Find<EquipmentStateHistory>(id);
            return StateHistory;
        }

        public List<EquipmentStateHistory> GetMany()
        {
            var StateHistory = _appContext.EquipmentsStateHistory.ToList();
            return StateHistory;
        }

        public List<EquipmentStateHistory> GetManyByEquipment(int id)
        {
            var EquipmentStateHistory = _appContext.EquipmentsStateHistory.Where(x => x.Equipment.Id == id).ToList<EquipmentStateHistory>();
            return EquipmentStateHistory;
        }

        public EquipmentStateHistory GetLastByEquipment(int id)
        {
            var state = _appContext.EquipmentsStateHistory.OrderByDescending(x =>x.Equipment.Id == id).FirstOrDefault();
            return state;
        }

        public void Delete(int id)
        {
            var StateHistory = Get(id);
            _appContext.Remove<EquipmentStateHistory>(StateHistory);
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
