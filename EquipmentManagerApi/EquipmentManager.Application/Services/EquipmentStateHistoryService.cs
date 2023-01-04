using AutoMapper;
using EquipmentManager.Application.Dtos;
using EquipmentManager.Application.Interfaces;
using EquipmentManager.Domain.Constants;
using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Interfaces.Repository;
using Flunt.Notifications;

namespace EquipmentManager.Application.Services
{
    public class EquipmentStateHistoryService : Notifiable<Notification>, IEquipmentStateHistoryService
    {
        private readonly IEquipmentStateHistoryRepository _repository;
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IEquipmentStateRepository _equipmentStateRepository;
        private readonly IMapper _mapper;
        public EquipmentStateHistoryService(IEquipmentStateHistoryRepository equipmentRepository, IMapper mapper)
        {
            _repository = equipmentRepository;
            _mapper = mapper;
        }

        public void Create(EquipmentStateHistoryDto stateHistoryDto)
        {
            var equipmentState = _mapper.Map<EquipmentState>(stateHistoryDto.EquipmentState);
            var equipment = _equipmentRepository.Get(stateHistoryDto.Equipment.Id);
            var equipmentStateHistory = new EquipmentStateHistory(equipment, equipmentState);
            AddNotifications(equipmentStateHistory);

            if (!IsValid)
                return;

            _repository.EnsureCreatedDatabase();

            _repository.Create(equipmentStateHistory);
            _repository.SaveChanges();
        }

        public EquipmentStateHistoryDto Get(int id)
        {
            _repository.EnsureCreatedDatabase();

            var equipmentStateHistory = _repository.Get(id);

            if (equipmentStateHistory is null)
            {
                AddNotification(EquipmentConstants.EquipmentNull, EquipmentConstants.EquipmentNullMsg);
                return null;
            }

            return _mapper.Map<EquipmentStateHistoryDto>(equipmentStateHistory);
        }

        public List<EquipmentStateHistoryDto> GetMany()
        {
            _repository.EnsureCreatedDatabase();

            var equipmentStateHistory = _repository.GetMany();
            if (equipmentStateHistory is null)
            {
                AddNotification(EquipmentConstants.EquipmentEmpty, EquipmentConstants.EquipmentEmptyMsg);
            }
            return _mapper.Map<List<EquipmentStateHistoryDto>>(equipmentStateHistory);
        }
        public List<EquipmentStateHistoryDto> GetManyByEquipment(int id)
        {
            _repository.EnsureCreatedDatabase();

            var equipmentStateHistory = _repository.GetManyByEquipment(id);
            if (equipmentStateHistory is null)
            {
                AddNotification(EquipmentConstants.EquipmentEmpty, EquipmentConstants.EquipmentEmptyMsg);
            }
            return _mapper.Map<List<EquipmentStateHistoryDto>>(equipmentStateHistory);

        }

        public void Delete(int id)
        {
            _repository.EnsureCreatedDatabase();

            _repository.Delete(id);
            _repository.SaveChanges();
        }
    }
}
