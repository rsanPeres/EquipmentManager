using EquipmentManager.Application.Dtos;

namespace EquipmentManager.Application.Interfaces
{
    public interface ILoginService
    {
        UserDto VerifyUserPassword(UserDto user);
    }
}