using AutoMapper;
using EquipmentManager.Application.Dtos;
using EquipmentManager.Application.Interfaces;
using EquipmentManagerApi.Controllers.Requests;
using EquipmentManagerApi.Controllers.Requests.Validators;
using EquipmentManagerApi.Controllers.Responses;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentManagerApi.Controllers
{
    [ApiController]
    [Route("api/v1/equipmentState")]
    public class EquipmentStateController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEquipmentStateService _service;

        public EquipmentStateController(IEquipmentStateService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(GetEquipmentStateRequest request)
        {
            try
            {
                GetEquipmentStateValidator validator = new GetEquipmentStateValidator();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }
                var equipmentStateDto = _mapper.Map<EquipmentStateDto>(request);
                var equipmentState = _service.Get(equipmentStateDto.Id);

                var ret = _mapper.Map<GetEquipmentStateResponse>(equipmentState);
                var response = new ApiResponse<GetEquipmentStateResponse>()
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
        public async Task<IActionResult> Create(CreateEquipmentStateRequest request)
        {
            try
            {
                CreateEquipmentStateValidator validator = new CreateEquipmentStateValidator();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }
                var equipmentStateDto = _mapper.Map<EquipmentStateDto>(request);
                _service.Create(equipmentStateDto);

                var equipmentState = _service.Get(equipmentStateDto.Id);

                var ret = _mapper.Map<CreateEquipmentStateResponse>(equipmentState);
                var response = new ApiResponse<CreateEquipmentStateResponse>()
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
        public async Task<IActionResult> Delete(DeleteEquipmentStateRequest request)
        {
            try
            {
                DeleteEquipmentStateValidator validator = new();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }
                var equipmentStateDto = _mapper.Map<EquipmentStateDto>(request);
                _service.Delete(equipmentStateDto.Id);

                var ret = _mapper.Map<DeleteEquipmentStateResponse>(request);
                var response = new ApiResponse<DeleteEquipmentStateResponse>()
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
