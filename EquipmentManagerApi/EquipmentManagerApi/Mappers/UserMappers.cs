using AutoMapper;
using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Entities.Dtos;
using EquipmentManagerApi.Controllers.Requests;
using EquipmentManagerApi.Controllers.Responses;

namespace EquipmentManagerApi.Mappers
{
    public class UserMappers : Profile
    {
        public UserMappers()
        {
            UserToDto();
            CreateRequestToDto();
            GetRequestToDto();
            UpdateRequestToUserDto();
            DeleteRequestToDto();
            CreateResponseToDto();
            GetResponseToDto();
            UpdateResponseToUserDto();
            DeleteResponseToDto();
            LoginRequestToDto();
            LoginResponseToDto();
        }

        private void UserToDto()
        {
            CreateMap<UserDto, User>()
                .ReverseMap();
        }

        private void CreateRequestToDto()
        {
            CreateMap<UserDto, CreateUserRequest>()
                .ReverseMap();
        }

        private void GetRequestToDto()
        {
            CreateMap<UserDto, GetUserRequest>()
                .ReverseMap();
        }

        private void UpdateRequestToUserDto()
        {
            CreateMap<UpdateUserRequest, UserDto>()
                .ReverseMap();
        }

        private void DeleteRequestToDto()
        {
            CreateMap<UserDto, DeleteUserRequest>()
                .ReverseMap();
        }

        private void CreateResponseToDto()
        {
            CreateMap<UserDto, CreateUserResponse>()
                .ReverseMap();
        }

        private void GetResponseToDto()
        {
            CreateMap<UserDto, GetUserResponse>()
                .ReverseMap();
        }

        private void UpdateResponseToUserDto()
        {
            CreateMap<UpdateUserResponse, UserDto>()
                .ReverseMap();
        }

        private void DeleteResponseToDto()
        {
            CreateMap<UserDto, DeleteUserResponse>()
                .ReverseMap();
        }

        private void LoginRequestToDto()
        {
            CreateMap<UserDto, LoginUserRequest>()
                .ReverseMap();
        }

        private void LoginResponseToDto()
        {
            CreateMap<UserDto, LoginUserResponse>()
                .ReverseMap();
        }
    }
}
