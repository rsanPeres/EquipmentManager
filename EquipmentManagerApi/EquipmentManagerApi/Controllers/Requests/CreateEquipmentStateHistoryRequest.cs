using EquipmentManager.Application.Dtos;
using EquipmentManager.Domain.Entities;

namespace EquipmentManagerApi.Controllers.Requests
{
    public class CreateEquipmentStateHistoryRequest
    {
        public int Id { get; private set; }
        public DateTime ReportedStatusStartDate { get; set; }
        public GetEquipmentRequest Equipment { get; set; }
        public CreateEquipmentStateRequest EquipmentState { get; set; }
    }
}
