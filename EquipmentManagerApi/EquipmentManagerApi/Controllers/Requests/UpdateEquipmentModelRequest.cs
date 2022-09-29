using EquipmentManager.Domain.Entities.Enuns;

namespace EquipmentManagerApi.Controllers.Requests
{
    public class UpdateEquipmentModelRequest
    {
        public int Id { get; set; }
        public RoleNames Name { get; set; }
    }
}
