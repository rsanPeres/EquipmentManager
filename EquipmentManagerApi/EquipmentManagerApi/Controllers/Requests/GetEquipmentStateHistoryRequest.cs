using EquipmentManager.Domain.Entities;

namespace EquipmentManagerApi.Controllers.Requests
{
    public class GetEquipmentStateHistoryRequest
    {
        public int Id { get; private set; }
        public DateTime ReportedStatusStartDate { get; private set; }
    }
}
