using EquipmentManager.Domain.Entities;
using EquipmentManager.Infrastructure;

namespace EquipmentManager.Repository.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        public ApplicationContext _appContext;

        public LoginRepository(ApplicationContext appContext)
        {
            _appContext = appContext;
        }

        public User Get(string userName)
        {
            var user = _appContext.User
                       .Where(us => us.UserName == userName)
                       .FirstOrDefault<User>();
            return user;
        }
    }
}
