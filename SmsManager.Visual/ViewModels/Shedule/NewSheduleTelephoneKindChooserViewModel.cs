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
    [ViewModel(typeof(TelephoneKindChooseView))]
    public class NewSheduleTelephoneKindChooserViewModel:BaseTelephoneKindChooseViewModel
    {
        [Injection]
        public NewSheduleTelephoneKindChooserViewModel(INavigationService navigationService, IContactRepository contactRepository)
            :base(navigationService,contactRepository)
        {
            
        }

        protected override void OnSelectedPhoneAction()
        {
             base._navigationService.UriFor<NewShedulePeriodicAndTypeSetViewModel>().WithParam(x=>x.SelectedTelephoneNumber,base.SelectedPhone.TelephoneNumber).WithParam(x=>x.SelectedContactId,base.SelectedContactId).Navigate();
        }
    }
}
