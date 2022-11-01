using EquipmentManager.Domain.Entities;

namespace EquipmentManager.Domain.Interfaces.Repository
{
    public interface IEquipmentStateRepository
    {
        public void Create(EquipmentState equipment);
        public EquipmentState Get(int id);
        public List<EquipmentState> GetMany();
        public void Delete(int id);
        public void SaveChanges();
        public void EnsureCreatedDatabase();
    }
}
