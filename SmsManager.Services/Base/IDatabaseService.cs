using System.Collections.Generic;
using SmsManager.DataLayer.Dto;
using SmsManager.Infrastructure.IRepositories;

namespace SmsManager.Services.Base
{
    public interface IDatabaseService
    {
        ICategoryRepository CategoryRepository { get;}
        IMessagesRepository MessagesRepository { get;}

        IEnumerable<MessageDto> GetAllMessagesFromCategory(long categoryId);
    }
}
