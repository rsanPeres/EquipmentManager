using AutoMapper;
using EquipmentManager.Application.Services;
using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Entities.Dtos;
using EquipmentManagerApi.Controllers.Requests;
using EquipmentManagerApi.Controllers.Requests.Validators;
using EquipmentManagerApi.Controllers.Responses;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentManagerApi.Controllers
{
    [ApiController]
    [Route("api/v1/login")]
    public class LoginController : Controller
    {
        private readonly LoginService _loginService;
        private readonly IMapper _mapper;
        private readonly TokenService _tokenService;

        public LoginController(LoginService service, IMapper mappper, TokenService token)
        {
            _loginService = service;
            _mapper = mappper;
            _tokenService = token;
        }

        [HttpPost]
        public async Task<ActionResult<dynamic>> AuthenticateAsync(LoginUserRequest request)
        {
            try
            {
                LoginUserValidator validator = new LoginUserValidator();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }
                var userDto = _mapper.Map<UserDto>(request);
                var user = _loginService.VerifyUserPassword(userDto);
                if (user == null) return NotFound(new { message = "User not found"});

                var userT = _mapper.Map<User>(user);
                var token = _tokenService.GenerateToken(userT);

                var ret = _mapper.Map<LoginUserResponse>(user);
                ret.Token = token;
                var response = new ApiResponse<LoginUserResponse>()
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
