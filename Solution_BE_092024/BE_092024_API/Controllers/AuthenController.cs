using BE_092024.DataAccess.NetCore.DAL;
using BE_092024.DataAccess.NetCore.DataObject;
using BE_092024.DataAccess.NetCore.DataObject.RequestData;
using BE_092024.DataAccess.NetCore.DataObject.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Collections.Generic;
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
        private readonly IDistributedCache _cache;

        public AuthenController(IAccountRepository accountRepository,
            IConfiguration configuration, IDistributedCache cache)
        {
            _accountRepository = accountRepository;
            _configuration = configuration;
            _cache = cache;
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
                var refehtoken = GenerateRefreshToken();

                // Lưu refeshtoken 
                _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);

                await _accountRepository.User_UpdateRefestoken(user.UserID, refehtoken, DateTime.Now.AddDays(refreshTokenValidityInDays));


                // Lưu vào RedisCaching
                var cacheKey = "USER_LOGIN_TOKEN_" + user.UserID + "_" + requestData.DeviceID;
                //Set data vào caching 

                var user_Sessions = new User_Sessions();
                user_Sessions.UserId = user.UserID;
                user_Sessions.token = new JwtSecurityTokenHandler().WriteToken(newToken);
                user_Sessions.createdTime = DateTime.Now;
                user_Sessions.deviceID = requestData.DeviceID;

                var dataCacheJson = JsonConvert.SerializeObject(user_Sessions);
                var dataToCache = Encoding.UTF8.GetBytes(dataCacheJson);
                DistributedCacheEntryOptions options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(DateTime.Now.AddMinutes(1));

                _cache.Set(cacheKey, dataToCache, options);

                responseData.ResponseCode = 1;
                responseData.ResponseMessage = "Đăng nhập thành công!";
                responseData.token = new JwtSecurityTokenHandler().WriteToken(newToken);
                responseData.refeshToken = refehtoken;
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
            var responseData = new UserLoginResponseData();
            try
            {
                if (tokenModel == null
                    || string.IsNullOrEmpty(tokenModel.RefreshToken)
                    || string.IsNullOrEmpty(tokenModel.AccessToken))
                {
                    responseData.ResponseCode = -1;
                    responseData.ResponseMessage = "dữ liệu đầu vào không hợp lệ";
                    return Ok(responseData);
                }

                // Bước 1 : giải mã token truyền lên để lấy claims 
                var principal = GetPrincipalFromExpiredToken(tokenModel.AccessToken);
                if (principal == null)
                {
                    responseData.ResponseCode = -1;
                    responseData.ResponseMessage = "token không hợp lệ";
                    return Ok(responseData);
                }
                // Bước 2: check refeshtoken và ngày hết hạn 

                var exp = DateTimeOffset.FromUnixTimeSeconds(long.Parse(principal.FindFirst("exp").Value));
                //or as DateTime:
                DateTime result = exp.UtcDateTime.AddHours(7);



                string username = principal.Identity.Name;

                // GỌI DB ĐỂ LẤY THEO USERNAME 
                var user = _accountRepository.GetUser_ByUsername(username);

                // ngày hết hạn < thời gian hiện tại
                // refeshtoken truyền lên khác với refeshtoken trong db => sai token
                if (user == null || user.RefeshToken != tokenModel.RefreshToken || user.TokenExprired <= DateTime.Now)
                {
                    responseData.ResponseCode = -1;
                    responseData.ResponseMessage = "token không hợp lệ";
                    return Ok(responseData);
                }

                var newToken = CreateToken(principal.Claims.ToList());
                var newRefehtoken = GenerateRefreshToken();
                // Bước 3 : tạo token mới và refeshtoken mới 


                // Lưu refeshtoken 
                _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);

                await _accountRepository.User_UpdateRefestoken(user.UserID, newRefehtoken, DateTime.Now.AddDays(refreshTokenValidityInDays));

                responseData.ResponseCode = 1;
                responseData.ResponseMessage = "Đăng nhập thành công!";
                responseData.token = new JwtSecurityTokenHandler().WriteToken(newToken);
                responseData.refeshToken = newRefehtoken;
                return Ok(responseData);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost("Logout")]
        public async Task<IActionResult> LogOut(TokenLogOutModel tokenLogOut)
        {
            var responseData = new UserLogOutResponseData();
            try
            {
                if (tokenLogOut == null
                    || string.IsNullOrEmpty(tokenLogOut.AccessToken)
                     || string.IsNullOrEmpty(tokenLogOut.DeviceID))
                {
                    responseData.ResponseCode = -1;
                    responseData.ResponseMessage = "Đăng nhập thất bại, kiểm tra lại username hoặc mật khẩu";
                    return Ok(responseData);
                }

                // thực hiện xóa token trong cache 

                // giải mã token 

                // Bước 1 : giải mã token truyền lên để lấy claims 
                var principal = GetPrincipalFromExpiredToken(tokenLogOut.AccessToken);
                if (principal == null)
                {
                    responseData.ResponseCode = -1;
                    responseData.ResponseMessage = "token không hợp lệ";
                    return Ok(responseData);
                }
                // Bước 2: check refeshtoken và ngày hết hạn 

                string username = principal.Identity.Name;
                var user = _accountRepository.GetUser_ByUsername(username);
                if (user == null)
                {
                    responseData.ResponseCode = -1;
                    responseData.ResponseMessage = "token không hợp lệ";
                    return Ok(responseData);
                }
                // lấy dữ liệu từ redis bằng keycache 
                var cacheKey = "USER_LOGIN_TOKEN_" + user.UserID + "_" + tokenLogOut.DeviceID;
                // thực hiện xóa token của thiết bị này trong redis caching

                _cache.Remove(cacheKey);

                responseData.ResponseCode = 1;
                responseData.ResponseMessage = "Đăng xuất thành công!";

                return Ok(responseData);
                //byte[] cachedData = await _cache.GetAsync(cacheKey);

                //if (cachedData == null)
                //{
                //    responseData.ResponseCode = -1;
                //    responseData.ResponseMessage = "đã đăng xuất hoặc hết hạn token";
                //    return Ok(responseData);
                //}


                //// Trong cache có dữ liệu thì lấy luôn từ cache và trả về client
                //var cachedDataString = Encoding.UTF8.GetString(cachedData);
                //var user_sessions = JsonConvert.DeserializeObject<List<User_Sessions>>(cachedDataString);

                //if (user_sessions == null || user_sessions.Count <= 0)
                //{
                //    responseData.ResponseCode = -1;
                //    responseData.ResponseMessage = "đã đăng xuất hoặc hết hạn token";
                //    return Ok(responseData);
                //}

                //var session = user_sessions.FindAll(s => s.token == tokenLogOut.AccessToken && s.deviceID == tokenLogOut.DeviceID).FirstOrDefault();



            }
            catch (Exception EX)
            {

                throw;
            }

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
