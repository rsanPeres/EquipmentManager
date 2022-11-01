using AutoMapper;
using EquipmentManager.Application.Dtos;
using EquipmentManager.Domain.Entities;
using EquipmentManagerApi.Controllers.Requests;
using EquipmentManagerApi.Controllers.Responses;

namespace EquipmentManagerApi.Mappers
{
    public class EquipmentPositionHistoryMappers : Profile
    {
        public EquipmentPositionHistoryMappers()
        {
            PositionHistoryToDto();
            PositionHistoryDtoToCreateRequest();
            PositionHistoryDtoToGetRequest();
            PositionHistoryDtoToDeleteRequest();
            PositionHistoryDtoToCreateResponse();
            PositionHistoryDtoToGetResponse();
            PositionHistoryDtoToDeleteResponse();
        }

        public void PositionHistoryToDto()
        {
            CreateMap<EquipmentPositionHistory, EquipmentPositionHistoryDto>()
                .ReverseMap();
        }

        public void PositionHistoryDtoToCreateRequest()
        {
            CreateMap<EquipmentPositionHistoryDto, CreateEquipmentPositionHistoryRequest>()
                .ReverseMap();
        }

        public void PositionHistoryDtoToGetRequest()
        {
            CreateMap<EquipmentPositionHistoryDto, GetEquipmentPositionHistoryRequest>()
                .ReverseMap();
        }

        public void PositionHistoryDtoToDeleteRequest()
        {
            CreateMap<EquipmentPositionHistoryDto, DeleteEquipmentPositionHistoryRequest>()
                .ReverseMap();
        }

        public void PositionHistoryDtoToCreateResponse()
        {
            CreateMap<EquipmentPositionHistoryDto, CreateEquipmentPositionHistoryRequest>()
                .ReverseMap();
        }

        public void PositionHistoryDtoToGetResponse()
        {
            CreateMap<EquipmentPositionHistoryDto, GetEquipmentPositionHistoryResponse>()
                .ReverseMap();
        }

        public void PositionHistoryDtoToDeleteResponse()
        {
            CreateMap<EquipmentPositionHistoryDto, DeleteEquipmentPositionHistoryResponse>()
                .ReverseMap();
        }
    }
}
