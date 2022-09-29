using EquipmentManager.Domain.Entities.Enuns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManager.Domain.Entities
{
    public class EmployeeRoleNames
    {
        [Required]
        public int EmployeeRoleId { get
            {
                return (int)this.RoleName;
            }
            set 
            {
                RoleName = (RoleNames)value;
            } 
        }
        [EnumDataType(typeof(RoleNames))]
        public RoleNames RoleName { get; set; }

        public ICollection<User> Users { get; set; }    
    }
}
