using AutoMapper;
using EquipmentManager.Application.Dtos;
using EquipmentManager.Domain.Entities;
using EquipmentManager.Repository.Repositories;

namespace EquipmentManager.Application.Services
{
    public class EquipmentModelService
    {
        private readonly EquipmentModelRepository _repository;
        private readonly IMapper _mapper;

        public EquipmentModelService(IMapper mapper, EquipmentModelRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public EquipmentModelDto Create(EquipmentModelDto equipmentDto)
        {
            var equipmentModel = new EquipmentModel(equipmentDto.ModelName);
            if (equipmentModel.IsValid)
            {
                _repository.Create(equipmentModel);
                return _mapper.Map<EquipmentModelDto>(equipmentModel);
            }
            foreach (var notification in equipmentModel.Notifications)
                Console.WriteLine($"{notification.Key} : {notification.Message}");
            return null;
        }

        public EquipmentModelDto Get(EquipmentModelDto equipmentModelDto)
        {
            var equipmentModel = _repository.Get(equipmentModelDto.ModelName);
            if (equipmentModel != null) return _mapper.Map<EquipmentModelDto>(equipmentModel);
            return null;
        }

        public EquipmentModelDto Update(EquipmentModelDto equipmentModelDto)
        {
            var equipmentModel = _repository.Update(equipmentModelDto.Id, equipmentModelDto.ModelName);
            if (equipmentModel != null) return _mapper.Map<EquipmentModelDto>(equipmentModel);
            return null;
        }

        public void Delete(EquipmentModelDto equipmentModelDto)
        {
            _repository.Delete(equipmentModelDto.ModelName);
        }
    }
}
