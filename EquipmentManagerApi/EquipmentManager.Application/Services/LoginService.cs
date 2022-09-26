using AutoMapper;
using EquipmentManager.Domain.Entities.Dtos;
using EquipmentManager.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManager.Application.Services
{
    public class LoginService
    {
        private readonly LoginRepository _repository;
        private IMapper _mapper;

        public LoginService(LoginRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public UserDto VerifyUserPassword(UserDto user)
        {
            var userBd = _repository.Get(user.UserName);
            if (user.Password.Equals(userBd.Password)) return _mapper.Map<UserDto>(userBd); ;
            return null;
        }
    }
}
