using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Interfaces.Repository;
using EquipmentManager.Infrastructure;

namespace EquipmentManager.Repository.Repositories
{
    public class EquipmentStateRepository : IEquipmentStateRepository
    {
        private readonly ApplicationContext _appContext;
        public EquipmentStateRepository(ApplicationContext appContext)
        {
            _appContext = appContext;
        }

        public void Create(EquipmentState equipment)
        {
            _appContext.Add(equipment);
        }

        public EquipmentState Get(int id)
        {
            var equipment = _appContext.Find<EquipmentState>(id);
            return equipment;
        }

        public List<EquipmentState> GetMany()
        {
            var equipment = _appContext.EquipmentsState.ToList();
            return equipment;
        }

        public void Delete(int id)
        {
            var equipment = Get(id);
            _appContext.Remove<EquipmentState>(equipment);
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
