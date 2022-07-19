using DevExtremeYoutubeModel.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevExtremeYoutubeDataAccess
{
    public class BaseDataAccess<TEntity> : IBaseDataAccess<TEntity> where TEntity : class, new()
    {
        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var db = new NorthwindEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                return filter == null
                    ? db.Set<TEntity>().ToList()
                    : db.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var db = new NorthwindEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                return db.Set<TEntity>().FirstOrDefault(filter);
            }
        }

        public TEntity Add(TEntity entity)
        {

            using (var db = new NorthwindEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                try
                {
                    DbEntityEntry _entity = db.Entry(entity);
                    _entity.State = EntityState.Added;
                    db.SaveChanges();
                    return entity;
                }
                catch (Exception e)
                {

                }

                return null;
            }
        }

        public int Delete(TEntity entity)
        {

            using (var db = new NorthwindEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                DbEntityEntry _entity = db.Entry(entity);
                _entity.State = EntityState.Deleted;
                return db.SaveChanges();
            }
        }

        public int Update(TEntity entity)
        {
            try
            {
                using (var db = new NorthwindEntities())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    DbEntityEntry _entity = db.Entry(entity);
                    _entity.State = EntityState.Modified;
                    return db.SaveChanges();
                }
            }
            catch (Exception e)
            {

            }

            return 0;

        }

        public TEntity GetByPrimaryKey(int primaryKey)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(TEntity), "x");
            Expression property = Expression.Property(parameter, "Id");
            Expression target = Expression.Constant(primaryKey);
            Expression equalsMethod = Expression.Call(property, "Equals", null, target);
            Expression<Func<TEntity, bool>> lambda = Expression.Lambda<Func<TEntity, bool>>(equalsMethod, parameter);

            using (var db = new NorthwindEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                return db.Set<TEntity>().FirstOrDefault(lambda);
            }
        }

        public IEnumerable<TEntity> GetListByInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            using (var context = new NorthwindEntities())
            {
                context.Configuration.LazyLoadingEnabled = false;
                var _dbSet = context.Set<TEntity>();
                IQueryable<TEntity> queryable = _dbSet.AsNoTracking();

                return includeProperties.Aggregate
                    (queryable, (current, includeProperty) => current.Include(includeProperty));

            }

        }
    }
}
