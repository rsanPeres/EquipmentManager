using AutoMapper;
using EquipmentManager.Application.Dtos;
using EquipmentManager.Domain.Entities;
using EquipmentManagerApi.Controllers.Requests;
using EquipmentManagerApi.Controllers.Responses;

namespace EquipmentManagerApi.Mappers
{
    public class EquipmentStateMappers : Profile
    {
        public EquipmentStateMappers()
        {
            EquipmentStateToDto();
            EquipmentStateToCreateRequest();
            EquipmentStateDtoToGetRequest();
            EquipmentStateDtoToDeleteRequest();
            EquipmentStateDtoToCreateResponse();
            EquipmentStateDtoToGetResponse();
            EquipmentStateDtoToDeleteResponse();
        }

        public void EquipmentStateToDto()
        {
            CreateMap<EquipmentState, EquipmentStateDto>()
                .ReverseMap();
        }

        public void EquipmentStateToCreateRequest()
        {
            CreateMap<EquipmentStateDto, CreateEquipmentStateRequest>()
                .ReverseMap();
        }

        public void EquipmentStateDtoToGetRequest()
        {
            CreateMap<EquipmentStateDto, GetEquipmentStateRequest>()
                .ReverseMap();
        }

        public void EquipmentStateDtoToDeleteRequest()
        {
            CreateMap<EquipmentStateDto, DeleteEquipmentStateRequest>()
                .ReverseMap();
        }

        public void EquipmentStateDtoToCreateResponse()
        {
            CreateMap<EquipmentStateDto, CreateEquipmentStateRequest>()
                .ReverseMap();
        }

        public void EquipmentStateDtoToGetResponse()
        {
            CreateMap<EquipmentStateDto, GetEquipmentStateResponse>()
                .ReverseMap();
        }

        public void EquipmentStateDtoToDeleteResponse()
        {
            CreateMap<EquipmentStateDto, DeleteEquipmentStateResponse>()
                .ReverseMap();
        }
    }
}
