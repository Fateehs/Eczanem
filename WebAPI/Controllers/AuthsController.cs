using Business.Abstract;
using Core.Entities.Concrete.DTOs;
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

            var createdAccessTokenDataWithSuccessResult = new SuccessDataResult<AccessToken>(createAccessTokenResult.Data);

            return Ok(createdAccessTokenDataWithSuccessResult);
        }
    }
}
