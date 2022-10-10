using EquipmentManager.Application.Dtos;

namespace EquipmentManager.Application.Interfaces
{
    public interface IEquipmentService
    {
        void Create(EquipmentDto equipmentDto);
        void Delete(int id);
        EquipmentDto Get(int id);
        List<EquipmentDto> GetMany();
        void Update(EquipmentDto equipmentDto);
    }
}