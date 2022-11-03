using AutoMapper;
using EquipmentManager.Application.Dtos;
using EquipmentManager.Application.Interfaces;
using EquipmentManager.Domain.Constants;
using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Interfaces.Repository;
using Flunt.Notifications;

namespace EquipmentManager.Application.Services
{
    public class EquipmentPositionHistoryService : Notifiable<Notification>, IEquipmentPositionHistoryService
    {
        private readonly IEquipmentPositionHistoryRepository _equipmentPositionRepository;
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IMapper _mapper;
        public EquipmentPositionHistoryService(IEquipmentPositionHistoryRepository equipmentPositionRepository, IEquipmentRepository equipmentRepository, IMapper mapper)
        {
            _equipmentPositionRepository = equipmentPositionRepository;
            _equipmentRepository = equipmentRepository;
            _mapper = mapper;
        }

        public void Create(EquipmentPositionHistoryDto equipmentPositionDto)
        {
            var equipment = _equipmentRepository.Get(equipmentPositionDto.Equipment.Id);
            var equipmentPosition = new EquipmentPositionHistory
                (equipmentPositionDto.Latitude, equipmentPositionDto.Length, equipment);
            AddNotifications(equipmentPosition);

            if (!IsValid)
                return;

            _equipmentPositionRepository.EnsureCreatedDatabase();

            _equipmentPositionRepository.Create(equipmentPosition);
            _equipmentPositionRepository.SaveChanges();
        }

        public EquipmentPositionHistoryDto Get(int id)
        {
            _equipmentPositionRepository.EnsureCreatedDatabase();

            var equipmentPosition = _equipmentPositionRepository.Get(id);

            if (equipmentPosition is null)
            {
                AddNotification(EquipmentConstants.EquipmentNull, EquipmentConstants.EquipmentNullMsg);
                return null;
            }

            return _mapper.Map<EquipmentPositionHistoryDto>(equipmentPosition);
        }

        public List<EquipmentPositionHistoryDto> GetMany()
        {
            _equipmentPositionRepository.EnsureCreatedDatabase();

            var equipmentPosition = _equipmentPositionRepository.GetMany();
            if (equipmentPosition is null)
            {
                AddNotification(EquipmentConstants.EquipmentEmpty, EquipmentConstants.EquipmentEmptyMsg);
            }
            return _mapper.Map<List<EquipmentPositionHistoryDto>>(equipmentPosition);
        }

        public void Delete(int id)
        {
            _equipmentPositionRepository.EnsureCreatedDatabase();

            _equipmentPositionRepository.Delete(id);
            _equipmentPositionRepository.SaveChanges();
        }
    }
}
