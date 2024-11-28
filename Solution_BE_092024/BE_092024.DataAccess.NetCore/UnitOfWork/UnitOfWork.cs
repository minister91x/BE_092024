using BE_092024.DataAccess.NetCore.DAL;
using BE_092024.DataAccess.NetCore.DBContext;
using BE_092024_API.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_092024.DataAccess.NetCore.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private BE_092924DbContext _dbContext;
        public IRoomGenericRepository _roomGenericRepository { get; set; }
        public IProductRepository _productRepository { get; set; }
        public UnitOfWork(BE_092924DbContext dbContext, IRoomGenericRepository roomGenericRepository, IProductRepository productRepository)
        {
            _dbContext = dbContext;
            _roomGenericRepository = roomGenericRepository;
            _productRepository = productRepository;
        }


        public int SaveChange()
        {
            return _dbContext.SaveChanges();
        }
    }
}
