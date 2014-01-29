using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Phone7.Fx.Ioc;
using Phone7.Fx.Mvvm;
using Phone7.Fx.Navigation;
using SmsManager.DataLayer.Dto;
using SmsManager.Services.Base;
using SmsManager.Services.Models;
using SmsManager.Visual.ViewModels.Contracts;
using SmsManager.Visual.Views;
using SmsManager.DataLayer.Repositories.Base;

namespace SmsManager.Visual.ViewModels
{
    [ViewModel(typeof(TelephoneKindChooseView))]
    public class TelephoneKindChooseViewModel : ViewModelBase, ITelephoneKindChooseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly ISmsSenderService _smsSenderService;
        private readonly IContactRepository _contactRepository;


        public string ChoosedMessageText { get; set; }
        public  long SelectedContactId { get; set; }
        private ContactDto _selectedContact;
        private string _selectedPhone;

        [Injection]
        public TelephoneKindChooseViewModel(INavigationService navigationService, ISmsSenderService smsSenderService,IContactRepository contactRepository)
        {
            _navigationService = navigationService;
            _smsSenderService = smsSenderService;
            _contactRepository = contactRepository;
        }

        public override void InitalizeData(){
           SelectedContact= _contactRepository.GetItem(SelectedContactId);
            base.InitalizeData();
        }


        private void SendSmsOnChoosedPhone()
        {
            _smsSenderService.SendSms(new SmsMessage(){MessageText = ChoosedMessageText,Telephone = _selectedPhone.TelephoneNumber});
        }

        public ContactDto SelectedContact
        {
            get { return _selectedContact; }
            set
            {
                _selectedContact = value;
                base.RaisePropertyChanged(()=>SelectedContact);
            }
        }
    }
}
