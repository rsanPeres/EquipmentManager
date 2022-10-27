using EquipmentManager.Domain.Entities;
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

        public void Create(User user)
        {
            _appContext.Database.EnsureCreated();
            _appContext.Users.Add(user);
        }

        public User Get(string cpf)
        {
            var user = _appContext.Users.Find(cpf);
            return user;
        }

        public List<User> GetMany()
        {
            var user = _appContext.Users.ToList();
            return user;
        }

        public void Update(User user)
        {
            _appContext.Update(user);
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
        public void EnsureCreatedDatabase()
        {
            try
            {
                _appContext.Database.EnsureCreated();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
