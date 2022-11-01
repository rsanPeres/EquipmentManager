using EquipmentManager.Domain.Entities;

namespace EquipmentManager.Application.Dtos
{
    public class EquipmentStateDto
    {
        public int Id { get; private set; }
        public string StateName { get; private set; }
        public string EquipmentColor { get; private set; }
        public ICollection<EquipmentModelStateHourlyEarning> EquipmentsStateHourlyEarning { get; private set; }
        public ICollection<EquipmentStateHistory> EquipmentStatesHistory { get; private set; }
    }
}
