using EquipmentManager.Domain.Enums;
using Flunt.Notifications;

namespace EquipmentManager.Domain.Entities
{
    public class User : Notifiable<Notification>
    {
        public int Id { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public RoleNames Role { get; private set; }
        public string Cpf { get; private set; }

        public User(string userName, string password, RoleNames role, string cpf)
        {
            if (string.IsNullOrEmpty(userName))
            {
                AddNotification("UserName", "Invalid userName");
            }
            UserName = userName;
            if (string.IsNullOrEmpty(password))
            {
                AddNotification("Password", "Invalid password");
            }
            Password = password;
            Role = role;
            if (string.IsNullOrEmpty(cpf))
            {
                AddNotification("CPF", "Invalid cpf");
            }
            Cpf = cpf;
        }

        public void setEmployeeRole(RoleNames role)
        {
            switch (role)
            {
                case RoleNames.Manager:
                    this.Role = RoleNames.Manager;
                    break;
                default:
                    this.Role = RoleNames.Employee;
                    break;
            }
        }
    }
}
