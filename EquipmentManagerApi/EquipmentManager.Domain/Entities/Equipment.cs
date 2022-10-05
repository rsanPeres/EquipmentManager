using Flunt.Notifications;
using Flunt.Validations;

namespace EquipmentManager.Domain.Entities
{
    public class Equipment : Notifiable<Notification>
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public EquipmentModel EquipmentModel { get; private set; }
        public ICollection<EquipmentStateHistory> EquipmentStatesHistory { get; private set; }
        public ICollection<EquipmentPositionHistory> EquipmentPositionHistories { get; private set; }

        protected Equipment() { }

        public Equipment(string name, EquipmentModel equipmentModel)
        {
            Validate(name, equipmentModel);

            if (!IsValid)
                return;

            Name = name;
            EquipmentModel = equipmentModel;
            EquipmentStatesHistory = new List<EquipmentStateHistory>();
            EquipmentPositionHistories = new List<EquipmentPositionHistory>();
        }

        public void Update(string name, EquipmentModel equipmentModel)
        {
            Validate(name, equipmentModel);

            if (!IsValid)
                return;

            Name = name;
        }
        public void Validate(string name, EquipmentModel equipmentModel)
        {
            AddNotifications(new Contract<Notification>()
               .IsNotNullOrEmpty(name, "invalid_name", "Invalid name")
               .IsGreaterThan(name.Length, 2, "invalid_size_name", "Invalid size name")
               .IsNotNull(equipmentModel, "invalid_equipmentModel", "Invalid equipmentModel"));

        }
    }
}
