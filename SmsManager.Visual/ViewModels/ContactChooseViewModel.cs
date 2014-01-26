using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Threading;
using Phone7.Fx.Ioc;
using Phone7.Fx.Mvvm;
using ScaryStories.ViewModel.Extensions;
using SmsManager.DataLayer.Dto;
using SmsManager.Services;
using SmsManager.Services.Models;
using SmsManager.Visual.ViewModels.Contracts;
using SmsManager.Visual.Views;

namespace SmsManager.Visual.ViewModels
{
    [ViewModel(typeof(ContactChooseView))]
    public class ContactChooseViewModel:ViewModelBase, IContactChooseViewModel
    {
        public MessageDto _currentSmsMessage { get; set; }

        private List<AlphaKeyGroup<ContactDto>> _contacts;
        private ContactDto _selectedContact;
        private IContactService _contactService;

        [Injection]
        public ContactChooseViewModel(IContactService contactService)
        {
            _contactService = contactService;
            _contactService.OnGetComplete += _contactService_OnGetComplete;
        }


        void _contactService_OnGetComplete(object o, ContactServiceEventArgs e)
        {
           Contacts = ConvertToGroupedList(e.ResultContacts);
        }

        private List<AlphaKeyGroup<ContactDto>> ConvertToGroupedList(IEnumerable<ContactDto> contacts)
        {
           var  alphaContact = AlphaKeyGroup<ContactDto>.CreateGroups(
           contacts,
           CultureInfo.CurrentCulture,
           (ContactDto s) => { return s.DisplayName.ElementAt(0).ToString().ToLower(); }, true);
            return alphaContact;
        }

        public override void InitalizeData()
        {
           _contactService.GetAllContactsAsync(); 
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
                base.RaisePropertyChanged(()=>SelectedContact);
            }
        }
    }
}
