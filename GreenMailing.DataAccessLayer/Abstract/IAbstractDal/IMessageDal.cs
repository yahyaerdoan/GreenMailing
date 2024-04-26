using GreenMailing.DataAccessLayer.Abstract.IGenericRepository;
using GreenMailing.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenMailing.DataAccessLayer.Abstract.IAbstractDal
{
    public interface IMessageDal : IGenericRepository<Message>
    {
        List<Message> GetMessageListWithSender(string email);
        List<Message> GetMessageListWithRecever(string email);
        Message? GetMessageByIdWithSender(int id);
        int GetUnReadMessagesCountWithRecever(string email);
        List<Message> GetLastOneUnReadMessagesWithReceiver(string email);
        bool? ChangeIsReadStatusToTrue(int id);
        bool? ChangeIsImportantStatusToTrue(int id);
        (int count, List<Message> isImportantMessages) GetIsImportantMessagesAndCountWithReceiver(string email);
        int GetIsImportantMessagesCountWithReceiver(string email);
    }
}