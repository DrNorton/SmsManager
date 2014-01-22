using System.Collections.Generic;
using SmsManager.Infrastructure.Entities;
using SmsManager.Infrastructure.Entities.Dto;

namespace SmsManager.Infrastructure.IRepositories
{
    public interface IMessagesRepository
    {
        IMessageDetail UpdateEntry(IMessageDto sourceDto, IMessageDetail targetEntity);
        IMessageDetail CreateEntry(IMessageDto dto);
        IMessageDto Convert(IMessageDetail entity);
        IEnumerable<IMessageDto> Search(string pattern);
        IEnumerable<IMessageDto> GetAll();
        IMessageDto GetItem(long id);
        void InsertOrUpdateRange(IEnumerable<IMessageDto> items);
        void InsertOrUpdate(IMessageDto dto);
        void Delete(IMessageDto dto);
        void Insert(IMessageDto dto);
    }
}
