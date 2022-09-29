using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Entities.Enuns;
using EquipmentManager.Domain.Interfaces.Repository;
using EquipmentManager.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return user;
        }

        public User Update(string cpf, RoleNames name)
        {
            var user = AppContext.User.First(p => p.Cpf == cpf);
            if (user != null)
            {
                AppContext.User.Where(p => p.Cpf == cpf).ToList().ForEach(p => p.Role = name);
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
