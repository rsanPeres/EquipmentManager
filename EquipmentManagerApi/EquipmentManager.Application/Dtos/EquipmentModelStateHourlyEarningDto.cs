using EquipmentManager.Domain.Entities;

namespace EquipmentManager.Application.Dtos
{
    public class EquipmentModelStateHourlyEarningDto
    {
        public EquipmentModel EquipmentModelId { get; private set; }
        public EquipmentModel EquipmentModel { get; private set; }
        public EquipmentState EquipmentState { get; private set; }
        public EquipmentState EquipmentStateId { get; private set; }
        public Decimal EarnedValueByHourState { get; private set; }
    }
}
