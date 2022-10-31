using EquipmentManager.Application.Dtos;

namespace EquipmentManager.Application.Interfaces
{
    public interface IEquipmentModelStateHourlyEarningService
    {
        void Create(EquipmentModelStateHourlyEarningDto hourlyEarning);
        void Delete(EquipmentModelStateHourlyEarningDto equipmentModelDto);
        EquipmentModelStateHourlyEarningDto Get(EquipmentModelStateHourlyEarningDto equipmentModelDto);
        List<EquipmentModelStateHourlyEarningDto> GetMany();
    }
}