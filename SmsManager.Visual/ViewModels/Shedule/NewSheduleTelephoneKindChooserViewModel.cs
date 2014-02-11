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
    [ViewModel(typeof(TelephoneKindChooseView))]
    public class NewSheduleTelephoneKindChooserViewModel:BaseTelephoneKindChooseViewModel
    {
        private readonly INewShedule _newShedule;
        public long SelectedContactId { get; set; }

        [Injection]
        public NewSheduleTelephoneKindChooserViewModel(INavigationService navigationService, IContactRepository contactRepository,INewShedule newShedule)
            :base(navigationService,contactRepository){
            _newShedule = newShedule;
            base.SelectedContactId = _newShedule.ContactDto.Id;
        }

        protected override void OnSelectedPhoneAction(){
            _newShedule.Telephone = base.SelectedPhone;
          base._navigationService.UriFor<AddSheduleViewModel>().Navigate();
        }
    }
}
