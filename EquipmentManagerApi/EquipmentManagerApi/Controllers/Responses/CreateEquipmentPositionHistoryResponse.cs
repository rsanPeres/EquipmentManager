using EquipmentManager.Domain.Entities;

namespace EquipmentManagerApi.Controllers.Responses
{
    public class CreateEquipmentPositionHistoryResponse
    {
        public int Id { get; set; }
        public DateTime DateRegisteredPosition { get; set; }
        public string Latitude { get; set; }
        public string Length { get; set; }
        public Equipment Equipment { get; set; }
    }
}
