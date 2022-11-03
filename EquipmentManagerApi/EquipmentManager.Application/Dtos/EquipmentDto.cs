using EquipmentManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManager.Application.Dtos
{
    public class EquipmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EquipmentModelDto EquipmentModel { get; set; }
    }
}
