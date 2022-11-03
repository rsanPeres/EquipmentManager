using EquipmentManager.Domain.Enums;

namespace EquipmentManagerApi.Controllers.Requests
{
    public class UpdateEquipmentModelRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
