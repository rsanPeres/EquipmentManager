using EquipmentManager.Domain.Entities;

namespace EquipmentManagerApi.Controllers.Responses
{
    public class GetValueByEquipmentStateResponse
    {
        public Dictionary<string, EquipmentModelStateHourlyEarning> ValueByState { get; set; }
    }
}
