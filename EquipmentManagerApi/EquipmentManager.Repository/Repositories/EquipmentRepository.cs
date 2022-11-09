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

        public List<Dictionary<Equipment, EquipmentModel>> GetMany()
        {
            var equipmentModelq = _appContext.Equipments.Join(_appContext.EquipmentsModel,
                equipment => equipment.EquipmentModel.Id,
                equipmentModel => equipmentModel.Id,
                (equipment, equipmentModel) => new Dictionary<Equipment, EquipmentModel>()
                {
                    { equipment,
                    equipmentModel }
                }).ToList();
            return equipmentModelq;
        }

        public Equipment Get(int id)
        {
            var equipment = _appContext.Equipments.Find(id);
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
