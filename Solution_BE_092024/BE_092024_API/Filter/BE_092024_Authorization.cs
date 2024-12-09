using BE_092024.DataAccess.NetCore.DAL;
using BE_092024.DataAccess.NetCore.DBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace BE_092024_API.Filter
{
    public class BE_092024_AuthorizationAttribute : TypeFilterAttribute
    {
        public BE_092024_AuthorizationAttribute(string functionCode, string permission) : base(typeof(DemoAuthorizeActionFilter))
        {
            Arguments = new object[] { functionCode, permission };
        }
    }

    public class DemoAuthorizeActionFilter : IAsyncAuthorizationFilter
    {

        private readonly string _functionCode;
        private readonly string _permission;
        private readonly IAccountRepository _accountRepository;
        public DemoAuthorizeActionFilter(string functionCode, string permission, IAccountRepository accountRepository)
        {
            _functionCode = functionCode;
            _permission = permission;
            _accountRepository = accountRepository;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            // Đọc thông tin từ Claims 

            var identity = context.HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {

                var userClaims = identity.Claims;

                var userId = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.PrimarySid)?.Value != null

                    ? Convert.ToInt32(userClaims.FirstOrDefault(x => x.Type == ClaimTypes.PrimarySid)?.Value) : 0;

                if (userId == 0)
                {
                    context.HttpContext.Response.ContentType = "application/json";
                    context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
                    context.Result = new JsonResult(new
                    {
                        ReturnCode = System.Net.HttpStatusCode.Unauthorized,
                        ReturnMessage = "Vui lòng đăng nhập để thực hiện chức năng này "
                    });
                    return;
                }

                // Lấy functionID dựa vào functionCode 

                var function = await _accountRepository.Function_ByName(_functionCode);
                if (function == null)
                {
                    context.HttpContext.Response.ContentType = "application/json";
                    context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
                    context.Result = new JsonResult(new
                    {
                        ReturnCode = System.Net.HttpStatusCode.Unauthorized,
                        ReturnMessage = "Chức năng này không hợp lệ"
                    });
                    return;
                }

                // lấy quyền từ userid và functionID 
                var permission = await _accountRepository.Permission_GetByUser(userId, function.FunctionID);

                if (permission == null)
                {

                    context.HttpContext.Response.ContentType = "application/json";
                    context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
                    context.Result = new JsonResult(new
                    {
                        ReturnCode = System.Net.HttpStatusCode.Unauthorized,
                        ReturnMessage = "Bạn không có quyền thực hiện chức năng này"
                    });
                    return;

                }


                switch (_permission)
                {
                    case "VIEW":
                        if (permission.IsView == 0)
                        {
                            context.HttpContext.Response.ContentType = "application/json";
                            context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
                            context.Result = new JsonResult(new
                            {
                                ReturnCode = System.Net.HttpStatusCode.Unauthorized,
                                ReturnMessage = "Bạn không có quyền thực hiện chức năng này"
                            });
                            return;
                        }
                        break;

                    case "INSERT":
                        if (permission.IsInsert == 0)
                        {
                            context.HttpContext.Response.ContentType = "application/json";
                            context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
                            context.Result = new JsonResult(new
                            {
                                ReturnCode = System.Net.HttpStatusCode.Unauthorized,
                                ReturnMessage = "Bạn không có quyền thực hiện chức năng này"
                            });
                            return;
                        }
                        break;
                }

            }

        }
    }

}
