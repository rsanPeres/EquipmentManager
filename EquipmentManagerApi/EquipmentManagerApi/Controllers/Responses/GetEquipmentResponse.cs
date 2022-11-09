using EquipmentManager.Application.Dtos;
using EquipmentManager.Domain.Entities;

namespace EquipmentManagerApi.Controllers.Responses
{
    public class GetEquipmentResponse
    {
        public string Name { get; set; }
        public GetEquipmentModelResponse EquipmentModel { get; set; }
        public List<GetEquipmentStateHistoryResponse> EquipmentStatesHistory { get; set; }
        public List<GetEquipmentPositionHistoryResponse> EquipmentPositionHistories { get; set; }
    }
}
