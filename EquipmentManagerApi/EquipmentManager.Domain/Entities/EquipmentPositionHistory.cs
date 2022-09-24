using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManager.Domain.Entities
{
    public class EquipmentPositionHistory : Notifiable<Notification>
    {
        public int Id { get; set; }
        public DateTime DateRegisteredPosition { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
    }
}
