using SmsManager.Infrastructure.IRepositories;

namespace SmsManager.Services
{
    public interface IDatabaseService
    {
        ICategoryRepository CategoryRepository { get;}
        IMessagesRepository MessagesRepository { get;}
    }
}
