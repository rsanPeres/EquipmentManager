using EquipmentManager.Domain.Entities;

namespace EquipmentManagerApi.Controllers.Responses
{
    public class GetEquipmentStateHistoryResponse
    {
        public int Id { get; set; }
        public DateTime ReportedStatusStartDate { get; set; }
    }
}
