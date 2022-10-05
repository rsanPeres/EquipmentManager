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

        public EquipmentModel Create(EquipmentModel equipmentModel)
        {
            _appContext.Add(equipmentModel);
            return equipmentModel;
        }

        public EquipmentModel Update(EquipmentModel equipmentModel)
        {
            _appContext.Update(equipmentModel);
            return equipmentModel;
        }

        public EquipmentModel Get(int id)
        {
            var equipmentModel = _appContext.Find<EquipmentModel>(id);
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
    }
}
