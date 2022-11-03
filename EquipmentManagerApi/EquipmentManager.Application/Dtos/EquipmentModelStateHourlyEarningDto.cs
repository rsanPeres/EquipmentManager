using EquipmentManager.Domain.Entities;

namespace EquipmentManager.Application.Dtos
{
    public class EquipmentModelStateHourlyEarningDto
    {
        public EquipmentModel EquipmentModelId { get; set; }
        public EquipmentModel EquipmentModel { get; set; }
        public EquipmentState EquipmentState { get; set; }
        public EquipmentState EquipmentStateId { get; set; }
        public Decimal EarnedValueByHourState { get; set; }
    }
}
