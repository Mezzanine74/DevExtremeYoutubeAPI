using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevExtremeYoutubeDataAccess
{
    public interface IBaseDataAccess<T> where T: class, new()
    {
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter = null);
        T Add(T entity);
        int Delete(T entity);
        int Update(T entity);
        T GetByPrimaryKey(int primaryKey);
        IEnumerable<T> GetListByInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
    }
}
