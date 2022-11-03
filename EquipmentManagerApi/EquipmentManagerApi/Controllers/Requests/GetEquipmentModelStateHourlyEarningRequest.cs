using EquipmentManager.Domain.Entities;

namespace EquipmentManagerApi.Controllers.Requests
{
    public class GetEquipmentModelStateHourlyEarningRequest
    {
        public int EquipmentModelId { get; set; }
        public int EquipmentStateId { get; set; }
    }
}
