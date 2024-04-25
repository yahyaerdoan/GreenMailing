using GreenMailing.BusinessLayer.Abstract.IGenericService;
using GreenMailing.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenMailing.BusinessLayer.Abstract.IAbstractService
{
    public interface IMessageService : IGenericService<Message>
    {
        List<Message> GetMessageListWithSender(string email);
        List<Message> GetMessageListWithRecever(string email);
        Message? GetMessageByIdWithSender(int id);
        int GetUnReadMessagesCountWithRecever(string email);
    }
}