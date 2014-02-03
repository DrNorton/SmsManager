using System.Collections.Generic;
using System.Linq;
using Phone7.Fx.Commands;
using Phone7.Fx.Ioc;
using Phone7.Fx.Mvvm;
using Phone7.Fx.Navigation;
using SmsManager.DataLayer.Dto;
using SmsManager.Services.Base;
using SmsManager.Visual.Views;

namespace SmsManager.Visual.ViewModels.CategorySms
{
    [ViewModel(typeof(CategoryView))]
    public class CategoryViewModel : ViewModelBase
    {
        private readonly IDatabaseService _dataService;
        private readonly INavigationService _navigationService;
        

        public DelegateCommand<object> GetContactCommand { get; set; }

        public long CurrentCategoryId { get; set; }
        private MessageDto _selectedMessage;
    
        private CategoryDto _currentCategory;
        private IEnumerable<MessageDto> _categoryMessages;


        [Injection]
        public CategoryViewModel(IDatabaseService dataService, INavigationService navigationService){
            _dataService = dataService;
            _navigationService = navigationService;
            GetContactCommand=new DelegateCommand<object>(ToContactListNavigatedHandler);
        }

       

        private void ToContactListNavigatedHandler(object obj)
        { 
            if(SelectedMessage!=null)
            _navigationService.UriFor<CategoryContactChooseViewModel>().WithParam(x=>x.ChoosedMessageText,SelectedMessage.Text).Navigate();
        }

        public override void InitalizeData(){
            CurrentCategory=_dataService.CategoryRepository.GetItem(CurrentCategoryId);
            CategoryMessages = _dataService.GetAllMessagesFromCategory(CurrentCategoryId).ToList();
        }

        public CategoryDto CurrentCategory
        {
            get { return _currentCategory; }
            set{
                _currentCategory = value;
                base.RaisePropertyChanged(()=>CurrentCategory);
            }
        }

        public IEnumerable<MessageDto> CategoryMessages{
            get { return _categoryMessages; }
            set{
                _categoryMessages = value;
                base.RaisePropertyChanged(()=>CategoryMessages);
            }
        }

        public MessageDto SelectedMessage{
            get { return _selectedMessage; }
            set{
                _selectedMessage = value;
                base.RaisePropertyChanged(()=>SelectedMessage);
            }
        }
    }
}
