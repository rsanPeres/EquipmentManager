﻿using Flunt.Notifications;
using Flunt.Validations;

namespace EquipmentManager.Domain.Entities
{
    public class EquipmentModel : Notifiable<Notification>
    {

        public int Id { get; private set; }
        public string ModelName { get; private set; }
        public ICollection<Equipment> Equipments { get; private set; }
        public ICollection<EquipmentModelStateHourlyEarning> EquipmentsStateHourlyEarning { get; private set; }

        public EquipmentModel(string modelName)
        {
            Validate(modelName);

            if (!IsValid)
                return;
            ModelName = modelName;
            Equipments = new List<Equipment>();
            EquipmentsStateHourlyEarning = new List<EquipmentModelStateHourlyEarning>();
        }

        public void setModelName(string name)
        {
            this.ModelName = name;
        }

        public void Validate(string name)
        {
            AddNotifications(new Contract<Notification>()
               .IsNotNullOrEmpty(name, "invalid_name", "Invalid name")
               .IsGreaterThan(name.Length, 2, "invalid_size_name", "Invalid size name"));
        }
    }
}
