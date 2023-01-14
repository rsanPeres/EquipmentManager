using EquipmentManager.Domain.Entities;

namespace EquipmentManager.Domain.Interfaces.Repository
{
    public interface IEquipmentPositionHistoryRepository
    {
        void Create(EquipmentPositionHistory equipment);
        void Delete(int id);
        void EnsureCreatedDatabase();
        EquipmentPositionHistory Get(int id);
        List<EquipmentPositionHistory> GetMany();
        void SaveChanges();
        EquipmentPositionHistory PositionByEquipment(int id);
    }
}