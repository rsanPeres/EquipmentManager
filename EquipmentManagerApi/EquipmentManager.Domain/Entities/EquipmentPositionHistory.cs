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
        public int Id { get; private set; }
        public DateTime DateRegisteredPosition { get; private set; }
        public string Latitude { get; private set; }
        public string Longitude { get; private set; }
        public int EquipmentId { get; private set; }
        public Equipment Equipment { get; private set; }

        public EquipmentPositionHistory(string latitude, string longitude)
        {
            if (string.IsNullOrEmpty(latitude))
            {
                AddNotification("Latitude", "Invalid latitude");
            }
            Latitude = latitude;
            if (string.IsNullOrEmpty(longitude))
            {
                AddNotification("Longitude", "Invalid longitude");
            }
            Longitude = longitude;
        }
    }
}
