using GreenMailing.BusinessLayer.Abstract.IAbstractService;
using GreenMailing.DataAccessLayer.Abstract.IAbstractDal;
using GreenMailing.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GreenMailing.BusinessLayer.Concrete.ConcreteManager
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void Add(Message entity)
        {
            _messageDal.Add(entity);
        }

        public void Delete(Message entity)
        {
            _messageDal.Delete(entity);
        }

        public Message Get(Expression<Func<Message, bool>> filter)
        {
            var values = _messageDal.Get(filter);
            return values;
        }

        public List<Message> GetAll(Expression<Func<Message, bool>>? filter = null)
        {
            var values = _messageDal.GetAll(filter);
            return values;
        }

        public List<Message> GetMessageListWithRecever(string email)
        {
            var values = _messageDal.GetMessageListWithRecever(email); 
            return values;   
        }

        public List<Message> GetMessageListWithSender(string email)
        {
            var values = _messageDal.GetMessageListWithSender(email);
            return values;
        }

        public void Update(Message entity)
        {
            _messageDal.Update(entity);
        }
    }
}