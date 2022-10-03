using Flunt.Notifications;

namespace EquipmentManager.Domain.Entities
{
    public class Equipment : Notifiable<Notification>
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        //Todo: pq precisa desta prop, já que abaixo vc referencia o objjeto?
        public int EquipmentModelId { get; private set; }
        public EquipmentModel EquipmentModel { get; set; }
        public ICollection<EquipmentStateHistory> EquipmentStatesHistory { get; private set; }
        public ICollection<EquipmentPositionHistory> EquipmentPositionHistories { get; private set; }

        public Equipment(string name, EquipmentModel equipmentModel)
        {
            Name = name;
            EquipmentModel.Id = equipmentModel.Id;
            EquipmentStatesHistory = new List<EquipmentStateHistory>();
            EquipmentPositionHistories = new List<EquipmentPositionHistory>();
        }
    }
}
