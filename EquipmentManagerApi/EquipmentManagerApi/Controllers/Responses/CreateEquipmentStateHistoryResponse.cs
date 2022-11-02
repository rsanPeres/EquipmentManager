using EquipmentManager.Domain.Entities;

namespace EquipmentManagerApi.Controllers.Responses
{
    public class CreateEquipmentStateHistoryResponse
    {
        public int Id { get; private set; }
        public DateTime ReportedStatusStartDate { get; private set; }
        public Equipment Equipment { get; private set; }
        public EquipmentState EquipmentState { get; private set; }
    }
}
