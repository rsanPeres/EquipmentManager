namespace EquipmentManagerApi.Controllers.Requests
{
    public class CreateUserRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Cpf { get; set; }
    }
}
