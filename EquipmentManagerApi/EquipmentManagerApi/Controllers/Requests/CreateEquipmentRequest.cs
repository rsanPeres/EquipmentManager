using EquipmentManager.Application.Dtos;
using EquipmentManager.Domain.Entities;

namespace EquipmentManagerApi.Controllers.Requests
{
    public class CreateEquipmentRequest
    {
        public string Name { get; set; }
        public EquipmentModelDto EquipmentModel { get; set; }
    }

}
