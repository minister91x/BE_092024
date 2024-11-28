using BE_092024.DataAccess.NetCore.DAL;
using BE_092024.DataAccess.NetCore.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_092024.DataAccess.NetCore.DALImpl
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private BE_092924DbContext _dbContext;
        public GenericRepository(BE_092924DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return  await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<int> Insert(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            // return await _dbContext.SaveChangesAsync();

            return 1;
        }

        public async Task<int> Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
