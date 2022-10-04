using Flunt.Notifications;

namespace EquipmentManager.Domain.Entities
{
    public class Equipment : Notifiable<Notification>
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public EquipmentModel EquipmentModel { get; set; }
        public ICollection<EquipmentStateHistory> EquipmentStatesHistory { get; private set; }
        public ICollection<EquipmentPositionHistory> EquipmentPositionHistories { get; private set; }

        public Equipment(string name)
        {

            //Todo: Usou o Flunt mas não validou a entidade?

            Name = name;
            EquipmentStatesHistory = new List<EquipmentStateHistory>();
            EquipmentPositionHistories = new List<EquipmentPositionHistory>();
        }
    }
}
