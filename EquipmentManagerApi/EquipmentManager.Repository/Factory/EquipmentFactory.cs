using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManager.Repository.Factory
{
    public class EquipmentFactory : IEquipmentFactory 
    {
        public Equipment Factory(string name, EquipmentModel equipmentModel)
        {
            return new Equipment(name, equipmentModel);
        }
    }
}
