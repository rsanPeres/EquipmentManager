using EquipmentManager.Domain.Entities;

namespace EquipmentManager.Domain.Interfaces.Repository
{
    public interface IEquipmentStateHistoryRepository
    {
        void Create(EquipmentStateHistory StateHistory);
        void Delete(int id);
        void EnsureCreatedDatabase();
        EquipmentStateHistory Get(int id);
        List<EquipmentStateHistory> GetMany();
        void SaveChanges();
        void Update(EquipmentStateHistory StateHistory);
        List<EquipmentStateHistory> GetManyByEquipment(int id);
        EquipmentStateHistory GetLastByEquipment(int id);
    }
}