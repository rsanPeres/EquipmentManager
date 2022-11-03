using EquipmentManager.Domain.Entities;

namespace EquipmentManagerApi.Controllers.Responses
{
    public class CreateEquipmentStateHistoryResponse
    {
        public int Id { get; set; }
        public DateTime ReportedStatusStartDate { get; set; }
        public Equipment Equipment { get; set; }
        public EquipmentState EquipmentState { get; set; }
    }
}
