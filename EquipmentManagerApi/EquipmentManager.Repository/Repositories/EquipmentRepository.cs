using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Interfaces.Repository;
using EquipmentManager.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace EquipmentManager.Repository
{
    public class EquipmentRepository : IEquipmentRepository
    {
        public ApplicationContext AppContext;

        public EquipmentRepository(ApplicationContext appContext)
        {
            AppContext = appContext;
        }

        public Equipment Create(Equipment equipment)
        {
            AppContext.Database.EnsureCreated();
            AppContext.Equipment.Add(equipment);
            AppContext.SaveChanges();
            return equipment;
        }

        public Equipment CreateEquipment(Equipment equipment)
        {
            AppContext.Database.EnsureCreated();
            var include = AppContext.EquipmentModel.Include(x => x.Equipments).First();
            include.Equipments.Add(equipment);
            AppContext.SaveChanges();
            return equipment;
        }


        public Equipment Get(string name)
        {
            AppContext.Database.EnsureCreated();
            var equipment = AppContext.Equipment
                       .Where(us => us.Name == name)
                       .FirstOrDefault<Equipment>();
            if(equipment == null) return null;
            return equipment;
        }

        public Equipment Update(string address, string name)
        {
            var equipment = AppContext.Equipment.First(p => p.Name == name);
            if (equipment != null)
            {
                AppContext.Equipment.Where(p => p.Name == name).ToList().ForEach(p => p.setName(address));
                AppContext.SaveChanges();
                return equipment;
            }
            return null;
        }

        public void Delete(string name)
        {
            var equipment = AppContext.Equipment.First(p => p.Name == name);
            if (equipment != null)
            {
                AppContext.Equipment.Remove(equipment);
                AppContext.SaveChanges();
            }
        }
    }
}
