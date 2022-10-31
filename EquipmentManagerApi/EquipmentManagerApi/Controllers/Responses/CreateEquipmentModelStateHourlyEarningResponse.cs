using EquipmentManager.Domain.Entities;

namespace EquipmentManagerApi.Controllers.Responses
{
    public class CreateEquipmentModelStateHourlyEarningResponse
    {
        public EquipmentModel EquipmentModel { get; private set; }
        public EquipmentState EquipmentState { get; private set; }
        public Decimal EarnedValueByHourState { get; private set; }
    }
}
