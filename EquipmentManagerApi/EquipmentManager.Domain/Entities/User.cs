using EquipmentManager.Domain.Enums;
using Flunt.Notifications;

namespace EquipmentManager.Domain.Entities
{
    public class User : Notifiable<Notification>
    {
        public int Id { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public RoleNames Role { get; set; }
        public string Cpf { get; private set; }

        public User(string userName, string password, RoleNames role, string cpf)
        {
            UserName = userName;
            Password = password;
            Role = role;
            Cpf = cpf;
        }

    }
}
