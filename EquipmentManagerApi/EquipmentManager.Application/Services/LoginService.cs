using AutoMapper;
using EquipmentManager.Application.Dtos;
using EquipmentManager.Application.Interfaces;
using EquipmentManager.Repository.Repositories;

namespace EquipmentManager.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _repository;
        private readonly IMapper _mapper;

        public LoginService(ILoginRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public UserDto VerifyUserPassword(UserDto user)
        {
            var userBd = _repository.Get(user.UserName);
            if (user.Password.Equals(userBd.Password))
                return _mapper.Map<UserDto>(userBd); ;
            return null;
        }
    }
}
