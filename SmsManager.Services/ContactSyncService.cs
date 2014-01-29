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
using SmsManager.DataLayer.Repositories.Base;

namespace SmsManager.Services
{
    public class ContactSyncService
    {
        private readonly IContactRepository _contactRepository;

        [Injection]
        public ContactSyncService(IContactRepository contactRepository){
            _contactRepository = contactRepository;
        }

        public void Sync(){
            
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
            _contactRepository.InsertOrUpdate(dto);
        }

        private void InsertNewContactIntoDatabase(Contact findedContact){
            var newContactDto = PrepareContactDto(findedContact);
            _contactRepository.Insert(newContactDto);
        }

        private ContactDto PrepareContactDto(Contact findedContact){
            var newContactDto = new ContactDto(){
                BirthdayDate = findedContact.Birthdays.FirstOrDefault(),
                DisplayName = findedContact.DisplayName
            };
            ParseTelephoneNumbers(findedContact, newContactDto);
            return newContactDto;
        }

        private void ParseTelephoneNumbers(Contact findedContact, ContactDto newContactDto){
            foreach (var phoneNumber in findedContact.PhoneNumbers){
                switch (phoneNumber.Kind){
                    case PhoneNumberKind.Mobile:
                        newContactDto.MobileTelephone = phoneNumber.ToString();
                        break;

                    case PhoneNumberKind.Home:
                        newContactDto.HomeTelephone = phoneNumber.ToString();
                        break;

                    case PhoneNumberKind.Work:
                        newContactDto.WorkTelephone = phoneNumber.ToString();
                        break;
                }
            }
        }
    }
}
