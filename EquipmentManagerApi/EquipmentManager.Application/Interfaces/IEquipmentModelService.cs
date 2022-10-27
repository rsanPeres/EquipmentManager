using EquipmentManager.Application.Dtos;

namespace EquipmentManager.Application.Interfaces
{
    public interface IEquipmentModelService
    {
        void Create(EquipmentModelDto equipmentDto);
        void Delete(EquipmentModelDto equipmentModelDto);
        EquipmentModelDto Get(EquipmentModelDto equipmentModelDto);
        List<EquipmentModelDto> GetMany();
        void Update(EquipmentModelDto equipmentModelDto);
    }
}