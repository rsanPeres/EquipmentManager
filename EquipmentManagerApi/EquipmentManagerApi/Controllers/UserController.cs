using AutoMapper;
using EquipmentManager.Application.Services;
using EquipmentManager.Domain.Entities.Dtos;
using EquipmentManagerApi.Controllers.Requests;
using EquipmentManagerApi.Controllers.Requests.Validators;
using EquipmentManagerApi.Controllers.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentManagerApi.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserService _service;

        public UserController(UserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get(GetUserRequest request)
        {
            try
            {
                GetUserValidator validator = new GetUserValidator();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }
                var userDto = _mapper.Map<UserDto>(request);
                var user = _service.Get(userDto);

                var ret = _mapper.Map<GetUserResponse>(user);
                var response = new ApiResponse<GetUserResponse>()
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
        [AllowAnonymous]
        public async Task<IActionResult> Create(CreateUserRequest request)
        {
            try
            {
                CreateUserValidator validator = new CreateUserValidator();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }
                var userDto = _mapper.Map<UserDto>(request);
                var user = _service.Create(userDto);

                var ret = _mapper.Map<CreateUserResponse>(user);
                var response = new ApiResponse<CreateUserResponse>()
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
        [AllowAnonymous]
        public async Task<IActionResult> Update(UpdateUserRequest request)
        {
            try
            {
                UpdateUserValidator validator = new UpdateUserValidator();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }
                var userDto = _mapper.Map<UserDto>(request);
                var user = _service.Update(userDto);

                var ret = _mapper.Map<UpdateUserResponse>(user);
                var response = new ApiResponse<UpdateUserResponse>()
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
        [AllowAnonymous]
        
        public async Task<IActionResult> Delete(DeleteUserRequest request)
        {
            try
            {
                DeleteUserValidator validator = new DeleteUserValidator();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }
                var userDto = _mapper.Map<UserDto>(request);
                _service.Delete(userDto);

                var response = new ApiResponse<DeleteUserResponse>()
                {
                    Success = true,
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
