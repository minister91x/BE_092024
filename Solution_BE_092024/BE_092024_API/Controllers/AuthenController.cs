using BE_092024.DataAccess.NetCore.DAL;
using BE_092024.DataAccess.NetCore.DataObject.RequestData;
using BE_092024.DataAccess.NetCore.DataObject.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
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
                    new Claim(ClaimTypes.Actor, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.PrimarySid, user.UserID.ToString())};

                var newToken = CreateToken(authClaims);

                // Lưu refeshtoken 
                _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);
                var refehtoken = GenerateRefreshToken();
                await _accountRepository.User_UpdateRefestoken(user.UserID, refehtoken, DateTime.Now.AddDays(refreshTokenValidityInDays));

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



        [HttpPost]
        [Route("refresh-token")]
        public async Task<IActionResult> RefreshToken(TokenModel tokenModel)
        {
            // Bước 1 : giải mã token truyền lên để lấy claims 
            var principal = GetPrincipalFromExpiredToken(tokenModel.AccessToken);
            // Bước 2: check refeshtoken và ngày hết hạn 


            string username = principal.Identity.Name;

            // GỌI DB ĐỂ LẤY THEO USERNAME 

            // ngày hết hạn < thời gian hiện tại
            // refeshtoken truyền lên khác với refeshtoken trong db => sai token

            // Bước 3 : tạo token mới và refeshtoken mới 

            return Ok();
        }


        private ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;

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

        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

    }
}
