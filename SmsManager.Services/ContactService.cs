using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Imaging;
using Microsoft.Phone.UserData;
using SmsManager.Services.Base;
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

        private ContactDto ConvertContactToDto(Contact contact){
            var photo = GetPicture(contact);
            var dto= new ContactDto(){DisplayName = contact.DisplayName,
                Telephones = ConvertPhoneNumbers(contact.PhoneNumbers).ToList(),
                Photo = photo};
            return dto;
        }

        private BitmapImage GetPicture(Contact contact)
        {
            BitmapImage img = new BitmapImage();
            var imageStream = contact.GetPicture();
            if (imageStream == null) return null;
            img.SetSource(imageStream);
            return img;
        }

        private IEnumerable<TelephoneDto> ConvertPhoneNumbers(IEnumerable<ContactPhoneNumber> telephoneNumbers){
            foreach (var contactPhoneNumber in telephoneNumbers){
                yield return new TelephoneDto(){TelephoneNumber = contactPhoneNumber.PhoneNumber,Kind = contactPhoneNumber.Kind.ToString()};
            }
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
