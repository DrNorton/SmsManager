using System.Collections.Generic;
using SmsManager.DataLayer.Dto;
using SmsManager.DataLayer.Entities;

namespace SmsManager.DataLayer.Repositories.Base
{
    public interface ICelebrityNotificationRepository
    {
        IEnumerable<CelebrityNotificationDto> Search(string pattern);
        CelebrityNotification UpdateEntry(CelebrityNotificationDto sourceDto, CelebrityNotification targetEntity);
        CelebrityNotification CreateEntry(CelebrityNotificationDto dto);
        CelebrityNotificationDto Convert(CelebrityNotification entity);
        event BaseRepository<CelebrityNotification, CelebrityNotificationDto>.ChangeHandler OnChange;
        IEnumerable<CelebrityNotificationDto> GetAll();
        CelebrityNotificationDto GetItem(long id);
        void InsertOrUpdateRange(IEnumerable<CelebrityNotificationDto> items);
        void InsertOrUpdate(CelebrityNotificationDto dto);
        void Delete(CelebrityNotificationDto dto);
        void Insert(CelebrityNotificationDto dto); 
    }
}