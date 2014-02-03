using System.Collections.Generic;
using SmsManager.DataLayer.Dto;
using SmsManager.DataLayer.Entities;

namespace SmsManager.DataLayer.Repositories.Base
{
    public interface ISmsSheduleRepository
    {
        IEnumerable<SmsSheduleDto> Search(string pattern);
        SmsShedule UpdateEntry(SmsSheduleDto sourceDto, SmsShedule targetEntity);
        SmsShedule CreateEntry(SmsSheduleDto dto);
        SmsSheduleDto Convert(SmsShedule entity);
        event BaseRepository<SmsShedule, SmsSheduleDto>.ChangeHandler OnChange;
        IEnumerable<SmsSheduleDto> GetAll();
        SmsSheduleDto GetItem(long id);
        void InsertOrUpdateRange(IEnumerable<SmsSheduleDto> items);
        void InsertOrUpdate(SmsSheduleDto dto);
        void Delete(SmsSheduleDto dto);
        void Insert(SmsSheduleDto dto);
    }
}