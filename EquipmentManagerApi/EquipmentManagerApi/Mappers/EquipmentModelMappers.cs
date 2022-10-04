using AutoMapper;
using EquipmentManager.Application.Dtos;
using EquipmentManager.Domain.Entities;
using EquipmentManagerApi.Controllers.Requests;
using EquipmentManagerApi.Controllers.Responses;

namespace EquipmentManagerApi.Mappers
{
    public class EquipmentModelMappers : Profile
    {
        public EquipmentModelMappers()
        {
            EquipmentModelToDto();
            CreateRequestToDto();
            GetRequestToDto();
            UpdateRequestToDto();
            DeleteRequestToDto();
            CreateResponseToDto();
            GetResponseToDto();
            UpdateResponseToDto();
            DeleteResponseToDto();
        }

        private void EquipmentModelToDto()
        {
            CreateMap<EquipmentModelDto, EquipmentModel>()
                .ReverseMap();
        }

        private void CreateRequestToDto()
        {
            CreateMap<EquipmentModelDto, CreateEquipmentModelRequest>()
                .ReverseMap();
        }

        private void GetRequestToDto()
        {
            CreateMap<EquipmentModelDto, GetEquipmentModelRequest>()
                .ReverseMap();
        }

        private void UpdateRequestToDto()
        {
            CreateMap<UpdateEquipmentModelRequest, EquipmentModelDto>()
                .ReverseMap();
        }

        private void DeleteRequestToDto()
        {
            CreateMap<EquipmentModelDto, DeleteEquipmentModelRequest>()
                .ReverseMap();
        }

        private void CreateResponseToDto()
        {
            CreateMap<EquipmentModelDto, CreateEquipmentModelResponse>()
                .ReverseMap();
        }

        private void GetResponseToDto()
        {
            CreateMap<EquipmentModelDto, GetEquipmentModelResponse>()
                .ReverseMap();
        }

        private void UpdateResponseToDto()
        {
            CreateMap<UpdateEquipmentModelResponse, EquipmentModelDto>()
                .ReverseMap();
        }

        private void DeleteResponseToDto()
        {
            CreateMap<EquipmentModelDto, DeleteEquipmentModelResponse>()
                .ReverseMap();
        }
    }
}
