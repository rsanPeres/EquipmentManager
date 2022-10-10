using EquipmentManager.Domain.Entities;

namespace EquipmentManager.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}