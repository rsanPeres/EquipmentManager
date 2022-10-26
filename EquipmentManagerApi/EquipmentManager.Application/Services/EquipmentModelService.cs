using AutoMapper;
using EquipmentManager.Application.Dtos;
using EquipmentManager.Application.Interfaces;
using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Interfaces.Repository;
using Flunt.Notifications;

namespace EquipmentManager.Application.Services
{
    public class EquipmentModelService : Notifiable<Notification>, IEquipmentModelService
    {
        private readonly IEquipmentModelRepository _repository;
        private readonly IMapper _mapper;

        public EquipmentModelService(IMapper mapper, IEquipmentModelRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public void Create(EquipmentModelDto equipmentDto)
        {
            var equipmentModel = new EquipmentModel(equipmentDto.ModelName);
            AddNotifications(equipmentModel);

            if (!IsValid)
                return;

            _repository.EnsureCreatedDatabase();
            _repository.Create(equipmentModel);
            _repository.SaveChanges();
        }

        public EquipmentModelDto Get(EquipmentModelDto equipmentModelDto)
        {
            _repository.EnsureCreatedDatabase();

            var equipmentModel = _repository.Get(equipmentModelDto.Id);
            if (equipmentModel is null)
            {
                AddNotification("equipmentModel_isnull", "EquipmentModel not found");
                return null;
            }
            return _mapper.Map<EquipmentModelDto>(equipmentModel);
        }

        public List<EquipmentModelDto> GetMany()
        {
            _repository.EnsureCreatedDatabase();
            var equipmentModel = _repository.GetMany();
            if (equipmentModel is null)
            {
                AddNotification("equipmentModel_isEmpty", "EquipmentModel list is empty");
            }
            return _mapper.Map<List<EquipmentModelDto>>(equipmentModel);
        }

        public void Update(EquipmentModelDto equipmentModelDto)
        {
            _repository.EnsureCreatedDatabase();

            var equipmentModel = _repository.Get(equipmentModelDto.Id);
            equipmentModel.Update(equipmentModelDto.ModelName);
            AddNotifications(equipmentModel);

            if (!IsValid)
                return;

            _repository.Update(equipmentModel);
            _repository.SaveChanges();
        }

        public void Delete(EquipmentModelDto equipmentModelDto)
        {
            _repository.EnsureCreatedDatabase();

            _repository.Delete(equipmentModelDto.Id);
        }
    }
}
