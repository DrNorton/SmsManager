using System.Collections.Generic;
using SmsManager.DataLayer.Dto;
using SmsManager.DataLayer.Entities;
using SmsManager.DataLayer.Repositories.Base;
using SmsManager.Infrastructure.Entities;
using SmsManager.Infrastructure.Entities.Dto;

namespace SmsManager.Infrastructure.IRepositories
{
    public interface IMessagesRepository
    {
        Message UpdateEntry(MessageDto sourceDto, Message targetEntity);
        Message CreateEntry(MessageDto dto);
        MessageDto Convert(Message entity);
        IEnumerable<MessageDto> Search(string pattern);
        event BaseRepository<Message, MessageDto>.ChangeHandler OnChange;
        IEnumerable<MessageDto> GetAll();
        MessageDto GetItem(long id);
        void InsertOrUpdateRange(IEnumerable<MessageDto> items);
        void InsertOrUpdate(MessageDto dto);
        void Delete(MessageDto dto);
        void Insert(MessageDto dto);

        IEnumerable<MessageDto> GetAllFromCategory(long categoryId);
    }
}
