using EquipmentManager.Domain.Entities;

namespace EquipmentManagerApi.Controllers.Responses
{
    public class CreateEquipmentPositionHistoryResponse
    {
        public int Id { get; private set; }
        public DateTime DateRegisteredPosition { get; private set; }
        public string Latitude { get; private set; }
        public string Length { get; private set; }
        public Equipment Equipment { get; private set; }
    }
}
