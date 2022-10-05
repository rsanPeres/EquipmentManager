using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Enums;
using EquipmentManager.Domain.Interfaces.Repository;
using EquipmentManager.Infrastructure;

namespace EquipmentManager.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _appContext;

        public UserRepository(ApplicationContext appContext)
        {
            _appContext = appContext;
        }

        public User Create(User user)
        {
            _appContext.User.Add(user);
            return user;
        }

        public User Get(string cpf)
        {
            var user = _appContext.User.Find(cpf);
            return user;
        }

        public User Update(User user)
        {
            _appContext.Update(user);
            return user;
        }

        public void Delete(string cpf)
        {
            var user = Get(cpf);
            _appContext.Remove<User>(user);
        }
        public void SaveChanges()
        {
            _appContext.SaveChanges();
        }
    }
}
