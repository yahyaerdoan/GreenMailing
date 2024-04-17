using GreenMailing.DataAccessLayer.Abstract.IAbstractDal;
using GreenMailing.DataAccessLayer.Abstract.IGenericRepository;
using GreenMailing.DataAccessLayer.Concrete.Context;
using GreenMailing.DataAccessLayer.Concrete.GenericRepository;
using GreenMailing.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenMailing.DataAccessLayer.Concrete.ConcreteDal.EntityFramework
{
    public class UserDal : EfGenericRepository<User, GreenMailingDbContext>, IUserDal
    {
        public UserDal(DbContext context) : base(context)
        {
        }
    }
}