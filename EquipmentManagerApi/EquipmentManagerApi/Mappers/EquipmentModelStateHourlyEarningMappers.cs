using AutoMapper;
using EquipmentManager.Application.Dtos;
using EquipmentManager.Domain.Entities;
using EquipmentManagerApi.Controllers.Requests;
using EquipmentManagerApi.Controllers.Responses;

namespace EquipmentManagerApi.Mappers
{
    public class EquipmentModelStateHourlyEarningMappers : Profile
    {
        public EquipmentModelStateHourlyEarningMappers()
        {
            HourlyEarningToDto();
            HourlyEarningDtoToCreateRequest();
            HourlyEarningDtoToGetRequest();
            HourlyEarningDtoToDeleteRequest();
            HourlyEarningDtoToCreateResponse();
            HourlyEarningDtoToGetResponse();
            HourlyEarningDtoToDeleteResponse();
        }

        public void HourlyEarningToDto()
        {
            CreateMap<EquipmentModelStateHourlyEarning, EquipmentModelStateHourlyEarningDto>()
                .ReverseMap();
        }

        public void HourlyEarningDtoToCreateRequest()
        {
            CreateMap<EquipmentModelStateHourlyEarningDto, CreateEquipmentModelStateHourlyEarningRequest>()
                .ReverseMap();
        }

        public void HourlyEarningDtoToGetRequest()
        {
            CreateMap<EquipmentModelStateHourlyEarningDto, GetEquipmentModelStateHourlyEarningRequest>()
                .ReverseMap();
        }

        public void HourlyEarningDtoToDeleteRequest()
        {
            CreateMap<EquipmentModelStateHourlyEarningDto, DeleteEquipmentModelStateHourlyEarningRequest>()
                .ReverseMap();
        }

        public void HourlyEarningDtoToCreateResponse()
        {
            CreateMap<EquipmentModelStateHourlyEarningDto, CreateEquipmentModelStateHourlyEarningRequest>()
                .ReverseMap();
        }

        public void HourlyEarningDtoToGetResponse()
        {
            CreateMap<EquipmentModelStateHourlyEarningDto, GetEquipmentModelStateHourlyEarningResponse>()
                .ReverseMap();
        }

        public void HourlyEarningDtoToDeleteResponse()
        {
            CreateMap<EquipmentModelStateHourlyEarningDto, DeleteEquipmentModelStateHourlyEarningResponse>()
                .ReverseMap();
        }
    }
}
