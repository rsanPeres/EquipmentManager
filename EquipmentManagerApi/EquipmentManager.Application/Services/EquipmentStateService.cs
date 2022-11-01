using AutoMapper;
using EquipmentManager.Application.Dtos;
using EquipmentManager.Application.Interfaces;
using EquipmentManager.Domain.Constants;
using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Interfaces.Repository;
using Flunt.Notifications;

namespace EquipmentManager.Application.Services
{
    public class EquipmentStateService : Notifiable<Notification>, IEquipmentStateService
    {
        private readonly IEquipmentStateRepository _repository;
        private readonly IMapper _mapper;
        public EquipmentStateService(IEquipmentStateRepository equipmentRepository, IMapper mapper)
        {
            _repository = equipmentRepository;
            _mapper = mapper;
        }

        public void Create(EquipmentStateDto stateDto)
        {
            var equipmentState = new EquipmentState(stateDto.StateName, stateDto.EquipmentColor);
            AddNotifications(equipmentState);

            if (!IsValid)
                return;

            _repository.EnsureCreatedDatabase();

            _repository.Create(equipmentState);
            _repository.SaveChanges();
        }

        public EquipmentStateDto Get(int id)
        {
            _repository.EnsureCreatedDatabase();

            var equipmentState = _repository.Get(id);

            if (equipmentState is null)
            {
                AddNotification(EquipmentConstants.EquipmentNull, EquipmentConstants.EquipmentNullMsg);
                return null;
            }

            return _mapper.Map<EquipmentStateDto>(equipmentState);
        }

        public List<EquipmentStateDto> GetMany()
        {
            _repository.EnsureCreatedDatabase();

            var equipmentState = _repository.GetMany();
            if (equipmentState is null)
            {
                AddNotification(EquipmentConstants.EquipmentEmpty, EquipmentConstants.EquipmentEmptyMsg);
            }
            return _mapper.Map<List<EquipmentStateDto>>(equipmentState);
        }

        public void Delete(int id)
        {
            _repository.EnsureCreatedDatabase();

            _repository.Delete(id);
            _repository.SaveChanges();
        }
    }
}
