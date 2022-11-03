using EquipmentManager.Domain.Entities;

namespace EquipmentManager.Application.Dtos
{
    public class EquipmentStateHistoryDto
    {
        public int Id { get; set; }
        public DateTime ReportedStatusStartDate { get; set; }
        public EquipmentDto Equipment { get; set; }
        public EquipmentStateDto EquipmentState { get; set; }
    }
}
