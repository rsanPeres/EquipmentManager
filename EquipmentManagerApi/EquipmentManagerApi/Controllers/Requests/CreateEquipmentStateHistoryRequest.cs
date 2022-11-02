using EquipmentManager.Domain.Entities;

namespace EquipmentManagerApi.Controllers.Requests
{
    public class CreateEquipmentStateHistoryRequest
    {
        public int Id { get; private set; }
        public DateTime ReportedStatusStartDate { get; private set; }
    }
}
