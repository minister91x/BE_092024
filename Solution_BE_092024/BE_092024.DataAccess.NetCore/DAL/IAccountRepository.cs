using BE_092024.DataAccess.NetCore.DataObject;
using BE_092024.DataAccess.NetCore.DataObject.RequestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_092024.DataAccess.NetCore.DAL
{
    public interface IAccountRepository
    {
        Task<User> User_Login(AccountLoginRequestData requestData);

        Task<User> User_GetByID(int id);
        Task<Function> Function_ByName(string functionName);

        Task<Permission> Permission_GetByUser(int UserID,int FunctionID);


        Task<int> User_UpdateRefestoken(int UserID,string RefreshToken,DateTime RefreshTokenExpiryTime);

        User GetUser_ByUsername(string username);

    }
}
