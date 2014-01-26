using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Phone.UserData;
using SmsManager.Services.Models;

namespace SmsManager.Services
{
    public class ContactService : IContactService
    {
        public delegate void ContactServiceEventHandler(object o, ContactServiceEventArgs e);
        public event ContactServiceEventHandler OnGetComplete;
        private IEnumerable<ContactDto> _contacts;

        public void GetAllContactsAsync()
        {
            if (_contacts == null)
            {
                var objContacts = new Contacts();
                objContacts.SearchCompleted += objContacts_SearchCompleted;
                objContacts.SearchAsync(string.Empty, FilterKind.None, null);
            }
            else
            {
                OnGetComplete(this, new ContactServiceEventArgs(_contacts));
            }
        }

        void objContacts_SearchCompleted(object sender, ContactsSearchEventArgs e)
        {
            if (OnGetComplete != null)
            {

                OnGetComplete(this, new ContactServiceEventArgs(ConvertContactToDto(e.Results)));
            }
        }

        private IEnumerable<ContactDto> ConvertContactToDto(IEnumerable<Contact> contacts )
        {
            foreach (var contact in contacts)
            {
                yield return ConvertContactToDto(contact);
            }
        }

        private ContactDto ConvertContactToDto(Contact contact)
        {
            return new ContactDto(){DisplayName = contact.DisplayName,Telephones = contact.PhoneNumbers.Select(x=>new TelephoneDto{TelephoneNumber = x.PhoneNumber,Kind = x.Kind.ToString()})};
        }
    }

    public class ContactServiceEventArgs:EventArgs
    {
        private readonly IEnumerable<ContactDto> _resultContacts;

        public ContactServiceEventArgs(IEnumerable<ContactDto> result)
        {
            _resultContacts = result;
        }

        public IEnumerable<ContactDto> ResultContacts
        {
            get { return _resultContacts; }
        }
    }
}
