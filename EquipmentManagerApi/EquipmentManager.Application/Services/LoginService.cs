using AutoMapper;
using EquipmentManager.Application.Dtos;
using EquipmentManager.Repository.Repositories;

namespace EquipmentManager.Application.Services
{
    public class LoginService
    {
        private readonly LoginRepository _repository;
        private readonly IMapper _mapper;

        public LoginService(LoginRepository repository, IMapper mapper)
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
