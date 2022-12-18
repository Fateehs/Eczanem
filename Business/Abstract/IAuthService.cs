using Core.Entities.Concrete.DTOs.Auth;
using Core.Entities.Concretes;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Security.JWT;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(RegisterDTO registerDTO, string password);
        IDataResult<User> Login(LoginDTO loginDTO);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
