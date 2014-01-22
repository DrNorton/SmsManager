using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Phone7.Fx.Ioc;
using SmsManager.Infrastructure.IRepositories;
using SmsManager.Infrastructure.Services.Contracts;

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
    }
}
