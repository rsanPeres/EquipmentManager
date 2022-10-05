using AutoMapper;
using EquipmentManager.Application.Dtos;
using EquipmentManager.Domain.Entities;
using EquipmentManagerApi.Controllers.Requests;
using EquipmentManagerApi.Controllers.Responses;

namespace EquipmentManagerApi.Mappers
{
    public class EquipmentMappers : Profile
    {
        public EquipmentMappers()
        {
            EquipmentToDto();
            CreateRequestToDto();
            GetRequestToDto();
            UpdateRequestToDto();
            DeleteRequestToDto();
            CreateResponseToDto();
            GetResponseToDto();
            UpdateResponseToDto();
            DeleteResponseToDto();
        }

        private void EquipmentToDto()
        {
            CreateMap<EquipmentDto, Equipment>()
                .ReverseMap();
        }

        private void CreateRequestToDto()
        {
            CreateMap<EquipmentDto, CreateEquipmentRequest>()
                .ReverseMap();
        }

        private void GetRequestToDto()
        {
            CreateMap<EquipmentDto, GetEquipmentRequest>()
                .ReverseMap();
        }

        private void UpdateRequestToDto()
        {
            CreateMap<EquipmentDto, UpdateEquipmentRequest>()
                .ReverseMap();
        }

        private void DeleteRequestToDto()
        {
            CreateMap<EquipmentDto, DeleteEquipmentRequest>()
                .ReverseMap();
        }

        private void CreateResponseToDto()
        {
            CreateMap<EquipmentDto, CreateEquipmentResponse>()
                .ReverseMap();
        }

        private void GetResponseToDto()
        {
            CreateMap<EquipmentDto, GetEquipmentResponse>()
                .ReverseMap();
        }

        private void UpdateResponseToDto()
        {
            CreateMap<UpdateEquipmentResponse, EquipmentDto>()
                .ReverseMap();
        }

        private void DeleteResponseToDto()
        {
            CreateMap<EquipmentDto, DeleteEquipmentResponse>()
                .ReverseMap();
        }
    }
}
