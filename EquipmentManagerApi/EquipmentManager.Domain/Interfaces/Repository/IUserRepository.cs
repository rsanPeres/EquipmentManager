using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Enums;

namespace EquipmentManager.Domain.Interfaces.Repository
{
    public interface IUserRepository
    {
        public User Get(string cpf);
        public User Create(User user);
        public User Update(User user);
        public void Delete(string cpf);
    }
}
