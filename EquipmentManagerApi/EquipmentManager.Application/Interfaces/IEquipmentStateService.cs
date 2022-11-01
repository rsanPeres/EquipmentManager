using EquipmentManager.Application.Dtos;

namespace EquipmentManager.Application.Interfaces
{
    public interface IEquipmentStateService
    {
        void Create(EquipmentStateDto stateDto);
        void Delete(int id);
        EquipmentStateDto Get(int id);
        List<EquipmentStateDto> GetMany();
    }
}