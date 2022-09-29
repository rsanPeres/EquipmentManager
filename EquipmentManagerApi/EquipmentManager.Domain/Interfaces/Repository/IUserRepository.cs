using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Entities.Enuns;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManager.Domain.Interfaces.Repository
{
    public interface IUserRepository
    {
        public User Get(string cpf);
        public User Create(User user);
        public User Update(string name, RoleNames role);
        public void Delete(string cpf);
    }
}
