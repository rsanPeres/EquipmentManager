﻿using AutoMapper;
using EquipmentManager.Application.Dtos;
using EquipmentManager.Application.Interfaces;
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
        private readonly IEquipmentService _service;

        public EquipmentController(IEquipmentService service, IMapper mapper)
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
                var equipment = _service.Get(equipmentDto.Id);

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

        [HttpGet]
        [Route("GetManyState")]
        public IActionResult GetStatesByEquipment(GetEquipmentStateHistoryRequest request)
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

        [HttpGet]
        [Route("GetLastState")]
        public IActionResult GetLastStateByEquipmentId(GetEquipmentStateHistoryRequest request)
        {
            try
            {
                GetEquipmentStateHistoryValidator validator = new();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }
                var equipmentStateHistory = _service.GetLastStateEquipment(request.Id);

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
        [Route("positionByEquipment")]
        public IActionResult GetPositionsByEquipment(GetEquipmentRequest request)
        {
            try
            {
                GetEquipmentValidator validator = new();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }
                var equipmentPositionHistory = _service.PositionByEquipment(request.Id);

                var ret = new GetEquipmentPositionHistoryResponse();
                var response = new ApiResponse<GetEquipmentPositionHistoryResponse>()
                {
                    Success = true,
                    Data = ret,
                    Messages = null
                };
                return Ok(equipmentPositionHistory);
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
        [Route("getModelByEquipmentId")]
        public IActionResult GetModelByEquipmentId(GetEquipmentRequest request)
        {
            try
            {
                GetEquipmentValidator validator = new();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }
                var equipmentModel = _service.GetModelByEquipmentId(request.Id);

                var ret = new GetEquipmentModelResponse();
                var response = new ApiResponse<GetEquipmentModelResponse>()
                {
                    Success = true,
                    Data = ret,
                    Messages = null
                };
                return Ok(equipmentModel);
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
                _service.Create(equipmentDto);
                var equipment = _service.Get(equipmentDto.Id);

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
                _service.Update(equipmentDto);

                var equipment = _service.Get(equipmentDto.Id);

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
                _service.Delete(equipmentDto.Id);

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
