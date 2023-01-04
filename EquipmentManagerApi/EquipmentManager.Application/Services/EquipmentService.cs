using AutoMapper;
using EquipmentManager.Application.Dtos;
using EquipmentManager.Application.Interfaces;
using EquipmentManager.Domain.Constants;
using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Interfaces.Repository;
using EquipmentManager.Repository.Factory;
using EquipmentManager.Repository.Repositories;
using Flunt.Notifications;

namespace EquipmentManager.Application.Services
{
    public class EquipmentService : Notifiable<Notification>, IEquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IEquipmentModelRepository _equipmentModelRepository;
        private readonly IEquipmentStateHistoryRepository _equipmentStateHistoryRepository; 
        private readonly IEquipmentStateRepository _equipmentStateRepository; 
        private readonly IMapper _mapper;
        private readonly IEquipmentPositionHistoryRepository _equipmentPositionHistoryRepository;

        public EquipmentService(IEquipmentRepository equipmentRepository, IEquipmentModelRepository equipmentModelRepository, IMapper mapper, IEquipmentStateHistoryRepository equipmentStateHistoryRepository, IEquipmentPositionHistoryRepository equipmentPositionHistoryRepository)
        {
            _equipmentRepository = equipmentRepository;
            _equipmentModelRepository = equipmentModelRepository;
            _mapper = mapper;
            _equipmentStateHistoryRepository = equipmentStateHistoryRepository;
            _equipmentPositionHistoryRepository = equipmentPositionHistoryRepository;
        }

        public void Create(EquipmentDto equipmentDto)
        {
            var equipmentModel = _equipmentModelRepository.Get(equipmentDto.EquipmentModel.Id);
            var equipment = new Equipment(equipmentDto.Name, equipmentModel);

            var equipPosition = new EquipmentPositionHistory(equipmentDto.EquipmentPositionHistory.Latitude, equipmentDto.EquipmentPositionHistory.Length, equipment);
            _equipmentPositionHistoryRepository.Create(equipPosition);
            equipment.EquipmentPositionsHistory.Add(equipPosition);

            var equipmentState = new EquipmentState(equipmentDto.EquipmentState.StateName, equipmentDto.EquipmentState.EquipmentColor);
            //_equipmentStateRepository.Create(equipmentState);

            var stateHistory = new EquipmentStateHistory(equipment, equipmentState);
            _equipmentStateHistoryRepository.Create(stateHistory);
            equipment.EquipmentStatesHistory.Add(stateHistory);

            AddNotifications(equipment);

            if (!IsValid)
                return;

            _equipmentRepository.EnsureCreatedDatabase();

            _equipmentRepository.Create(equipment);
            _equipmentRepository.SaveChanges();
        }

        public EquipmentDto Get(int id)
        {
            _equipmentRepository.EnsureCreatedDatabase();

            var equipment = _equipmentRepository.Get(id);

            if (equipment is null)
            {
                AddNotification(EquipmentConstants.EquipmentNull, EquipmentConstants.EquipmentNullMsg);
                return null;
            }

            return _mapper.Map<EquipmentDto>(equipment);
        }

        public List<EquipmentDto> GetMany()
        {
            _equipmentRepository.EnsureCreatedDatabase();

            var equipment = _equipmentRepository.GetMany();
            if (equipment is null)
            {
                AddNotification(EquipmentConstants.EquipmentEmpty, EquipmentConstants.EquipmentEmptyMsg);
            }
            return _mapper.Map<List<EquipmentDto>>(equipment);
        }

        public List<EquipmentStateHistoryDto> GetManyByEquipment(int id)
        {
            _equipmentStateHistoryRepository.EnsureCreatedDatabase();

            var equipmentStateHistory = _equipmentStateHistoryRepository.GetManyByEquipment(id);
            if (equipmentStateHistory is null)
            {
                AddNotification(EquipmentConstants.EquipmentEmpty, EquipmentConstants.EquipmentEmptyMsg);
            }
            return _mapper.Map<List<EquipmentStateHistoryDto>>(equipmentStateHistory);

        }

        public EquipmentStateHistoryDto GetLastStateEquipment(int id)
        {
            _equipmentStateHistoryRepository.EnsureCreatedDatabase();

            var equipmentStateHistory = _equipmentStateHistoryRepository.GetLastByEquipment(id);
            if (equipmentStateHistory is null)
            {
                AddNotification(EquipmentConstants.EquipmentEmpty, EquipmentConstants.EquipmentEmptyMsg);
            }
            return _mapper.Map<EquipmentStateHistoryDto>(equipmentStateHistory);

        }

        public List<EquipmentPositionHistoryDto> PositionByEquipment(int id)
        {
            _equipmentPositionHistoryRepository.EnsureCreatedDatabase();
            var listPositions = _equipmentPositionHistoryRepository.PositionByEquipment(id);

            if (listPositions is null)
            {
                AddNotification(EquipmentConstants.EquipmentEmpty, EquipmentConstants.EquipmentEmptyMsg);
            }
            return _mapper.Map<List<EquipmentPositionHistoryDto>>(listPositions);
        }

        public EquipmentModelDto GetModelByEquipmentId(int id)
        {
            _equipmentPositionHistoryRepository.EnsureCreatedDatabase();
            var equipmentModel = _equipmentModelRepository.GetModelByEquipmentId(id);
            if (equipmentModel is null)
            {
                AddNotification(EquipmentConstants.EquipmentEmpty, EquipmentConstants.EquipmentEmptyMsg);
            }
            return _mapper.Map<EquipmentModelDto>(equipmentModel);
        }

        public void Update(EquipmentDto equipmentDto)
        {
            _equipmentRepository.EnsureCreatedDatabase();

            var equipmentModel = _equipmentModelRepository.Get(equipmentDto.EquipmentModel.Id);
            var equipment = _equipmentRepository.Get(equipmentDto.Id);
            equipment.Update(equipmentDto.Name, equipmentModel);
            AddNotifications(equipment);

            if (!IsValid)
                return;

            _equipmentRepository.Update(equipment);
            _equipmentRepository.SaveChanges();

        }

        public void Delete(int id)
        {
            _equipmentRepository.EnsureCreatedDatabase();

            _equipmentRepository.Delete(id);
            _equipmentRepository.SaveChanges();
        }
    }
}

