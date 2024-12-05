using BE_092024.Common;
using BE_092024.DataAccess.NetCore.DAL;
using BE_092024.DataAccess.NetCore.DataObject;
using BE_092024.DataAccess.NetCore.DataObject.RequestData;
using BE_092024.DataAccess.NetCore.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
