using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Phone7.Fx.Mvvm;
using ScaryStories.ViewModel.Extensions;
using SmsManager.DataLayer.Dto;
using SmsManager.Services.Models;
using SmsManager.Visual.ViewModels.Contracts;

namespace SmsManager.Visual.ViewModels.DesignViewModel
{
    public class DesignContactChooseViewModel:ViewModelBase,IContactChooseViewModel
    {
        private List<AlphaKeyGroup<ContactDto>> _contacts;

        public DesignContactChooseViewModel()
        {
            _contacts=new List<AlphaKeyGroup<ContactDto>>();
            var anotherContacts = new List<ContactDto>();
            
        }

        public List<AlphaKeyGroup<ContactDto>> Contacts
        {
            get{
                return _contacts;
            }
            set
            {
                _contacts = value;
            }
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
