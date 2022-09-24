using Flunt.Notifications;
using System;
using System.Collections.Generic;
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
        public string Role { get; set; }
        public string Cpf { get; set; }

        public User(int id, string userName, string password, string role, string cpf)
        {
            Id = id;
            UserName = userName;
            Password = password;
            Role = role;
            Cpf = cpf;
        }
    }
}
