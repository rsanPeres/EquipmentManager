using Flunt.Notifications;
using Flunt.Validations;
using System.Security.Cryptography.X509Certificates;

namespace EquipmentManager.Domain.Entities
{
    public class EquipmentStateHistory : Notifiable<Notification>
    {
        public int Id { get; private set; }
        public DateTime ReportedStatusStartDate { get; private set; }
        public Equipment Equipment { get; private set; }
        public EquipmentState EquipmentState { get; private set; }

        public EquipmentStateHistory(DateTime reportedStatusStartDate, Equipment equipment, EquipmentState equipmentState)
        {
            Validate(reportedStatusStartDate, equipment, equipmentState);
            if(!IsValid)
                return;

            ReportedStatusStartDate = reportedStatusStartDate;
            Equipment = equipment;
            EquipmentState = equipmentState;
        }

        public void Validate(DateTime date, Equipment equipment, EquipmentState equipmentState)
        {
            AddNotifications(new Contract<Notification>()
                .IsGreaterThan(date, DateTime.UtcNow, "Invalid_Date", "Invalid date")
                .IsNotNull(equipment, "Null_Equipment", "Equipment should not be null")
                .IsNotNull(equipmentState, "Null_Equipment_State", "EquipmentState should not be null")
                );
        }
    }
}
