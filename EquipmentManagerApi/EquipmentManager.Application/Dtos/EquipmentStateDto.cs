using EquipmentManager.Domain.Entities;

namespace EquipmentManager.Application.Dtos
{
    public class EquipmentStateDto
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        public string EquipmentColor { get; set; }
        public List<EquipmentModelStateHourlyEarning> EquipmentsStateHourlyEarning { get; set; }
        public List<EquipmentStateHistory> EquipmentStatesHistory { get; set; }
    }
}
