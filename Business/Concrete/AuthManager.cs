using Azure.Core;
using Business.Abstract;
using Core.Entities.Concrete.DTOs;
using Core.Entities.Concretes;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessToken = Core.Utilities.Security.JWT.AccessToken;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService)
        {
            _userService = userService;
        }

        public IDataResult<User> Register(RegisterDTO registerDTO, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordPash(password, out passwordHash, out passwordSalt);

            var user = new User()
            {
                Email = registerDTO.Email,
                FirstName = registerDTO.FirstName,
                MiddleName = registerDTO.MiddleName,
                LastName = registerDTO.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            var result = _userService.Add(user);

            if (!result.Success) return new ErrorDataResult<User>();
            return new SuccessDataResult<User>();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var accessToken = _tokenHelper.CreateToken(user);

            return new SuccessDataResult<AccessToken>(accessToken);
        }
    }
}
