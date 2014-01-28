using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Phone7.Fx.Ioc;
using Phone7.Fx.Mvvm;
using Phone7.Fx.Navigation;
using SmsManager.Services.Base;
using SmsManager.Services.Models;
using SmsManager.Visual.ViewModels.Contracts;
using SmsManager.Visual.Views;

namespace SmsManager.Visual.ViewModels
{
    [ViewModel(typeof(TelephoneKindChooseView))]
    public class TelephoneKindChooseViewModel : ViewModelBase, ITelephoneKindChooseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly ISmsSenderService _smsSenderService;
        private readonly IContactService _contactService;

        public string ChoosedMessageText { get; set; }
        public string SelectedContactName { get; set; }
        private ContactDto _selectedContact;
        private TelephoneDto _selectedPhone;

        [Injection]
        public TelephoneKindChooseViewModel(INavigationService navigationService, ISmsSenderService smsSenderService,IContactService contactService)
        {
            _navigationService = navigationService;
            _smsSenderService = smsSenderService;
            _contactService = contactService;
            _contactService.OnGetComplete += _contactService_OnGetComplete;
          
        }

        void _contactService_OnGetComplete(object o, Services.ContactServiceEventArgs e)
        {
            var contacts = e.ResultContacts as IEnumerable<ContactDto>;
            SelectedContact = contacts.First();

        }

        public override void InitalizeData()
        {
            _contactService.GetOneContactAsync(SelectedContactName);   
        }

        public IEnumerable<TelephoneDto> Telephones
        {
            get
            {
                if (SelectedContact != null)
                {
                    return SelectedContact.Telephones;
                }
                return null;
            }
        }

        public TelephoneDto SelectedPhone
        {
            get { return _selectedPhone; }
            set
            {
                _selectedPhone = value;
                SendSmsOnChoosedPhone();
                base.RaisePropertyChanged(() => SelectedPhone);
            }
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
