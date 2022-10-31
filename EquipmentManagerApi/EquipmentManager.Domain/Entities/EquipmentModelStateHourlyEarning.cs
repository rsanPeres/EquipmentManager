using Flunt.Notifications;
using Flunt.Validations;

namespace EquipmentManager.Domain.Entities
{
    public class EquipmentModelStateHourlyEarning : Notifiable<Notification>
    {
        public int EquipmentModelId { get; private set; }
        public EquipmentModel EquipmentModel { get; private set; }
        public int EquipmentStateId { get; private set; }
        public EquipmentState EquipmentState { get; private set; }
        public Decimal EarnedValueByHourState { get; private set; }

        public EquipmentModelStateHourlyEarning(decimal earnedValueByHourState, EquipmentModel model, EquipmentState state)
        {
            Validate(earnedValueByHourState);
            if (!IsValid)
                return;

            EarnedValueByHourState = earnedValueByHourState;
            EquipmentModel = model;
            EquipmentState = state;
        }

        public void Validate(decimal earnedValue)
        {
            AddNotifications(new Contract<Notification>()
                .IsNotNull(earnedValue,"earnedValueNull", "Value cannot be null"));
        }
    }
}
