using AutoMapper;
using EquipmentManager.Application.Dtos;
using EquipmentManager.Application.Interfaces;
using EquipmentManager.Domain.Constants;
using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Interfaces.Repository;
using Flunt.Notifications;

namespace EquipmentManager.Application.Services
{
    public class EquipmentService : Notifiable<Notification>, IEquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IEquipmentModelRepository _equipmentModelRepository;
        private readonly IMapper _mapper;
        public EquipmentService(IEquipmentRepository equipmentRepository, IEquipmentModelRepository equipmentModelRepository, IMapper mapper)
        {
            _equipmentRepository = equipmentRepository;
            _equipmentModelRepository = equipmentModelRepository;
            _mapper = mapper;
        }

        public void Create(EquipmentDto equipmentDto)
        {
            var equipmentModel = _equipmentModelRepository.Get(equipmentDto.EquipmentModel.Id);
            var equipment = new Equipment(equipmentDto.Name, equipmentModel);
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

