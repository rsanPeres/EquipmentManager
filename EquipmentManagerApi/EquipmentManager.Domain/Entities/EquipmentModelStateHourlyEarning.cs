using Flunt.Notifications;

namespace EquipmentManager.Domain.Entities
{
    public class EquipmentModelStateHourlyEarning
    {
        public int EquipmentModelId { get; private set; }
        public EquipmentModel EquipmentModel { get; private set; }
        public int EquipmentStateId { get; private set; }
        public EquipmentState EquipmentState { get; private set; }
        public Decimal EarnedValueByHourState { get; private set; }
    }
}
