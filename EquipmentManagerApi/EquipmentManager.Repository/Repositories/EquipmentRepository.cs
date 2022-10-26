using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Interfaces.Repository;
using EquipmentManager.Infrastructure;

namespace EquipmentManager.Repository
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly ApplicationContext _appContext;
        public EquipmentRepository(ApplicationContext appContext)
        {
            _appContext = appContext;
        }

        public void Create(Equipment equipment)
        {
            _appContext.Add(equipment);
        }

        public void Update(Equipment equipment)
        {
            _appContext.Update(equipment);
        }

        public Equipment Get(int id)
        {
            var equipment = _appContext.Find<Equipment>(id);
            return equipment;
        }

        public List<Equipment> GetMany()
        {
            var equipment = _appContext.Equipments.ToList();
            return equipment;
        }

        public void Delete(int id)
        {
            var equipment = Get(id);
            _appContext.Remove<Equipment>(equipment);
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
