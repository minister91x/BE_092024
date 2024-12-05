using BE_092024.DataAccess.NetCore.DAL;
using BE_092024.DataAccess.NetCore.DataObject.RequestData;
using BE_092024.DataAccess.NetCore.DataObject.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BE_092024_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenController : ControllerBase
    {
        private IAccountRepository _accountRepository;
        private IConfiguration _configuration;

        public AuthenController(IAccountRepository accountRepository, IConfiguration configuration)
        {
            _accountRepository = accountRepository;
            _configuration = configuration;
        }
        [HttpPost("Account_Login")]
        public async Task<ActionResult> Account_Login(AccountLoginRequestData requestData)
        {
            var responseData = new UserLoginResponseData();
            try
            {
                // Bước 1: Đăng nhập
                var user = await _accountRepository.User_Login(requestData);

                if (user == null)
                {
                    responseData.ResponseCode = -1;
                    responseData.ResponseMessage = "Đăng nhập thất bại, kiểm tra lại username hoặc mật khẩu";
                    return Ok(responseData);
                }

                // Bước 2: Tạo token 

                var authClaims = new List<Claim> { new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, user.UserID.ToString())};

                var newToken = CreateToken(authClaims);

                responseData.ResponseCode = 1;
                responseData.ResponseMessage = "Đăng nhập thành công!";
                responseData.token = new JwtSecurityTokenHandler().WriteToken(newToken);

                return Ok(responseData);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        private JwtSecurityToken CreateToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            _ = int.TryParse(_configuration["JWT:TokenValidityInMinutes"], out int tokenValidityInMinutes);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(tokenValidityInMinutes),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

    }
}
