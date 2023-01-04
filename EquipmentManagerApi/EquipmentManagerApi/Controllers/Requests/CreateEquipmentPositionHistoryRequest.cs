using EquipmentManager.Application.Dtos;
using EquipmentManager.Domain.Entities;

namespace EquipmentManagerApi.Controllers.Requests
{
    public class CreateEquipmentPositionHistoryRequest
    {
        public string Latitude { get; set; }
        public string Length { get; set; }
        public GetEquipmentRequest Equipment { get; set; }
    }
}
