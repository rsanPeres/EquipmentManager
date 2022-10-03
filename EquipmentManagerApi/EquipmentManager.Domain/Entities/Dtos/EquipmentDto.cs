using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManager.Domain.Entities.Dtos
{
    //Todo: DTOs não são entidades. Leve os para a camada Application
    public class EquipmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EquipmentModelId { get; set; }
        public EquipmentModel EquipmentModel { get; set; }
    }
}
