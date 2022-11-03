using EquipmentManager.Domain.Entities;

namespace EquipmentManagerApi.Controllers.Responses
{
    public class GetEquipmentModelStateHourlyEarningResponse
    {
        public int EquipmentModelId { get; set; }
        public int EquipmentStateId { get; set; }
    }
}
