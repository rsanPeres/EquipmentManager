using Flunt.Notifications;
using Flunt.Validations;

namespace EquipmentManager.Domain.Entities
{
    public class EquipmentPositionHistory : Notifiable<Notification>
    {
        public int Id { get; private set; }
        public DateTime DateRegisteredPosition { get; private set; }
        public string Latitude { get; private set; }
        public string Length { get; private set; }
        public Equipment Equipment { get; private set; }

        public EquipmentPositionHistory(string latitude, string length)
        {
            Validate(length, latitude);
            if (!IsValid)
                return;

            Latitude = latitude;
            Length = length;
        }

        public void Validate(string length, string latitude)
        {
            AddNotifications(new Contract<Notification>()
               .IsNotNullOrEmpty(length, "invalid_userName", "Invalid userName")
               .IsGreaterThan(length.Length, 10, "invalid_size_userName", "Invalid size userName")
               .IsNotNullOrEmpty(latitude, "invalid_password", "Invalid password")
               .IsGreaterThan(latitude.Length, 10, "invalid_size_password", "Invalid size password"));
        }
    }
}
