using Flunt.Notifications;
using Flunt.Validations;

namespace EquipmentManager.Domain.Entities
{
    public class EquipmentStateHistory : Notifiable<Notification>
    {
        public int Id { get; private set; }
        public DateTime ReportedStatusStartDate { get; private set; }
        public Equipment Equipment { get; private set; }
        public EquipmentState EquipmentState { get; private set; }

        public EquipmentStateHistory() { }
        public EquipmentStateHistory(Equipment equipment, EquipmentState equipmentState)
        {
            ReportedStatusStartDate = DateTime.UtcNow;
            Equipment = equipment;
            EquipmentState = equipmentState;
        }

        public void Validate(DateTime date)
        {
            AddNotifications(new Contract<Notification>()
                .IsGreaterThan(date, DateTime.UtcNow, "Invalid_Date", "Invalid date")
                //.IsNotNull(equipment, "Null_Equipment", "Equipment should not be null")
                //.IsNotNull(equipmentState, "Null_Equipment_State", "EquipmentState should not be null")
                );
        }
    }
}
