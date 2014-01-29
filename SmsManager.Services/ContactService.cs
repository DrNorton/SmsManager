using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Imaging;
using Microsoft.Phone.UserData;
using Phone7.Fx.Ioc;
using SmsManager.DataLayer.Repositories.Base;
using SmsManager.Services.Base;
using SmsManager.Services.Models;

namespace SmsManager.Services
{
    public class ContactService : IContactService
    {
        public delegate void ContactServiceEventHandler(object o, ContactServiceEventArgs e);
        public event ContactServiceEventHandler OnGetComplete;
        private IEnumerable<ContactFromBook> _contacts;
        private IContactRepository _contactRepository;

        [Injection]
        public ContactService(IContactRepository contactRepository){
            _contactRepository = contactRepository;
        }

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

        private void GetContactsFromDataBase(){
            var contacts = _contactRepository.GetAll().ToList();
        }

        public void GetOneContactAsync(string displayName)
        {
            if (_contacts == null)
            {
                var objContacts = new Contacts();
                objContacts.SearchCompleted += objContacts_SearchCompleted;
                objContacts.SearchAsync(string.Empty, FilterKind.None, displayName);
            }
            else
            {
                OnGetComplete(this, new ContactServiceEventArgs(_contacts.Where(x=>x.DisplayName==displayName)));
            }
     
        }

        void objContacts_SearchCompleted(object sender, ContactsSearchEventArgs e)
        {
            if (OnGetComplete != null)
            {
                if (e.State != null)
                {
                    var displayName = (string) e.State;
                    OnGetComplete(this, new ContactServiceEventArgs(_contacts.Where(x => x.DisplayName == displayName)));
                }
                else
                {
                    _contacts = ConvertContactsToDtoes(e.Results);
                    OnGetComplete(this, new ContactServiceEventArgs(_contacts));
                }
            }
        }


        private IEnumerable<ContactFromBook> ConvertContactsToDtoes(IEnumerable<Contact> contacts )
        {
            foreach (var contact in contacts)
            {
                yield return ConvertContactToDto(contact);
            }
        }
        private ContactFromBook ConvertContactToDto(Contact contact){
            var photo = GetPicture(contact);
            var dto= new ContactFromBook(){DisplayName = contact.DisplayName,
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
        private IEnumerable<TelephoneFromBook> ConvertPhoneNumbers(IEnumerable<ContactPhoneNumber> telephoneNumbers){
            foreach (var contactPhoneNumber in telephoneNumbers){
                yield return new TelephoneFromBook(){TelephoneNumber = contactPhoneNumber.PhoneNumber,Kind = contactPhoneNumber.Kind.ToString()};
            }
        }
    }

    public class ContactServiceEventArgs:EventArgs
    {
        private readonly IEnumerable<ContactFromBook> _resultContacts;

        public ContactServiceEventArgs(IEnumerable<ContactFromBook> result)
        {
            _resultContacts = result;
        }

        public IEnumerable<ContactFromBook> ResultContacts
        {
            get { return _resultContacts; }
        }
    }
}
