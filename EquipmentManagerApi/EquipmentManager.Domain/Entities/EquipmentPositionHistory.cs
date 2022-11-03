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

        protected EquipmentPositionHistory() { }

        public EquipmentPositionHistory(string latitude, string length, Equipment equipment)
        {
            Validate(length, latitude, DateTime.UtcNow);
            if (!IsValid)
                return;

            Latitude = latitude;
            Length = length;
            Equipment = equipment;
            DateRegisteredPosition = DateTime.UtcNow;
        }

        public void Validate(string length, string latitude, DateTime date)
        {
            AddNotifications(new Contract<Notification>()
               .IsNotNullOrEmpty(length, "invalid_length", "Invalid length")
               .IsGreaterThan(length.Length, 1, "invalid_size_length", "Invalid size length")
               .IsNotNullOrEmpty(latitude, "invalid_latitude", "Invalid latitude")
               .IsGreaterThan(latitude.Length, 1, "invalid_size_latitude", "Invalid size latitude")
               .IsGreaterThan(date, DateTime.MinValue, "DateTime_not_Valid", "Invalid date"));
        }
    }
}
