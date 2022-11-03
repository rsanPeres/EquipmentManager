using EquipmentManager.Application.Dtos;
using EquipmentManager.Domain.Entities;

namespace EquipmentManagerApi.Controllers.Requests
{
    public class CreateEquipmentPositionHistoryRequest
    {
        public DateTime DateRegisteredPosition { get; set; }
        public string Latitude { get; set; }
        public string Length { get; set; }
        public EquipmentDto Equipment { get; set; }
    }
}
