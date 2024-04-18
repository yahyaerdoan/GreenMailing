using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GreenMailing.DataAccessLayer.Abstract.IGenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class, new()
    {
        List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null);      
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}