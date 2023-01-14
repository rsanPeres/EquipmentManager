using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Interfaces.Repository;
using EquipmentManager.Infrastructure;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EquipmentManager.Repository.Repositories
{
    public class EquipmentModelRepository : IEquipmentModelRepository
    {
        private readonly ApplicationContext _appContext;

        public EquipmentModelRepository(ApplicationContext appContext)
        {
            _appContext = appContext;
        }

        public void Create(EquipmentModel equipmentModel)
        {
            _appContext.Add(equipmentModel);
        }

        public void Update(EquipmentModel equipmentModel)
        {
            _appContext.Update(equipmentModel);
        }

        public EquipmentModel Get(int id)
        {
            var equipmentModel = _appContext.Find<EquipmentModel>(id);
            return equipmentModel;
        }

        public List<EquipmentModel> GetMany()
        {
            var equipmentModel = _appContext.EquipmentsModel.ToList();
            return equipmentModel;
        }

        public Dictionary<string, string> GetModelByEquipmentId(Equipment equipment)
        {
            var equipmentModel = (from equip in _appContext.Equipments
                                  join equipmentM in _appContext.EquipmentsModel on
                                  equipment.EquipmentModel.Id equals equipmentM.Id 
                                  select new Dictionary<string, string>() { { equipment.Name, equipmentM.Name } }).FirstOrDefault();
           
            return equipmentModel;
        }

        public void Delete(int id)
        {
            var equipmentModel = Get(id);
            _appContext.Remove<EquipmentModel>(equipmentModel);
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
