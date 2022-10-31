using AutoMapper;
using EquipmentManager.Application.Dtos;
using EquipmentManager.Application.Interfaces;
using EquipmentManager.Domain.Entities;
using EquipmentManagerApi.Controllers.Requests;
using EquipmentManagerApi.Controllers.Requests.Validators;
using EquipmentManagerApi.Controllers.Responses;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentManagerApi.Controllers
{
    [ApiController]
    [Route("api/v1/equipmentModelStateHourlyEarning")]
    public class EquipmentModelStateHourlyEarningController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEquipmentModelStateHourlyEarningService _service;

        public EquipmentModelStateHourlyEarningController(IEquipmentModelStateHourlyEarningService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(GetEquipmentModelStateHourlyEarningRequest request)
        {
            try
            {
                GetEquipmentModelStateHourlyEarningValidator validator = new GetEquipmentModelStateHourlyEarningValidator();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }
                var hourlyEarningDto = _mapper.Map<EquipmentModelStateHourlyEarningDto>(request);
                var hourlyEarning = _service.Get(hourlyEarningDto);

                var ret = _mapper.Map<GetEquipmentModelStateHourlyEarningResponse>(hourlyEarning);
                var response = new ApiResponse<GetEquipmentModelStateHourlyEarningResponse>()
                {
                    Success = true,
                    Data = ret,
                    Messages = null
                };
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = new ApiResponse<string>()
                {
                    Success = false,
                    Data = null,
                    Messages = e.Message
                };
                return BadRequest(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEquipmentModelStateHourlyEarningRequest request)
        {
            try
            {
                CreateEquipmentModelStateHourlyEarningValidator validator = new CreateEquipmentModelStateHourlyEarningValidator();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }
                var hourlyEarningDto = _mapper.Map<EquipmentModelStateHourlyEarningDto>(request);
                _service.Create(hourlyEarningDto);

                var hourlyEarning = _service.Get(hourlyEarningDto);

                var ret = _mapper.Map<CreateEquipmentModelStateHourlyEarningResponse>(hourlyEarning);
                var response = new ApiResponse<CreateEquipmentModelStateHourlyEarningResponse>()
                {
                    Success = true,
                    Data = ret,
                    Messages = null
                };
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = new ApiResponse<string>()
                {
                    Success = false,
                    Data = null,
                    Messages = e.Message
                };
                return BadRequest(response);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteEquipmentModelStateHourlyEarningRequest request)
        {
            try
            {
                DeleteEquipmentModelStateHourlyEarningValidator validator = new DeleteEquipmentModelStateHourlyEarningValidator();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }
                var hourlyEarningDto = _mapper.Map<EquipmentModelStateHourlyEarningDto>(request);
                _service.Delete(hourlyEarningDto);

                var ret = _mapper.Map<DeleteEquipmentModelStateHourlyEarningResponse>(request);
                var response = new ApiResponse<DeleteEquipmentModelStateHourlyEarningResponse>()
                {
                    Success = true,
                    Data = ret,
                    Messages = null
                };
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = new ApiResponse<string>()
                {
                    Success = false,
                    Data = null,
                    Messages = e.Message
                };
                return BadRequest(response);
            }
        }
    }
}
