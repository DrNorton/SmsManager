using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.UserData;
using Phone7.Fx.Ioc;
using SmsManager.DataLayer.Dto;
using SmsManager.DataLayer.Entities;
using SmsManager.DataLayer.Repositories.Base;
using System.IO;
using SmsManager.Services.Base;
using Contact = Microsoft.Phone.UserData.Contact;

namespace SmsManager.Services
{
    public class ContactSyncService :  IContactSyncService
    {
        private readonly IContactRepository _contactRepository;
        private readonly ICelebritySyncService _celebritySyncService;

        public delegate void SyncContactServiceEventHandler(object o, SyncContactServiceEventArgs e);
        public event SyncContactServiceEventHandler OnSyncComplete;

        [Injection]
        public ContactSyncService(IContactRepository contactRepository,ICelebritySyncService celebritySyncService)
        {
            _contactRepository = contactRepository;
            _celebritySyncService = celebritySyncService;
        }

        public void StartSyncronizationAsync()
        {
            var objContacts = new Contacts();
            objContacts.SearchCompleted += new EventHandler<ContactsSearchEventArgs>(OnSearchCompleted);
            objContacts.SearchAsync(string.Empty, FilterKind.None, null);
        }

        private void OnSearchCompleted(object sender, ContactsSearchEventArgs e){
            StartSync(e);
        }

        private void StartSync(ContactsSearchEventArgs e){
            var findedContacts = e.Results;
            var contactsInDatabase = _contactRepository.GetAll().ToList();
            foreach (var findedContact in findedContacts){
                InsertNewContactOrUpdateExisting(contactsInDatabase, findedContact);
            }
            //Чекнем может аккаунт удалили
            DeleteContactFromDatabaseIfUserDeleteItFromBook(contactsInDatabase, findedContacts);
            var allContacts = _contactRepository.GetAll().ToList();
            var notifications = SyncAndGetNotifications(allContacts);
            //Отдаём в результате все контакты из базы
            SignalCompleteAndReturnAllContacts(allContacts,notifications);
          
        }

        #region PrivateMethods

        private IEnumerable<CelebrityNotificationDto> SyncAndGetNotifications(IEnumerable<ContactDto> allContacts)
        {
            var notifications = _celebritySyncService.StartSync(allContacts);
            return notifications;
        }

        private void SignalCompleteAndReturnAllContacts(IEnumerable<ContactDto> contacts,IEnumerable<CelebrityNotificationDto> notifications)
        {
            if (OnSyncComplete != null)
            {
                OnSyncComplete(this, new SyncContactServiceEventArgs(contacts,notifications));
            }
        }

        private void DeleteContactFromDatabaseIfUserDeleteItFromBook(List<ContactDto> contactsInDatabase, IEnumerable<Contact> findedContacts){
            foreach (var contactDto in contactsInDatabase){
                var isExist = findedContacts.Any(x => x.DisplayName == contactDto.DisplayName);
                if (!isExist){
                    _contactRepository.Delete(contactDto);
                }
            }
        }

        private void InsertNewContactOrUpdateExisting(IEnumerable<ContactDto> contactsInDatabase, Contact findedContact){
            var contactInDatabase = contactsInDatabase.FirstOrDefault(x => x.DisplayName == findedContact.DisplayName);
            if (contactInDatabase == null){
                //Не найдено в базе, знач контакт новый
                InsertNewContactIntoDatabase(findedContact);
            }
            else{
                //Обновляем контакт
                UpdateContactFromDatabase(findedContact, contactInDatabase);
            }

         
        }

        private void UpdateContactFromDatabase(Contact findedContact, ContactDto contactInDatabase){
            var dto=PrepareContactDto(findedContact);
            dto.Id = contactInDatabase.Id;
            SetTelephoneContactId(dto,contactInDatabase.Id);
            _contactRepository.InsertOrUpdate(dto);
        }

        private void SetTelephoneContactId(ContactDto newContact,long contactId)
        {
            foreach (var telephone in newContact.Telephones)
            {
                telephone.ContactId = contactId;
            }
        }
        private void InsertNewContactIntoDatabase(Contact findedContact){
            var newContactDto = PrepareContactDto(findedContact);
            _contactRepository.Insert(newContactDto);
        }

        private ContactDto PrepareContactDto(Contact findedContact)
        {
            var birthDay = findedContact.Birthdays.FirstOrDefault();
            var newContactDto = new ContactDto(){
                BirthdayDate = (birthDay==new DateTime())?null:(DateTime?)birthDay,
                DisplayName = findedContact.DisplayName,
                Photo = ReadBytePicture(findedContact.GetPicture())
            };
            ParseTelephoneNumbers(findedContact, newContactDto);
            return newContactDto;
        }

        private void ParseTelephoneNumbers(Contact findedContact, ContactDto newContactDto){
            foreach (var phoneNumber in findedContact.PhoneNumbers)
            {
                TelephoneDto telephone= new TelephoneDto() { TelephoneNumber = phoneNumber.ToString()};
                TelephoneKindDto kind=null;
                switch (phoneNumber.Kind){
                    case PhoneNumberKind.Mobile:
                        kind = new TelephoneKindDto() { Id = 1, Name = "Мобильный телефон" };
                      break;

                    case PhoneNumberKind.Home:
                        kind = new TelephoneKindDto() { Id = 2, Name = "Домашний телефон" };
                       break;

                    case PhoneNumberKind.Work:
                       kind = new TelephoneKindDto() { Id = 3, Name = "Рабочий телефон" };
                      break;
                }
                if (kind != null)
                {
                    telephone.TelephoneKind = kind;
                    newContactDto.Telephones.Add(telephone);  
                }
                
            }
        }

        private  byte[] ReadBytePicture(Stream input)
        {
            if (input == null)
            {
                return null;
            }
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        #endregion
    }

    public class SyncContactServiceEventArgs:EventArgs
    {
        private readonly IEnumerable<ContactDto> _contacts;
        private readonly IEnumerable<CelebrityNotificationDto> _notifications;

        public SyncContactServiceEventArgs(IEnumerable<ContactDto> contacts,IEnumerable<CelebrityNotificationDto> notifications )
        {
            _contacts = contacts;
            _notifications = notifications;
        }

        public IEnumerable<ContactDto> Contacts
        {
            get { return _contacts; }
        }

        public IEnumerable<CelebrityNotificationDto> Notifications
        {
            get { return _notifications; }
        }
    }
}
