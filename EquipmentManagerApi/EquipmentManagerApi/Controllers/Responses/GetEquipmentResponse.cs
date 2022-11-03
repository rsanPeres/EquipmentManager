using EquipmentManager.Application.Dtos;
using EquipmentManager.Domain.Entities;

namespace EquipmentManagerApi.Controllers.Responses
{
    public class GetEquipmentResponse
    {
        public string Name { get; set; }
        public EquipmentModelDto EquipmentModel { get; set; }
        public List<EquipmentStateHistory> EquipmentStatesHistory { get; set; }
        public List<EquipmentPositionHistory> EquipmentPositionHistories { get; set; }
    }
}
