using EquipmentManager.Application.Dtos;
using EquipmentManager.Domain.Entities;

namespace EquipmentManagerApi.Controllers.Requests
{
    public class CreateEquipmentStateHistoryRequest
    {
        public GetEquipmentRequest Equipment { get; set; }
        public CreateEquipmentStateRequest EquipmentState { get; set; }
    }
}
