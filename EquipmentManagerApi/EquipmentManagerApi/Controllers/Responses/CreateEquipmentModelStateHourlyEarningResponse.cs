using EquipmentManager.Domain.Entities;

namespace EquipmentManagerApi.Controllers.Responses
{
    public class CreateEquipmentModelStateHourlyEarningResponse
    {
        public EquipmentModel EquipmentModel { get; set; }
        public EquipmentState EquipmentState { get; set; }
        public Decimal EarnedValueByHourState { get; set; }
    }
}
