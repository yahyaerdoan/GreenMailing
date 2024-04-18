using GreenMailing.DataAccessLayer.Abstract.IGenericRepository;
using GreenMailing.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace GreenMailing.DataAccessLayer.Concrete.GenericRepository
{
    public class EfGenericRepository<TEntity, TContext> : IGenericRepository<TEntity> where TEntity : class, new() where TContext : IdentityDbContext<User, Role, int>, new()
    {
        protected readonly IdentityDbContext<User, Role, int> context;
        protected readonly DbSet<TEntity> set;

        public EfGenericRepository(IdentityDbContext<User, Role, int> context)
        {
            this.context = context;
            this.set = this.context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            set.Add(entity);
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            set.Remove(entity);
            context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            var values = set.FirstOrDefault(filter);
            return values;
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
        {
            if (filter != null)
            {
                return set.Where(filter).ToList();
            }
            else
            {
                return set.ToList();
            }
        }

        public void Update(TEntity entity)
        {
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified; 
            context.SaveChanges();
        }
    }
}