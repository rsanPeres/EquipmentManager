using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (string.IsNullOrEmpty(stateName))
            {
                AddNotification("Name", "Invalid name");
            }
            StateName = stateName;
            if (string.IsNullOrEmpty(equipmentColor))
            {
                AddNotification("EquipmentColor", "Invalid color");
            }
            EquipmentColor = equipmentColor;
        }
    }
}
