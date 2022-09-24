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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public ICollection<EquipmentModelStateHourlyEarning> EquipmentsStateHourlyEarning { get; set; }
        public ICollection<EquipmentStateHistory> EquipmentStatesHistory { get; set; }


    }
}
