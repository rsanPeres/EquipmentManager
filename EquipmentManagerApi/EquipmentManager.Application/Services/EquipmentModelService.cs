using AutoMapper;
using EquipmentManager.Domain.Entities.Dtos;
using EquipmentManager.Domain.Entities;
using EquipmentManager.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManager.Application.Services
{
    public class EquipmentModelService
    {
        private EquipmentModelRepository _repository;
        private IMapper _mapper;

        public EquipmentModelService(IMapper mapper, EquipmentModelRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public EquipmentModelDto Create(EquipmentModelDto equipmentDto)
        {
            var equipmentModel = new EquipmentModel(equipmentDto.Name);
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
            var equipmentModel = _repository.Get(equipmentModelDto.Name);
            if (equipmentModel != null) return _mapper.Map<EquipmentModelDto>(equipmentModel);
            return null;
        }

        public EquipmentModelDto Update(EquipmentModelDto equipmentModelDto)
        {
            var equipmentModel = _repository.Update(equipmentModelDto.Name, equipmentModelDto.Name);
            if (equipmentModel != null) return _mapper.Map<EquipmentModelDto>(equipmentModel);
            return null;
        }

        public void Delete(EquipmentModelDto equipmentModelDto)
        {
            _repository.Delete(equipmentModelDto.Name);
        }
    }
}
