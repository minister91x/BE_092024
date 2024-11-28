using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_092024.DataAccess.NetCore.DAL
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();

        Task<int> Insert(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(T entity);
    }
}
