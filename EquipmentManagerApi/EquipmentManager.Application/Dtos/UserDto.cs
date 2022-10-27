﻿using EquipmentManager.Domain.Enums;

namespace EquipmentManager.Application.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public RoleNames Role { get; set; }
        public string Cpf { get; set; }
    }
}
