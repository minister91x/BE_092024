using BE_092024.Common;
using BE_092024.DataAccess.NetCore.DAL;
using BE_092024.DataAccess.NetCore.DataObject;
using BE_092024.DataAccess.NetCore.DataObject.RequestData;
using BE_092024.DataAccess.NetCore.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace BE_092024.DataAccess.NetCore.DALImpl
{
    public class AccountRepository : IAccountRepository
    {
        private BE_092924DbContext _dbContext;
        public AccountRepository(BE_092924DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Function> Function_ByName(string functionName)
        {
            return _dbContext.function.Where(s=>s.FunctionName == functionName).FirstOrDefault();
            
        }

        public User GetUser_ByUsername(string username)
        {
            return _dbContext.user.Where(s => s.UserName == username).FirstOrDefault();
        }

        public async Task<Permission> Permission_GetByUser(int UserID, int FunctionID)
        {
            return _dbContext.permission.Where(s => s.UserID == UserID && s.FunctionID==FunctionID).FirstOrDefault();
        }

        public async Task<User> User_Login(AccountLoginRequestData requestData)
        {
			try
			{
                var passwordHash = Sercurity.EncryptPassWord(requestData.Password);

                var user = _dbContext.user.ToList().Where(s=>s.UserName == requestData.UserName
                && s.PassWord== passwordHash).FirstOrDefault();

                return user;
			}
			catch (Exception ex)
			{

				throw;
			}
        }

        public async Task<int> User_UpdateRefestoken(int UserID, string RefreshToken, DateTime RefreshTokenExpiryTime)
        {
            var user = _dbContext.user.Where(s => s.UserID == UserID).FirstOrDefault();
            if (user == null)
            {
                return -1;
            }

            user.RefeshToken = RefreshToken;
            user.TokenExprired = RefreshTokenExpiryTime;
            _dbContext.user.Update(user);
            _dbContext.SaveChanges();

            return 1;
        }
    }
}
