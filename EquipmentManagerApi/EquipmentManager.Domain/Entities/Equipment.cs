using Flunt.Notifications;

namespace EquipmentManager.Domain.Entities
{
    public class Equipment : Notifiable<Notification>
    {
        //Todo: Setters devem ser privados. O estado da entidade deve ser alterado por meio de operações.

        public int Id { get; set; }
        public string Name { get; set; }

        //Todo: pq precisa desta prop, já que abaixo vc referencia o objjeto?
        public int EquipmentModelId { get; set; }
        public EquipmentModel EquipmentModel { get; set; }
        public ICollection<EquipmentStateHistory> EquipmentStatesHistory { get; set; }
        public ICollection<EquipmentPositionHistory> EquipmentPositionHistories { get; set; }

        //Todo: É válido ter um equipamento sem modelo? Seu código está dizendo que sim
        public Equipment(string name)
        {
            Name = name;
        }
    }
}
