using AutoMapper;
using EquipmentManager.Application.Dtos;
using EquipmentManager.Application.Interfaces;
using EquipmentManagerApi.Controllers.Requests.Validators;
using EquipmentManagerApi.Controllers.Requests;
using EquipmentManagerApi.Controllers.Responses;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentManagerApi.Controllers
{
    [ApiController]
    [Route("api/v1/equipmentStateHistory")]
    public class EquipmentStateHistoryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEquipmentStateHistoryService _service;

        public EquipmentStateHistoryController(IEquipmentStateHistoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(GetEquipmentStateHistoryRequest request)
        {
            try
            {
                GetEquipmentStateHistoryValidator validator = new();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }
                var equipmentStateHistoryDto = _mapper.Map<EquipmentStateHistoryDto>(request);
                var equipmentStateHistory = _service.Get(equipmentStateHistoryDto.Id);

                var ret = _mapper.Map<GetEquipmentStateHistoryResponse>(equipmentStateHistory);
                var response = new ApiResponse<GetEquipmentStateHistoryResponse>()
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

        [HttpGet]
        [Route("GetByEquipment")]
        public IActionResult GetByEquipment(GetEquipmentStateHistoryRequest request)
        {
            try
            {
                GetEquipmentStateHistoryValidator validator = new();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }
                var equipmentStateHistory = _service.GetManyByEquipment(request.Id);

                var ret = _mapper.Map<GetEquipmentStateHistoryResponse>(equipmentStateHistory);
                var response = new ApiResponse<GetEquipmentStateHistoryResponse>()
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
        public async Task<IActionResult> Create(CreateEquipmentStateHistoryRequest request)
        {
            try
            {
                CreateEquipmentStateHistoryValidator validator = new();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }
                var equipmentStateHistoryDto = _mapper.Map<EquipmentStateHistoryDto>(request);
                _service.Create(equipmentStateHistoryDto);

                var equipmentStateHistory = _service.Get(equipmentStateHistoryDto.Id);

                var ret = _mapper.Map<CreateEquipmentStateHistoryResponse>(equipmentStateHistory);
                var response = new ApiResponse<CreateEquipmentStateHistoryResponse>()
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
        public async Task<IActionResult> Delete(DeleteEquipmentStateHistoryRequest request)
        {
            try
            {
                DeleteEquipmentStateHistoryValidator validator = new();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }
                var equipmentStateHistoryDto = _mapper.Map<EquipmentStateHistoryDto>(request);
                _service.Delete(equipmentStateHistoryDto.Id);

                var ret = _mapper.Map<DeleteEquipmentStateHistoryResponse>(request);
                var response = new ApiResponse<DeleteEquipmentStateHistoryResponse>()
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
