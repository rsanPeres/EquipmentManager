using AutoMapper;
using EquipmentManager.Application.Dtos;
using EquipmentManager.Domain.Entities;
using EquipmentManagerApi.Controllers.Requests;
using EquipmentManagerApi.Controllers.Responses;

namespace EquipmentManagerApi.Mappers
{
    public class EquipmentStateHistoryMappers : Profile
    {
        public EquipmentStateHistoryMappers()
        {
            EquipmentStateHistoryToDto();
            EquipmentStateHistoryToCreateRequest();
            EquipmentStateHistoryDtoToGetRequest();
            EquipmentStateHistoryDtoToDeleteRequest();
            EquipmentStateHistoryDtoToCreateResponse();
            EquipmentStateHistoryDtoToGetResponse();
            EquipmentStateHistoryDtoToDeleteResponse();
        }

        public void EquipmentStateHistoryToDto()
        {
            CreateMap<EquipmentStateHistory, EquipmentStateHistoryDto>()
                .ReverseMap();
        }

        public void EquipmentStateHistoryToCreateRequest()
        {
            CreateMap<EquipmentStateHistoryDto, CreateEquipmentStateHistoryRequest>()
                .ReverseMap();
        }

        public void EquipmentStateHistoryDtoToGetRequest()
        {
            CreateMap<EquipmentStateHistoryDto, GetEquipmentStateHistoryRequest>()
                .ReverseMap();
        }

        public void EquipmentStateHistoryDtoToDeleteRequest()
        {
            CreateMap<EquipmentStateHistoryDto, DeleteEquipmentStateHistoryRequest>()
                .ReverseMap();
        }

        public void EquipmentStateHistoryDtoToCreateResponse()
        {
            CreateMap<EquipmentStateHistoryDto, CreateEquipmentStateHistoryRequest>()
                .ReverseMap();
        }

        public void EquipmentStateHistoryDtoToGetResponse()
        {
            CreateMap<EquipmentStateHistoryDto, GetEquipmentStateHistoryResponse>()
                .ReverseMap();
        }

        public void EquipmentStateHistoryDtoToDeleteResponse()
        {
            CreateMap<EquipmentStateHistoryDto, DeleteEquipmentStateHistoryResponse>()
                .ReverseMap();
        }
    }
}
