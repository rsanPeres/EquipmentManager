using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Enums;

namespace EquipmentManager.Domain.Interfaces.Repository
{
    public interface IUserRepository
    {
        public User Get(string cpf);
        public void Create(User user);
        public void Update(User user);
        public void Delete(string cpf);
        public List<User> GetMany();
        public void SaveChanges();
    }
}
