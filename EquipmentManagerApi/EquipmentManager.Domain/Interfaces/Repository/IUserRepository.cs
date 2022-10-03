using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Enums;

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
