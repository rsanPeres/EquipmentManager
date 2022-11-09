using EquipmentManager.Domain.Entities;

namespace EquipmentManager.Application.Dtos
{
    public class EquipmentPositionHistoryDto
    {
        public int Id { get; set; }
        public DateTime DateRegisteredPosition { get; set; }
        public string Latitude { get; set; }
        public string Length { get; set; }
        public EquipmentDto Equipment { get; set; }
    }
}
