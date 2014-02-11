using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Phone7.Fx.Ioc;
using Phone7.Fx.Mvvm;
using Phone7.Fx.Navigation;
using SmsManager.DataLayer.Dto;
using SmsManager.DataLayer.Repositories.Base;
using SmsManager.Services.Base;
using SmsManager.Visual.Views;

namespace SmsManager.Visual.ViewModels.Base
{
    
    public abstract class BaseTelephoneKindChooseViewModel:ViewModelBase
    {
        protected readonly INavigationService _navigationService;
        private readonly ISmsSenderService _smsSenderService;
        private readonly IContactRepository _contactRepository;

        public long SelectedContactId { get; set; }

        private ContactDto _selectedContact;
        private TelephoneDto _selectedPhone;

  
        public BaseTelephoneKindChooseViewModel(INavigationService navigationService, IContactRepository contactRepository)
        {
            _navigationService = navigationService;
            _contactRepository = contactRepository;
        }


        public override void InitalizeData()
        {
            if (SelectedContactId != 0){
                SelectedContact = _contactRepository.GetItem(SelectedContactId);
            }
            base.InitalizeData();
        }

        public ContactDto SelectedContact
        {
            get { return _selectedContact; }
            set
            {
                _selectedContact = value;
                base.RaisePropertyChanged(() => SelectedContact);
            }
        }

        public TelephoneDto SelectedPhone
        {
            get { return _selectedPhone; }
            set
            {
                _selectedPhone = value;
                if (value != null)
                {
                   OnSelectedPhoneAction();
                }
                base.RaisePropertyChanged(() => SelectedPhone);
            }
        }

        protected abstract void OnSelectedPhoneAction();
    }
}
