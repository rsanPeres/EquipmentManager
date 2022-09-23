using EquipmentManager.Domain.Entities;

namespace EquipmentManagerApi.Controllers.Requests
{
    public class CreateEquipmentRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EquipmentModelId { get; set; }
        public EquipmentModel EquipmentModel { get; set; }
    }
}
