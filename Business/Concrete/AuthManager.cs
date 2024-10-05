using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService; // Kullanıcı var mı yok mu kontrol etmek için bu interface lazımdır.
        private ITokenHelper _tokenHelper; // Token üretmek için kullanacagağımız interface.
        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;

        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var operationClaims =_userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, operationClaims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            // bu business işlemleri BusinessRules ile yazılmalı. Code Refactoring yap.
            var userToCheck = _userService.GetByEmail(userForLoginDto.Email).Data; // userToCheck null oluyor, chatgpt'den bak.
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
        
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash,
                userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User()
            {
                Email= userForRegisterDto.Email,
                FirstName= userForRegisterDto.FirstName,
                LastName= userForRegisterDto.LastName,
                PasswordHash= passwordHash,
                PasswordSalt= passwordSalt,
                Status= true // email doğrulaması veya birinin onayını gerektiriyorsa status = false olarak işaretlenir.
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByEmail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }

            return new SuccessResult();

        }
    }
}
