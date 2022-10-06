using EquipmentManager.Domain.Entities;

namespace EquipmentManager.Domain.Interfaces.Repository
{
    public interface IEquipmentRepository
    {
        public void Create(Equipment equipment);
        public void Update(Equipment equipment);
        public Equipment Get(int id);
        public List<Equipment> GetMany();
        public void Delete(int id);
        public void SaveChanges();

    }
}
