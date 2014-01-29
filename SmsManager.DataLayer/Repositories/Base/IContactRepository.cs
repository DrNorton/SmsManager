using System.Collections.Generic;
using SmsManager.DataLayer.Dto;
using SmsManager.DataLayer.Entities;

namespace SmsManager.DataLayer.Repositories.Base
{
    public interface IContactRepository
    {
        ContactFromBase UpdateEntry(ContactDto sourceDto,ContactFromBase targetEntity);
        ContactFromBase CreateEntry(ContactDto dto);
        ContactDto Convert(ContactFromBase entity);
        IEnumerable<ContactDto> Search(string pattern);
        event BaseRepository<ContactFromBase, ContactDto>.ChangeHandler OnChange;
        IEnumerable<ContactDto> GetAll();
        ContactDto GetItem(long id);
        void InsertOrUpdateRange(IEnumerable<ContactDto> items);
        void InsertOrUpdate(ContactDto dto);
        void Delete(ContactDto dto);
        void Insert(ContactDto dto);
    }
}
