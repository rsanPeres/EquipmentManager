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
        //Todo: pode-se optar por mapeamento ORM por annotations ou FluentApi. Mas já que está usando FluentApi,melhor concentrar essas validações por lá
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
        
        //Todo: é importante inciailizar esta collection
    }
}
