using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Phone7.Fx.Mvvm;
using ScaryStories.ViewModel.Extensions;
using SmsManager.Services.Models;
using SmsManager.Visual.ViewModels.Contracts;

namespace SmsManager.Visual.ViewModels.DesignViewModel
{
    public class DesignContactChooseViewModel:ViewModelBase,IContactChooseViewModel
    {
        private List<AlphaKeyGroup<Services.Models.ContactDto>> _contacts;

        public List<ScaryStories.ViewModel.Extensions.AlphaKeyGroup<Services.Models.ContactDto>> Contacts
        {
            get
            {
                return _contacts;
            }
            set
            {
                _contacts = value;
                base.RaisePropertyChanged(()=>Contacts);
            }
        }

        public DesignContactChooseViewModel()
        {
            var contactList = new List<ContactDto>();
            contactList.Add(new ContactDto(){DisplayName = "Первый"});
            contactList.Add(new ContactDto() { DisplayName = "Второй" });
            contactList.Add(new ContactDto() { DisplayName = "Третий" });
            contactList.Add(new ContactDto() { DisplayName = "Четвертый" });
            Contacts=ConvertToGroupedList(contactList);
        }

        private List<AlphaKeyGroup<ContactDto>> ConvertToGroupedList(IEnumerable<ContactDto> contacts)
        {
            var alphaContact = AlphaKeyGroup<ContactDto>.CreateGroups(
            contacts,
            CultureInfo.CurrentCulture,
            (ContactDto s) => { return s.DisplayName.ElementAt(0).ToString().ToLower(); }, true);
            return alphaContact;
        }
    }
}
