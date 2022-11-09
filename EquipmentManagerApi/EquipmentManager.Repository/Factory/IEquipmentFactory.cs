using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Model;

namespace EquipmentManager.Repository.Factory
{
    public interface IEquipmentFactory
    {
        public Equipment Factory(string obj, EquipmentModel obj2);
    }
}
