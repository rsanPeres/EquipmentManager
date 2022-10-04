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
    [Route("api/v1/equipmentModel")]
    public class EquipmentModelController : Controller
    {
        private readonly IMapper _mapper;
        private readonly EquipmentModelService _service;

        public EquipmentModelController(EquipmentModelService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(GetEquipmentModelRequest request)
        {
            try
            {
                GetEquipmentModelValidator validator = new GetEquipmentModelValidator();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }
                var equipmentModelDto = _mapper.Map<EquipmentModelDto>(request);
                var equipmentModel = _service.Get(equipmentModelDto);

                var ret = _mapper.Map<GetEquipmentModelResponse>(equipmentModel);
                var response = new ApiResponse<GetEquipmentModelResponse>()
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
        public async Task<IActionResult> Create(CreateEquipmentModelRequest request)
        {
            try
            {
                CreateEquipmentModelValidator validator = new CreateEquipmentModelValidator();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }
                var equipmentModelDto = _mapper.Map<EquipmentModelDto>(request);
                var equipmentModel = _service.Create(equipmentModelDto);

                var ret = _mapper.Map<CreateEquipmentModelResponse>(equipmentModel);
                var response = new ApiResponse<CreateEquipmentModelResponse>()
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
        public async Task<IActionResult> Update(UpdateEquipmentModelRequest request)
        {
            try
            {
                UpdateEquipmentModelValidator validator = new UpdateEquipmentModelValidator();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }
                var equipmentModelDto = _mapper.Map<EquipmentModelDto>(request);
                var equipmentModel = _service.Update(equipmentModelDto);

                var ret = _mapper.Map<UpdateEquipmentModelResponse>(equipmentModel);
                var response = new ApiResponse<UpdateEquipmentModelResponse>()
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
        public async Task<IActionResult> Delete(DeleteEquipmentModelRequest request)
        {
            try
            {
                DeleteEquipmentModelValidator validator = new DeleteEquipmentModelValidator();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }
                var equipmentModelDto = _mapper.Map<EquipmentModelDto>(request);
                _service.Delete(equipmentModelDto);

                var ret = _mapper.Map<DeleteEquipmentModelResponse>(request);
                var response = new ApiResponse<DeleteEquipmentModelResponse>()
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