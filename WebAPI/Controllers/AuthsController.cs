using Business.Abstract;
using Core.Entities.Concrete.DTOs.Auth;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private IAuthService _authService;

        public AuthsController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDTO registerDTO)
        {
            var result = _authService.Register(registerDTO, registerDTO.Password);
            if (!result.Success) return BadRequest(result);

            var createAccessTokenResult = _authService.CreateAccessToken(result.Data);
            if (!result.Success) return BadRequest(result);

            var createdAccessTokenDataWithSuccessResult = new SuccessDataResult<AccessToken>(createAccessTokenResult.Data, result.Message);

            return Ok(createdAccessTokenDataWithSuccessResult);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO loginDTO)
        {
            var result = _authService.Login(loginDTO);
            if (!result.Success) return BadRequest(result);

            var createAccessTokenResult = _authService.CreateAccessToken(result.Data);
            if (!result.Success) return BadRequest(result);

            var newSuccessDataResult = new SuccessDataResult<AccessToken>(createAccessTokenResult.Data, result.Message);
            return Ok(newSuccessDataResult);

        }
    }
}
