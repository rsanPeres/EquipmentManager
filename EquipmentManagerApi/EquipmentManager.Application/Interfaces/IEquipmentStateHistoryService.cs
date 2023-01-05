using EquipmentManager.Application.Dtos;
using EquipmentManager.Domain.Entities;

namespace EquipmentManager.Application.Interfaces
{
    public interface IEquipmentStateHistoryService
    {
        void Create(EquipmentStateHistoryDto stateHistoryDto);
        void Delete(int id);
        EquipmentStateHistoryDto Get(int id);
        List<EquipmentStateHistoryDto> GetMany();
        List<EquipmentStateHistoryDto> GetManyByEquipment(int id);
        Dictionary<string, EquipmentModelStateHourlyEarning> GetValueByHour(int stateHistoryId);

    }
}