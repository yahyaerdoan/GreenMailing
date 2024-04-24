using GreenMailing.DataAccessLayer.Abstract.IAbstractDal;
using GreenMailing.DataAccessLayer.Concrete.Context;
using GreenMailing.DataAccessLayer.Concrete.GenericRepository;
using GreenMailing.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenMailing.DataAccessLayer.Concrete.ConcreteDal.EntityFramework
{
    public class MessageDal : EfGenericRepository<Message, GreenMailingDbContext>, IMessageDal
    {
        private readonly GreenMailingDbContext _greenMailingDbContext;

        public MessageDal(IdentityDbContext<User, Role, int> context, GreenMailingDbContext greenMailingDbContext) : base(context)
        {
            _greenMailingDbContext = greenMailingDbContext;
        }

        public List<Message> GetMessageListWithRecever(string email)
        {
            return _greenMailingDbContext.Messages.Include(x=>x.User).Where(x=> x.Sender == email).ToList();
        }

        public List<Message> GetMessageListWithSender(string email)
        {
           return _greenMailingDbContext.Messages.Include(x=> x.User).Where(x=> x.Recever == email).ToList();
        }
    }
}