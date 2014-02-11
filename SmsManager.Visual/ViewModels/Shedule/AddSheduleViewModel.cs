using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using Phone7.Fx.Commands;
using Phone7.Fx.Ioc;
using Phone7.Fx.Mvvm;
using Phone7.Fx.Navigation;
using SmsManager.DataLayer.Dto;
using SmsManager.Infrastructure;
using SmsManager.Visual.Models;
using SmsManager.Visual.ViewModels.CategorySms;
using SmsManager.Visual.Views.Shedule;

namespace SmsManager.Visual.ViewModels.Shedule
{
    [ViewModel(typeof(AddSheduleView))]
    public class AddSheduleViewModel:ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly INewShedule _newShedule;
        public DelegateCommand<object> GetContactCommand { get; set; }


        [Injection]
        public AddSheduleViewModel(INavigationService navigationService,INewShedule newShedule){
            _navigationService = navigationService;
            _newShedule = newShedule;
            GetContactCommand=new DelegateCommand<object>(GetContact);
        }

        public ImageSource AccountImage{
            get{
                if (_newShedule.ContactDto != null){
                    return _newShedule.ContactDto.BitmapImage;
                }
                return Extensions.GetUnknownPersonImage();
            }
        }
        public string AccountName{
            get{
                if (_newShedule.ContactDto != null){
                    return _newShedule.ContactDto.DisplayName;
                }
                else{
                    return "Выберите контакт";
                }
            }
        }

        public IEnumerable<TelephoneDto> Telephones{
            get{
                if (_newShedule.ContactDto != null)
                {
                    return _newShedule.ContactDto.Telephones;
                }
              return new List<TelephoneDto>();
            }
        }

        private void GetContact(object param){
            _navigationService.UriFor<NewSheduleContactChooseViewModel>().Navigate();
        }
    }

}
