using EquipmentManager.Domain.Entities;

namespace EquipmentManager.Domain.Interfaces.Repository
{
    public interface IEquipmentModelRepository
    {
        public void Create(EquipmentModel model);
        public EquipmentModel Get(int id);
        public void Update(EquipmentModel equipment);
        public List<EquipmentModel> GetMany();
        public void Delete(int id);
        public void SaveChanges();
        public void EnsureCreatedDatabase();
        Dictionary<string, string> GetModelByEquipmentId(Equipment equipment);
    }
}
