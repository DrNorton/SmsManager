using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Phone7.Fx.Ioc;
using Phone7.Fx.Mvvm;
using Phone7.Fx.Navigation;
using SmsManager.DataLayer.Repositories.Base;
using SmsManager.Visual.Models;
using SmsManager.Visual.ViewModels.Base;
using SmsManager.Visual.Views;

namespace SmsManager.Visual.ViewModels.Shedule
{
     [ViewModel(typeof(ContactChooseView))]
    public class NewSheduleContactChooseViewModel:BaseContactChooseViewModel
    {
         private readonly INewShedule _shedule;

         [Injection]
        public NewSheduleContactChooseViewModel(IContactRepository contactRepository,INavigationService navigationService,INewShedule shedule)
            :base(contactRepository,navigationService){
            _shedule = shedule;
        }

         protected override void OnContactSelected(){
             _shedule.ContactDto = base.SelectedContact;
            base._navigationService.UriFor<AddSheduleViewModel>().Navigate();
        }
    }
}
