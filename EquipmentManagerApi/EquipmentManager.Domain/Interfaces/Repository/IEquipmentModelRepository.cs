using EquipmentManager.Domain.Entities;

namespace EquipmentManager.Domain.Interfaces.Repository
{
    public interface IEquipmentModelRepository
    {
        public EquipmentModel Get(int id);
    }
}
