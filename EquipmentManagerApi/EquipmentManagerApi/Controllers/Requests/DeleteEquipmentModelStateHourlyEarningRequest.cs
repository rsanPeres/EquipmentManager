using EquipmentManager.Domain.Entities;

namespace EquipmentManagerApi.Controllers.Requests
{
    public class DeleteEquipmentModelStateHourlyEarningRequest
    {
        public int EquipmentModelId { get; private set; }
        public int EquipmentStateId { get; private set; }
    }
}
