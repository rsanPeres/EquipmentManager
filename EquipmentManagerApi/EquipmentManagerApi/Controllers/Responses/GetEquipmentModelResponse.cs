using EquipmentManager.Domain.Entities;

namespace EquipmentManagerApi.Controllers.Responses
{
    public class GetEquipmentModelResponse
    {
        public string Name { get; set; }
        public List<Equipment> Equipments{ get; set; }

    }
}
