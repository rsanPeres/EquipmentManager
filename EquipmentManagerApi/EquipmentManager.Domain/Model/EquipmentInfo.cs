using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManager.Domain.Model
{
    public class EquipmentInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EquipmentModelId { get; set; }
    }
}
