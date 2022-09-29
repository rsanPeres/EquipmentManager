using EquipmentManager.Domain.Entities.Enuns;

namespace EquipmentManagerApi.Controllers.Requests
{
    public class CreateUserRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public RoleNames Role { get; set; }
        public string Cpf { get; set; }
    }
}
