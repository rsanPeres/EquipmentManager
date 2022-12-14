using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Interfaces.Repository;
using EquipmentManager.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public EquipmentModel GetModelByEquipmentId(int id)
        {
            var equipmentModel = _appContext.EquipmentsModel.OrderByDescending(x => x.Equipments.Where(x => x.Id.Equals(id))).FirstOrDefault();
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
