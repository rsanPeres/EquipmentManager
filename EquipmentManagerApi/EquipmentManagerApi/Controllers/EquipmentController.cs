using AutoMapper;
using EquipmentManager.Application.Dtos;
using EquipmentManager.Application.Services;
using EquipmentManagerApi.Controllers.Requests;
using EquipmentManagerApi.Controllers.Requests.Validators;
using EquipmentManagerApi.Controllers.Responses;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentManagerApi.Controllers
{
    [ApiController]
    [Route("api/v1/equipment")]
    public class EquipmentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly EquipmentService _service;

        public EquipmentController(EquipmentService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(GetEquipmentRequest request)
        {
            try
            {
                GetEquipmentValidator validator = new GetEquipmentValidator();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }
                var equipmentDto = _mapper.Map<EquipmentDto>(request);
                var equipment = _service.Get(equipmentDto);

                var ret = _mapper.Map<GetEquipmentResponse>(equipment);
                var response = new ApiResponse<GetEquipmentResponse>()
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

        [Route("getMany")]
        [HttpGet]
        public IActionResult GetMany()
        {
            try
            {
                var equipment = _service.GetMany();

                
               
                return Ok(equipment);
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
        public async Task<IActionResult> Create(CreateEquipmentRequest request)
        {
            try
            {
                CreateEquipmentValidator validator = new CreateEquipmentValidator();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }
                var equipmentDto = _mapper.Map<EquipmentDto>(request);
                var equipment = _service.Create(equipmentDto);

                var ret = _mapper.Map<CreateEquipmentResponse>(equipment);
                var response = new ApiResponse<CreateEquipmentResponse>()
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
        public async Task<IActionResult> Update(UpdateEquipmentRequest request)
        {
            try
            {
                UpdateEquipmentValidator validator = new UpdateEquipmentValidator();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }
                var equipmentDto = _mapper.Map<EquipmentDto>(request);
                var equipment = _service.Update(equipmentDto);

                var ret = _mapper.Map<UpdateEquipmentResponse>(equipment);
                var response = new ApiResponse<UpdateEquipmentResponse>()
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
        public async Task<IActionResult> Delete(DeleteEquipmentRequest request)
        {
            try
            {
                DeleteEquipmentValidator validator = new DeleteEquipmentValidator();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }
                var equipmentDto = _mapper.Map<EquipmentDto>(request);
                _service.Delete(equipmentDto);

                var ret = _mapper.Map<DeleteEquipmentResponse>(request);
                var response = new ApiResponse<DeleteEquipmentResponse>()
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
