using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Phone7.Fx.Ioc;
using Phone7.Fx.Mvvm;
using Phone7.Fx.Navigation;
using ScaryStories.ViewModel.Extensions;
using SmsManager.DataLayer.Dto;
using SmsManager.DataLayer.Repositories.Base;
using SmsManager.Services.Base;

namespace SmsManager.Visual.ViewModels.Base
{
    public abstract class BaseContactChooseViewModel:ViewModelBase
    {
        private List<AlphaKeyGroup<ContactDto>> _contacts;
        private ContactDto _selectedContact;

        private readonly IContactRepository _contactRepository;
        protected readonly INavigationService _navigationService;
        private readonly ISmsSenderService _smsSenderService;
   
        public BaseContactChooseViewModel(IContactRepository contactRepository, INavigationService navigationService)
        {
            _contactRepository = contactRepository;
            _navigationService = navigationService;
        }


        private List<AlphaKeyGroup<ContactDto>> ConvertToGroupedList(IEnumerable<ContactDto> contacts)
        {
           var  alphaContact = AlphaKeyGroup<ContactDto>.CreateGroups(
           contacts,
           CultureInfo.CurrentCulture,
           (ContactDto s) => { return s.DisplayName.ElementAt(0).ToString().ToLower(); }, true);
            return alphaContact;
        }

        public override void InitalizeData(){
           var contacts=_contactRepository.GetAll().ToList();
            Contacts=ConvertToGroupedList(contacts);
            base.InitalizeData();
        }

        public List<AlphaKeyGroup<ContactDto>> Contacts
        {
            get { return _contacts; }
            set
            {
                _contacts = value;
                base.RaisePropertyChanged(() => Contacts);
            }
        }

        public ContactDto SelectedContact
        {
            get { return _selectedContact; }
            set
            {
                _selectedContact = value;
                if (value != null)
                {
                    OnContactSelected();
                }
                base.RaisePropertyChanged(()=>SelectedContact);
            }
        }


        protected abstract void OnContactSelected();

    }
}
