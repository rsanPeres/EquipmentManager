using EquipmentManager.Domain.Entities;

namespace EquipmentManagerApi.Controllers.Requests
{
    public class CreateEquipmentRequest
    {
        public string Name { get; set; }
        public EquipmentModel EquipmentModel { get; set; }
    }

}
