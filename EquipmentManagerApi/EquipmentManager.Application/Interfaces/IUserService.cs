using EquipmentManager.Application.Dtos;

namespace EquipmentManager.Application.Interfaces
{
    public interface IUserService
    {
        void Create(UserDto userDto);
        void Delete(UserDto userDto);
        UserDto Get(string cpf);
        List<UserDto> GetMany();
        void Update(UserDto userDto);
    }
}