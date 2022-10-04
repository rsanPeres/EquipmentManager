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

        public EquipmentState(string name, string color)
        {
            if (string.IsNullOrEmpty(name))
            {
                AddNotification("Name", "Invalid name");
            }
            StateName = name;
            if (string.IsNullOrEmpty(color))
            {
                AddNotification("EquipmentColor", "Invalid color");
            }
            EquipmentColor = color;
        }
    }
}
