using Business.Abstract;
using Core.Entities.Concrete.DTOs;
using Core.Entities.Concretes;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(RegisterDTO registerDTO, string password)
        {
            BusinessRules.Run(CheckTheEmailIsAlreadyRegistered(registerDTO));

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

        public IDataResult<User> Login(LoginDTO loginDTO)
        {
            var getUserData = _userService.GetByEmail(loginDTO.Email);

            if (getUserData == null) return new ErrorDataResult<User>();

            if (!HashingHelper.VerifyPasswordHash(loginDTO.Password, getUserData.Data.PasswordHash, getUserData.Data.PasswordSalt))

                return new ErrorDataResult<User>();

            return new SuccessDataResult<User>(getUserData.Data);
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);

            return new SuccessDataResult<AccessToken>(accessToken);
        }

        private IResult CheckTheEmailIsAlreadyRegistered(RegisterDTO registerDTO)
        {
            var emailToCheckResult = _userService.GetByEmail(registerDTO.Email);

            if (emailToCheckResult != null)

                return new SuccessResult();

            return new ErrorResult();
        }
    }
}
