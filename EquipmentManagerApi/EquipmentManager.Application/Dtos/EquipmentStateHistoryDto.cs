using EquipmentManager.Domain.Entities;

namespace EquipmentManager.Application.Dtos
{
    public class EquipmentStateHistoryDto
    {
        public int Id { get; private set; }
        public DateTime ReportedStatusStartDate { get; private set; }
        public Equipment Equipment { get; private set; }
        public EquipmentState EquipmentState { get; private set; }
    }
}
