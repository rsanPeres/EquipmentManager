using AutoMapper;
using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Entities.Dtos;
using EquipmentManager.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManager.Application.Services
{
    public class UserService
    {
        private UserRepository _repository;
        private IMapper _mapper;

        public UserService(IMapper mapper, UserRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public UserDto Create(UserDto userDto)
        {
            var user = new User(userDto.Id, userDto.UserName, userDto.Password, userDto.Role, userDto.Cpf);
            if (user.IsValid)
            {
                _repository.Create(user);
                return _mapper.Map<UserDto>(user);
            }
            foreach (var notification in user.Notifications)
                Console.WriteLine($"{notification.Key} : {notification.Message}");
            return null;
        }

        public UserDto Get(UserDto userDto)
        {
            var user = _repository.Get(userDto.Cpf);
            if (user != null) return _mapper.Map<UserDto>(user);
            return null;
        }

        public UserDto Update(UserDto userDto)
        {
            var user = _repository.Update(userDto.Cpf, userDto.Role);
            if (user != null) return _mapper.Map<UserDto>(user);
            return null;
        }

        public void Delete(UserDto userDto)
        {
            _repository.Delete(userDto.Cpf);
        }
    }
}
