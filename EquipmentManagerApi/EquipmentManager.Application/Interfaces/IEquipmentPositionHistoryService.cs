using EquipmentManager.Application.Dtos;

namespace EquipmentManager.Application.Interfaces
{
    public interface IEquipmentPositionHistoryService
    {
        void Create(EquipmentPositionHistoryDto equipmentPositionDto);
        void Delete(int id);
        EquipmentPositionHistoryDto Get(int id);
        List<EquipmentPositionHistoryDto> GetMany();
        List<EquipmentPositionHistoryDto> PositionByEquipment(int id);
        
    }
}