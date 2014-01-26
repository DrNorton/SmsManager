using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmsManager.Services;

namespace SmsManager.Tests.FakeServices
{
    public class FakeDatabaseService:IDatabaseService
    {
        public Infrastructure.IRepositories.ICategoryRepository CategoryRepository
        {
            get { throw new NotImplementedException(); }
        }

        public Infrastructure.IRepositories.IMessagesRepository MessagesRepository
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<DataLayer.Dto.MessageDto> GetAllMessagesFromCategory(long categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
