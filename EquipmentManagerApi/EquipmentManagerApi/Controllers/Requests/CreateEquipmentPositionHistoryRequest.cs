using EquipmentManager.Domain.Entities;

namespace EquipmentManagerApi.Controllers.Requests
{
    public class CreateEquipmentPositionHistoryRequest
    {
        public DateTime DateRegisteredPosition { get; private set; }
        public string Latitude { get; private set; }
        public string Length { get; private set; }
        public Equipment Equipment { get; private set; }
    }
}
