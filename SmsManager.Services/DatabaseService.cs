using Phone7.Fx.Ioc;
using SmsManager.DataLayer.Dto;
using SmsManager.Infrastructure.IRepositories;
using SmsManager.Services.Base;

namespace SmsManager.Services
{
    public class DatabaseService : IDatabaseService{
        private ICategoryRepository _categoryRepository;
        private IMessagesRepository _messagesRepository;

        [Injection]
        public DatabaseService(ICategoryRepository categoryRepository,IMessagesRepository messagesRepository){
            _categoryRepository = categoryRepository;
            _messagesRepository = messagesRepository;
            var test = _categoryRepository.GetAll();
        }

        public Infrastructure.IRepositories.ICategoryRepository CategoryRepository
        {
            get{
                return _categoryRepository;
            }
            
        }

        public Infrastructure.IRepositories.IMessagesRepository MessagesRepository
        {
            get{
                return _messagesRepository;
            }
        }

        public System.Collections.Generic.IEnumerable<MessageDto> GetAllMessagesFromCategory(long categoryId){
            return _messagesRepository.GetAllFromCategory(categoryId);
        }
    }
}
