using AutoMapper;
using EquipmentManager.Application.Dtos;
using EquipmentManager.Application.Interfaces;
using EquipmentManager.Domain.Interfaces.Repository;

namespace EquipmentManager.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public LoginService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public UserDto VerifyUserPassword(UserDto user)
        {
            _repository.EnsureCreatedDatabase();

            var userBd = _repository.Get(user.UserName);
            if (BCrypt.Net.BCrypt.Verify(user.Password, userBd.Password))
                return _mapper.Map<UserDto>(userBd); ;
            return null;
        }
    }
}
