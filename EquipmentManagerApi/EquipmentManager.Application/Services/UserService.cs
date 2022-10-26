using AutoMapper;
using EquipmentManager.Application.Dtos;
using EquipmentManager.Application.Interfaces;
using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Interfaces.Repository;
using Flunt.Notifications;

namespace EquipmentManager.Application.Services
{
    public class UserService : Notifiable<Notification>, IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, IUserRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public void Create(UserDto userDto)
        {
            var password = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
            var user = new User(userDto.UserName, password, userDto.Role, userDto.Cpf);
            AddNotifications(user);

            if (!IsValid)
                return;

            _repository.EnsureCreatedDatabase();
            _repository.Create(user);
            _repository.SaveChanges();
        }

        public UserDto Get(string cpf)
        {
            _repository.EnsureCreatedDatabase();
            var user = _repository.Get(cpf);
            
            if (user is null)
            {
                AddNotification("user_isnull", "User not found");
                return null;
            }
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }

        public List<UserDto> GetMany()
        {
            _repository.EnsureCreatedDatabase();

            var user = _repository.GetMany();
            if (user is null)
            {
                AddNotification("user_isEmpty", "user list is empty");
            }
            return _mapper.Map<List<UserDto>>(user);
        }

        public void Update(UserDto userDto)
        {
            _repository.EnsureCreatedDatabase();

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
            _repository.EnsureCreatedDatabase();

            var user = _repository.Get(userDto.Cpf);
            AddNotifications(user);

            if (!IsValid)
                return;
            _repository.Delete(userDto.Cpf);
            _repository.SaveChanges();
        }
    }
}
