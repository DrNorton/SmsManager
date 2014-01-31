using System.Collections.Generic;
using SmsManager.DataLayer.Dto;
using SmsManager.DataLayer.Entities;

namespace SmsManager.DataLayer.Repositories.Base
{
    public interface IContactRepository 
    {
        event BaseRepository<Contact, ContactDto>.ChangeHandler OnChange;
        Contact UpdateEntry(ContactDto sourceDto, Contact targetEntity);
        Contact CreateEntry(ContactDto dto);
        ContactDto Convert(Contact entity);
        IEnumerable<ContactDto> Search(string pattern);
        IEnumerable<ContactDto> GetAll();
        ContactDto GetItem(long id);
        void InsertOrUpdateRange(IEnumerable<ContactDto> items);
        void InsertOrUpdate(ContactDto dto);
        void Delete(ContactDto dto);
        void Insert(ContactDto dto);
    }
}
