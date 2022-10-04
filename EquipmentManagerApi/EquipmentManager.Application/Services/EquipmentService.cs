using AutoMapper;
using EquipmentManager.Application.Dtos;
using EquipmentManager.Domain.Entities;
using EquipmentManager.Repository;

namespace EquipmentManager.Application.Services
{
    public class EquipmentService
    {
        private readonly EquipmentRepository _repository;
        private readonly IMapper _mapper;

        public EquipmentService(IMapper mapper, EquipmentRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public EquipmentDto Create(EquipmentDto equipmentDto)
        {
            var equipment = new Equipment(equipmentDto.Name);
            if (equipment.IsValid)
            {
                _repository.CreateEquipment(equipment);
                return _mapper.Map<EquipmentDto>(equipment);
            }
            foreach (var notification in equipment.Notifications)
                Console.WriteLine($"{notification.Key} : {notification.Message}");
            return null;
        }

        public EquipmentDto Get(EquipmentDto equipmentDto)
        {
            var equipment = _repository.Get(equipmentDto.Name);
            if (equipment != null) return _mapper.Map<EquipmentDto>(equipment);
            return null;
        }

        public EquipmentDto Update(EquipmentDto equipmentDto)
        {
            var equipment = _repository.Update(equipmentDto.Name, equipmentDto.Name);
            if (equipment != null) return _mapper.Map<EquipmentDto>(equipment);
            return null;
        }

        public void Delete(EquipmentDto equipmentDto)
        {
            _repository.Delete(equipmentDto.Name);
        }
    }
}

