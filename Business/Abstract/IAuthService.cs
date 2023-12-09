using Azure.Core;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessToken = Core.Utilities.Security.JWT.AccessToken;

namespace Business.Abstract
{
    // Bu interface vasıtasıyla sisteme login veya register olunur.
    // login :Veritabanından kullanıcının varlığını kontrol edilmesi işlemini yapar.
    // register : Kullanıcının sisteme kayıt olması ile ona bir result verilir.
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);

    }
}
