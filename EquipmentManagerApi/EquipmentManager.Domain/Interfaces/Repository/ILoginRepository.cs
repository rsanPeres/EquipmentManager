using EquipmentManager.Domain.Entities;

namespace EquipmentManager.Repository.Repositories
{
    public interface ILoginRepository
    {
        public User Get(string userName);
    }
}