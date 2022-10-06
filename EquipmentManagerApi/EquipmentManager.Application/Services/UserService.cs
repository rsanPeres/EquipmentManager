using AutoMapper;
using EquipmentManager.Application.Dtos;
using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Interfaces.Repository;
using EquipmentManager.Infrastructure.Migrations;
using EquipmentManager.Repository;
using EquipmentManager.Repository.Repositories;
using Flunt.Notifications;

namespace EquipmentManager.Application.Services
{
    public class UserService : Notifiable<Notification>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, UserRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public void Create(UserDto userDto)
        {
            var user = new User(userDto.UserName, userDto.Password, userDto.Role, userDto.Cpf);
            AddNotifications(user);

            if (!IsValid)
                return;

            _repository.Create(user);
            _repository.SaveChanges();
        }

        public UserDto Get(string cpf)
        {
            var user = _repository.Get(cpf);

            if (user is null)
            {
                AddNotification("user_isnull", "User not found");
                return null;
            }

            return _mapper.Map<UserDto>(user);
        }

        public List<UserDto> GetMany()
        {
            var user = _repository.GetMany();
            if (user is null)
            {
                AddNotification("user_isEmpty", "user list is empty");
            }
            return _mapper.Map<List<UserDto>>(user);
        }

        public void Update(UserDto userDto)
        {
            var user = _repository.Get(userDto.Cpf);
            user.SetEmployeeRole(userDto.Role);
            AddNotifications(user);

            if (!IsValid)
                return;

            _repository.Update(user);
            _repository.SaveChanges();
        }

        public void Delete(UserDto userDto)
        {
            _repository.Delete(userDto.Cpf);
            _repository.SaveChanges();
        }
    }
}
