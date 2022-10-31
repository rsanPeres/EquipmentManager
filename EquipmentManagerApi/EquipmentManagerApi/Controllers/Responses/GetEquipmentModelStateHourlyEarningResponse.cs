using EquipmentManager.Domain.Entities;

namespace EquipmentManagerApi.Controllers.Responses
{
    public class GetEquipmentModelStateHourlyEarningResponse
    {
        public int EquipmentModelId { get; private set; }
        public int EquipmentStateId { get; private set; }
    }
}
