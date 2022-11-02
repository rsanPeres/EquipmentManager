using EquipmentManager.Domain.Entities;

namespace EquipmentManagerApi.Controllers.Responses
{
    public class GetEquipmentStateHistoryResponse
    {
        public int Id { get; private set; }
        public DateTime ReportedStatusStartDate { get; private set; }
    }
}
