using EquipmentManager.Application.Dtos;
using EquipmentManager.Domain.Entities;

namespace EquipmentManager.Application.Interfaces
{
    public interface IEquipmentService
    {
        void Create(EquipmentDto equipmentDto);
        void Delete(int id);
        EquipmentDto Get(int id);
        List<EquipmentDto> GetMany();
        void Update(EquipmentDto equipmentDto);
        public List<EquipmentStateHistoryDto> GetManyByEquipment(int id);
        public List<EquipmentPositionHistoryDto> PositionByEquipment(int id);
        public EquipmentStateHistoryDto GetLastStateEquipment(int id);
        Dictionary<string, string> GetModelByEquipmentId(int id);
    }
}