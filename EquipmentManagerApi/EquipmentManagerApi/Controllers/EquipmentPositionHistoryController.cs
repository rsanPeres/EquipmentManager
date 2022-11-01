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
    [Route("api/v1/equipmentPositionHistory")]
    public class EquipmentPositionHistoryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEquipmentPositionHistoryService _service;

        public EquipmentPositionHistoryController(IEquipmentPositionHistoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(GetEquipmentPositionHistoryRequest request)
        {
            try
            {
                GetEquipmentPositionHistoryValidator validator = new ();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }
                var equipmentPositionHistoryDto = _mapper.Map<EquipmentPositionHistoryDto>(request);
                var equipmentPositionHistory = _service.Get(equipmentPositionHistoryDto.Id);

                var ret = _mapper.Map<GetEquipmentPositionHistoryResponse>(equipmentPositionHistory);
                var response = new ApiResponse<GetEquipmentPositionHistoryResponse>()
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
        public async Task<IActionResult> Create(CreateEquipmentPositionHistoryRequest request)
        {
            try
            {
                CreateEquipmentPositionHistoryValidator validator = new ();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }
                var equipmentPositionHistoryDto = _mapper.Map<EquipmentPositionHistoryDto>(request);
                _service.Create(equipmentPositionHistoryDto);

                var equipmentPositionHistory = _service.Get(equipmentPositionHistoryDto.Id);

                var ret = _mapper.Map<CreateEquipmentPositionHistoryResponse>(equipmentPositionHistory);
                var response = new ApiResponse<CreateEquipmentPositionHistoryResponse>()
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

        [HttpPatch]
        
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteEquipmentPositionHistoryRequest request)
        {
            try
            {
                DeleteEquipmentPositionHistoryValidator validator = new();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }
                var equipmentPositionHistoryDto = _mapper.Map<EquipmentPositionHistoryDto>(request);
                _service.Delete(equipmentPositionHistoryDto.Id);

                var ret = _mapper.Map<DeleteEquipmentPositionHistoryResponse>(request);
                var response = new ApiResponse<DeleteEquipmentPositionHistoryResponse>()
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
