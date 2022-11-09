using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Model;

namespace EquipmentManager.Domain.Interfaces.Repository
{
    public interface IEquipmentRepository
    {
        public void Create(Equipment equipment);
        public void Update(Equipment equipment);
        public Equipment Get(int id);
        List<Dictionary<Equipment, EquipmentModel>> GetMany();
        public void Delete(int id);
        public void SaveChanges();
        public void EnsureCreatedDatabase();
    }
}
