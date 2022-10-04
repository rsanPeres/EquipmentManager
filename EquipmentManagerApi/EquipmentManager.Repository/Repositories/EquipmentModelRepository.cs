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
    public class EquipmentModelRepository
    {
        public ApplicationContext AppContext;

        public EquipmentModelRepository(ApplicationContext appContext)
        {
            AppContext = appContext;
        }

        public EquipmentModel Create(EquipmentModel equipmentModel)
        {
            AppContext.Database.EnsureCreated();
            AppContext.EquipmentModel.Add(equipmentModel);
            AppContext.SaveChanges();
            return equipmentModel;
        }

        public EquipmentModel Get(string name)
        {
            AppContext.Database.EnsureCreated();
            var equipmentModel = AppContext.EquipmentModel
                       .Where(us => us.Name == name)
                       .FirstOrDefault<EquipmentModel>();
            return equipmentModel;
        }

        public EquipmentModel Update(string address, string name)
        {
            var equipmentModel = AppContext.EquipmentModel.First(p => p.Name == name);
            if (equipmentModel != null)
            {
                AppContext.EquipmentModel.Where(p => p.Name == name).ToList().ForEach(p => p.Name = address);
                AppContext.SaveChanges();
                return equipmentModel;
            }
            return null;
        }

        public void Delete(string name)
        {
            var equipmentModel = AppContext.EquipmentModel.First(p => p.Name == name);
            if (equipmentModel != null)
            {
                AppContext.EquipmentModel.Remove(equipmentModel);
                AppContext.SaveChanges();
            }
        }
    }
}
