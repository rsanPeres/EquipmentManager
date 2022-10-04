using Flunt.Notifications;

namespace EquipmentManager.Domain.Entities
{
    public class Equipment : Notifiable<Notification>
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public EquipmentModel EquipmentModel { get; private set; }
        public ICollection<EquipmentStateHistory> EquipmentStatesHistory { get; private set; }
        public ICollection<EquipmentPositionHistory> EquipmentPositionHistories { get; private set; }

        public Equipment(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                AddNotification("Name", "Invalid name");
            }
            Name = name;
            EquipmentStatesHistory = new List<EquipmentStateHistory>();
            EquipmentPositionHistories = new List<EquipmentPositionHistory>();
        }

        public void setName(string name)
        {
            this.Name = name;
        }
    }
}
