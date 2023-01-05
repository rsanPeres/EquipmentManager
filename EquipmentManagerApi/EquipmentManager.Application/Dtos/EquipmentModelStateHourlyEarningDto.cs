using EquipmentManager.Domain.Entities;

namespace EquipmentManager.Application.Dtos
{
    public class EquipmentModelStateHourlyEarningDto
    {
        public int EquipmentModelId { get; set; }
        public EquipmentModelDto EquipmentModel { get; set; }
        public EquipmentStateDto EquipmentState { get; set; }
        public int EquipmentStateId { get; set; }
        public Decimal EarnedValueByHourState { get; set; }
    }
}
