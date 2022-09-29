using EquipmentManager.Domain.Entities.Enuns;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManager.Domain.Entities
{
    public class User : Notifiable<Notification>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public RoleNames Role { get; set; }
        public string Cpf { get; set; }

        public User(string userName, string password, RoleNames role, string cpf)
        {
            UserName = userName;
            Password = password;
            Role = role;
            Cpf = cpf;
        }

        public void EnumSet(string role) {
            switch (role.ToLower())
            {
                case "manager":
                    this.Role = RoleNames.Manager;
                    break;
                default:
                    this.Role = RoleNames.Employee;
                    break;
            }
        }
    }
}
