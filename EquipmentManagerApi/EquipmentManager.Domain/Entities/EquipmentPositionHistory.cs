using Flunt.Notifications;
using Flunt.Validations;

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
            Validate(longitude, latitude);
            if (!IsValid)
                return;

            Latitude = latitude;
            Longitude = longitude;
        }

        public void Validate(string longitude, string latitude)
        {
            AddNotifications(new Contract<Notification>()
               .IsNotNullOrEmpty(longitude, "invalid_userName", "Invalid userName")
               .IsGreaterThan(longitude.Length, 10, "invalid_size_userName", "Invalid size userName")
               .IsNotNullOrEmpty(latitude, "invalid_password", "Invalid password")
               .IsGreaterThan(latitude.Length, 10, "invalid_size_password", "Invalid size password"));
        }
    }
}
