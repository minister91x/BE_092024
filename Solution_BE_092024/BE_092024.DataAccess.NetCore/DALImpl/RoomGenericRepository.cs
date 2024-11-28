using BE_092024.DataAccess.NetCore.DAL;
using BE_092024.DataAccess.NetCore.DataObject;
using BE_092024.DataAccess.NetCore.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_092024.DataAccess.NetCore.DALImpl
{
    public class RoomGenericRepository : GenericRepository<Room>, IRoomGenericRepository
    {
        public RoomGenericRepository(BE_092924DbContext dbContext) : base(dbContext)
        {
        }
    }
}
