using AutoMapper;
using EquipmentManager.Application.Dtos;
using EquipmentManager.Application.Interfaces;
using EquipmentManager.Domain.Constants;
using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Interfaces.Repository;
using EquipmentManager.Repository.Repositories;
using Flunt.Notifications;

namespace EquipmentManager.Application.Services
{
    public class EquipmentModelStateHourlyEarningService : Notifiable<Notification>, IEquipmentModelStateHourlyEarningService
    {
        private readonly IEquipmentModelStateHourlyEarning _repository;
        private readonly IEquipmentModelRepository _modelRepository;
        private readonly IEquipmentState _stateRepository;
        private readonly IMapper _mapper;

        public EquipmentModelStateHourlyEarningService(IMapper mapper, IEquipmentModelStateHourlyEarning repository, IEquipmentModelRepository repositoryRepository, IEquipmentState stateRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _modelRepository = repositoryRepository;
            _stateRepository = stateRepository;
        }

        public void Create(EquipmentModelStateHourlyEarningDto hourlyEarning)
        {
            _repository.EnsureCreatedDatabase();
            var model = _modelRepository.Get(hourlyEarning.EquipmentModel.Id);
            var state = _stateRepository.Get(hourlyEarning.EquipmentState.Id);
            var equipmentHourlyEarning = new EquipmentModelStateHourlyEarning(hourlyEarning.EarnedValueByHourState, model, state);
            AddNotifications(equipmentHourlyEarning);

            if (!IsValid)
                return;

            _repository.Create(equipmentHourlyEarning);
            _repository.SaveChanges();
        }

        public EquipmentModelStateHourlyEarningDto Get(EquipmentModelStateHourlyEarningDto equipmentModelDto)
        {
            _repository.EnsureCreatedDatabase();
            var hourlyEarning = _mapper.Map<EquipmentModelStateHourlyEarning>(equipmentModelDto);
            var equipmentHourlyEarning = _repository.Get(hourlyEarning);
            if (equipmentHourlyEarning is null)
            {
                AddNotification(EquipmentModelConstants.EquipmentModelNull, EquipmentModelConstants.EquipmentNullMsg);
                return null;
            }
            return _mapper.Map<EquipmentModelStateHourlyEarningDto>(equipmentHourlyEarning);
        }

        public List<EquipmentModelStateHourlyEarningDto> GetMany()
        {
            _repository.EnsureCreatedDatabase();
            var equipmentModel = _repository.GetMany();
            if (equipmentModel is null)
            {
                AddNotification(EquipmentModelConstants.EquipmentModelEmpty, EquipmentModelConstants.EquipmentModelEmptyMsg);
            }
            return _mapper.Map<List<EquipmentModelStateHourlyEarningDto>>(equipmentModel);
        }

        public void Delete(EquipmentModelStateHourlyEarningDto equipmentModelDto)
        {
            _repository.EnsureCreatedDatabase();
            var hourlyEarning = _mapper.Map<EquipmentModelStateHourlyEarning>(equipmentModelDto);
            _repository.Delete(hourlyEarning);
        }
    }
}
