using EquipmentManager.Domain.Entities;

namespace EquipmentManager.Domain.Interfaces.Repository
{
    public interface IEquipmentRepository
    {
        public Equipment Create(Equipment equipment);
        public Equipment Update(Equipment equipment);
        public Equipment Get(int id);
        public void Delete(int id);
        public void SaveChanges();

    }
}
