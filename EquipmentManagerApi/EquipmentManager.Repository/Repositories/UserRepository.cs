using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Enums;
using EquipmentManager.Domain.Interfaces.Repository;
using EquipmentManager.Infrastructure;

namespace EquipmentManager.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        public ApplicationContext AppContext;

        public UserRepository(ApplicationContext appContext)
        {
            AppContext = appContext;
        }

        public User Create(User user)
        {
            AppContext.Database.EnsureCreated();
            AppContext.User.Add(user);
            AppContext.SaveChanges();
            return user;
        }

        public User Get(string cpf)
        {
            AppContext.Database.EnsureCreated();
            var user = AppContext.User
                       .Where(us => us.Cpf == cpf)
                       .FirstOrDefault<User>();
            if(user == null)return null;
            return user;
        }

        public User Update(string cpf, RoleNames name)
        {
            var user = AppContext.User.First(p => p.Cpf == cpf);
            if (user != null)
            {
                AppContext.User.Where(p => p.Cpf == cpf).ToList().ForEach(p => p.setEmployeeRole(name));
                AppContext.SaveChanges();
                return user;
            }
            return null;
        }

        public void Delete(string cpf)
        {
            var user = AppContext.User.First(p => p.Cpf == cpf);
            if (user != null)
            {
                AppContext.User.Remove(user);
                AppContext.SaveChanges();
            }
        }
    }
}
