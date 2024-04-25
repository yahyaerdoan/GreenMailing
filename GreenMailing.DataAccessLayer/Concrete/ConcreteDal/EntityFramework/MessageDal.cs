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
            return _greenMailingDbContext.Messages
                                  .Where(m => m.Sender == email)
                                  .Join(_greenMailingDbContext.Users,
                                        message => message.Recever,
                                        user => user.Email,
                                        (message, user) => new Message
                                        {
                                            MessageId = message.MessageId,
                                            UserId = user.Id,
                                            Sender = message.Sender,
                                            Recever = message.Recever,
                                            Subject = message.Subject,
                                            Content = message.Content,
                                            Timestamp = message.Timestamp,
                                            Status = message.Status,
                                            IsRead = message.IsRead,
                                            IsTrash = message.IsTrash,
                                            IsImportant = message.IsImportant,
                                            IsStarred = message.IsStarred,
                                            User = user
                                        }).OrderByDescending(x => x.Timestamp)
                                  .ToList();
        }

        public List<Message> GetMessageListWithSender(string email)
        {
            return _greenMailingDbContext.Messages
                 .Include(x => x.User)
                 .Where(x => x.Recever == email)
                 .OrderByDescending(x => x.Timestamp)
                 .ToList();
        }

        public Message? GetMessageByIdWithSender(int id)
        {
            return _greenMailingDbContext.Messages
                 .Include(x => x.User).FirstOrDefault(x => x.MessageId == id);
        }

        public int GetUnReadMessagesCountByIdWithRecever(string email)
        {
            return _greenMailingDbContext.Messages
                .Include(x => x.User).Where(x => x.Recever == email && x.IsRead == false).Count();
        }
    }
}