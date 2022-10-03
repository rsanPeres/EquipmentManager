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
        public string Name { get; private set; }
        public string Color { get; private set; }
        public ICollection<EquipmentModelStateHourlyEarning> EquipmentsStateHourlyEarning { get; private set; }
        public ICollection<EquipmentStateHistory> EquipmentStatesHistory { get; private set; }


    }
}
