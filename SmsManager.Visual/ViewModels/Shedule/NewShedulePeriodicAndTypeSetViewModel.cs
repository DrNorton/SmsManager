using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Phone7.Fx.Mvvm;
using SmsManager.DataLayer.Dto;
using SmsManager.DataLayer.Repositories.Base;
using SmsManager.Visual.Views.Shedule;

namespace SmsManager.Visual.ViewModels.Shedule
{
    [ViewModel(typeof(NewShedulePeriodicAndTypeSetView))]

    public class NewShedulePeriodicAndTypeSetViewModel:ViewModelBase
    {
        private readonly IContactRepository _contactRepository;
        private ContactDto _selectedContact;
        public string SelectedTelephoneNumber { get; set; }
        public long SelectedContactId { get; set; }

        public ContactDto SelectedContact
        {
            get { return _selectedContact; }
            set
            {
                _selectedContact = value;
                base.RaisePropertyChanged(()=>SelectedContact);
            }
        }


        public NewShedulePeriodicAndTypeSetViewModel(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public override void InitalizeData()
        {
            SelectedContact = _contactRepository.GetItem(SelectedContactId);
            base.InitalizeData();
        }
    }
}
