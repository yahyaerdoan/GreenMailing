﻿using GreenMailing.DataAccessLayer.Abstract.IAbstractDal;
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
                 .Where(x => x.Recever == email && x.IsTrash == false)
                 .OrderByDescending(x => x.Timestamp)
                 .ToList();
        }
        public Message? GetMessageByIdWithSender(int id)
        {
            return _greenMailingDbContext.Messages
                 .Include(x => x.User).FirstOrDefault(x => x.MessageId == id);
        }
        public int GetUnReadMessagesCountWithRecever(string email)
        {
            //return _greenMailingDbContext.Messages
            //    .Include(x => x.User).Where(x => x.Recever == email && x.IsRead == false).Count();

            return _greenMailingDbContext.Messages
                .Include(x => x.User).Count(x => x.Recever == email && !x.IsRead && !x.IsTrash);
        }
        public List<Message> GetLastOneUnReadMessagesWithReceiver(string email)
        {
            DateTime currentDate = DateTime.Today;

            return _greenMailingDbContext.Messages
                .Include(x => x.User)
                .Where(x => x.Recever == email && !x.IsRead && x.Timestamp.Date == currentDate)
                .OrderByDescending(x => x.Timestamp)
                .Take(1)
                .ToList();
        }
        public bool? ChangeIsReadStatusToTrue(int id)
        {
            var message = _greenMailingDbContext.Messages.FirstOrDefault(x => x.MessageId == id);

            if (message != null)
            {
                message.IsRead = true;
                _greenMailingDbContext.SaveChanges();
                return true; // Operation successful
            }
            return null; // Message with the specified ID not found
        }
        public bool? ChangeIsImportantStatusToTrue(int id)
        {
            var message = _greenMailingDbContext.Messages.FirstOrDefault(x=> x.MessageId == id);
            if (message != null)
            {
                message.IsImportant = true;
                _greenMailingDbContext.SaveChanges();
                return true;
            }
            return null;
        }
        public (int count, List<Message> isImportantMessages) GetIsImportantMessagesAndCountWithReceiver(string email)
        {
            var isImportantMessages = _greenMailingDbContext.Messages
                .Include(x => x.User)
                .Where(x => x.Recever == email && x.IsImportant == true)
                .ToList();

            var count = isImportantMessages.Count;

            return (count, isImportantMessages);
        }
        public int GetIsImportantMessagesCountWithReceiver(string email)
        {
            return _greenMailingDbContext.Messages
                .Include(x => x.User).Count(x => x.Recever == email && x.IsImportant == true);
        }
        public (int count, List<Message> isStarredMessages) GetIsStarredMessagesAndCountWithReceiver(string email)
        {
            var isStarredMessages = _greenMailingDbContext.Messages
                .Include(x => x.User)
                .Where(x => x.Recever == email && x.IsStarred == true)
                .ToList();

            var count = isStarredMessages.Count;

            return (count, isStarredMessages);
        }
        public bool? ChangeIsStarredStatusToTrue(int id)
        {
            var message = _greenMailingDbContext.Messages.FirstOrDefault(x => x.MessageId == id);
            if (message != null)
            {
                message.IsStarred = true;
                _greenMailingDbContext.SaveChanges();
                return true;
            }
            return null;
        }
        public bool? ChangeIsTrashStatusToTrue(List<int> id)
        {
            var messages = _greenMailingDbContext.Messages.Where(x => id.Contains(x.MessageId)).ToList();
            if (messages.Any())
            {
                foreach (var message in messages)
                {
                    message.IsTrash = true;
                }
                _greenMailingDbContext.SaveChanges();
                return true;
            }
            return null;
        }
        public int? DeleteIsTrashStatusTrueMessage(List<int> id)
        {
            var messages = _greenMailingDbContext.Messages.Where(x => id.Contains(x.MessageId) && x.IsTrash == true).ToList();
            if (messages.Any())
            {
                foreach (var message in messages)
                {
                    _greenMailingDbContext.Messages.Remove(message);
                }
                _greenMailingDbContext.SaveChanges();
                return messages.Count;
            }
            return null;
        }
        public (int count, List<Message> isTrashedMessages) GetIsTrashedMessagesAndCountWithReceiver(string email)
        {
            var isTrashedMessages = _greenMailingDbContext.Messages
                .Include(x => x.User)
                .Where(x => x.Recever == email && x.IsTrash == true)
                .ToList();

            var count = isTrashedMessages.Count;

            return (count, isTrashedMessages);
        }
    }
}