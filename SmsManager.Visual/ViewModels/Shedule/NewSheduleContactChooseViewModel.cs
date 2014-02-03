using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Phone7.Fx.Ioc;
using Phone7.Fx.Mvvm;
using Phone7.Fx.Navigation;
using SmsManager.DataLayer.Repositories.Base;
using SmsManager.Visual.ViewModels.Base;
using SmsManager.Visual.Views;

namespace SmsManager.Visual.ViewModels.Shedule
{
     [ViewModel(typeof(ContactChooseView))]
    public class NewSheduleContactChooseViewModel:BaseContactChooseViewModel
    {


        [Injection]
        public NewSheduleContactChooseViewModel(IContactRepository contactRepository,INavigationService navigationService)
            :base(contactRepository,navigationService)
        {
            
        }

        protected override void OnContactSelected()
        {
            base._navigationService.UriFor<NewSheduleTelephoneKindChooserViewModel>().WithParam(x => x.SelectedContactId, this.SelectedContact.Id).Navigate();
        }
    }
}
