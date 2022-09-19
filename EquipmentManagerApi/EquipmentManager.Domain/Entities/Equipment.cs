﻿using Flunt.Notifications;

namespace EquipmentManager.Domain.Entities
{
    public class Equipment : Notifiable<Notification>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EquipmentModelId { get; set; }
        public EquipmentModel EquipmentModel { get; set; }

        public Equipment()
        {

        }
    }
}
