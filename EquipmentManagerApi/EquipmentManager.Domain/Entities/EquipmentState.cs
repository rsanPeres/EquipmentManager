using Flunt.Notifications;
using Flunt.Validations;

namespace EquipmentManager.Domain.Entities
{
    public class EquipmentState : Notifiable<Notification>
    {
        public int Id { get; private set; }
        public string StateName { get; private set; }
        public string EquipmentColor { get; private set; }
        public ICollection<EquipmentModelStateHourlyEarning> EquipmentsStateHourlyEarning { get; private set; }
        public ICollection<EquipmentStateHistory> EquipmentStatesHistory { get; private set; }

        public EquipmentState(string stateName, string equipmentColor)
        {
            Validate(stateName, equipmentColor);
            if (!IsValid)
                return;

            StateName = stateName;
            EquipmentColor = equipmentColor;
            EquipmentsStateHourlyEarning = new List<EquipmentModelStateHourlyEarning>();
            EquipmentStatesHistory = new List<EquipmentStateHistory>();
        }

        public void Validate(string stateName, string equipmentColor)
        {
            AddNotifications(new Contract<Notification>()
               .IsNotNullOrEmpty(stateName, "invalid_userName", "Invalid userName")
               .IsGreaterThan(stateName.Length, 2, "invalid_size_userName", "Invalid size userName")
               .IsNotNullOrEmpty(equipmentColor, "invalid_password", "Invalid password")
               .IsGreaterThan(equipmentColor.Length, 3, "invalid_size_password", "Invalid size password"));
        }
    }
}
