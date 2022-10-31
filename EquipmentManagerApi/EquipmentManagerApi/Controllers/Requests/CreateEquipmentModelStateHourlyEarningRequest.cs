using EquipmentManager.Domain.Entities;

namespace EquipmentManagerApi.Controllers.Requests
{
    public class CreateEquipmentModelStateHourlyEarningRequest
    {
        public int EquipmentModelId { get; private set; }
        public int EquipmentStateId { get; private set; }
        public Decimal EarnedValueByHourState { get; private set; }
    }
}
