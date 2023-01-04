using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Interfaces.Repository;
using EquipmentManager.Infrastructure;
using System.Linq;

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

        public Dictionary<string, string> GetEquipmentModelByEquipmentId(int equipmentId)
        {
            var queryState = (from equipment in _appContext.Equipments
                        join equipmentState in _appContext.EquipmentsStateHistory on
                        equipmentId equals equipmentState.Equipment.Id
                        orderby equipmentState.EquipmentState.Id descending
                        select new Dictionary<string, string>(){ { equipment.Name, equipmentState.EquipmentState.StateName } }).First();

            return queryState;
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
