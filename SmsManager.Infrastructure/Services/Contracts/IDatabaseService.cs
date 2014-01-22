using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmsManager.Infrastructure.IRepositories;

namespace SmsManager.Infrastructure.Services.Contracts
{
    public interface IDatabaseService
    {
        ICategoryRepository CategoryRepository { get;}
        IMessagesRepository MessagesRepository { get;}
    }
}
