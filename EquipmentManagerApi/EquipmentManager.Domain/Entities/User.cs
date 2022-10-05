﻿using EquipmentManager.Domain.Enums;
using Flunt.Notifications;
using Flunt.Validations;

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
            Validate(userName, password, role, cpf);
            if (!IsValid)
                return;

            UserName = userName;
            Password = password;
            Role = role;
            Cpf = cpf;
        }

        public void SetEmployeeRole(RoleNames role)
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

        public void Validate(string userName, string password, RoleNames role, string cpf)
        {
            AddNotifications(new Contract<Notification>()
               .IsNotNullOrEmpty(userName, "invalid_userName", "Invalid userName")
               .IsGreaterThan(userName.Length, 2, "invalid_size_userName", "Invalid size userName")
               .IsNotNullOrEmpty(password, "invalid_password", "Invalid password")
               .IsGreaterThan(password.Length, 8, "invalid_size_password", "Invalid size password")
               .IsNotNull(role, "invalid_role", "Invalid role")
               .IsNotNullOrEmpty(cpf, "invalid_cpf", "Invalid cpf")
               .IsGreaterThan(cpf.Length, 11, "invalid_size_cpf", "Invalid size cpf"));
        }
    }
}
