using EquipmentManager.Domain.Entities;

namespace EquipmentManagerApi.Controllers.Requests
{
    public class GetEquipmentModelStateHourlyEarningRequest
    {
        public int EquipmentModelId { get; private set; }
        public EquipmentModel EquipmentModel { get; private set; }
        public int EquipmentStateId { get; private set; }
    }
}
