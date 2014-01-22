using System.Collections.Generic;
using SmsManager.DataLayer.Entities;
using SmsManager.Infrastructure.Entities;
using SmsManager.Infrastructure.Entities.Dto;


namespace SmsManager.DataLayer.Repositories.Base
{
    public interface IRepository<Entity,Dto>
    {
        IEnumerable<IDto> GetAll();
        IDto GetItem(long id);
        void InsertOrUpdateRange(IEnumerable<IDto> items);
        void InsertOrUpdate(IDto dto);
        void Insert(IDto dto);
        IEnumerable<IDto> Search(string pattern);
        void Delete(IDto dto);
        IDetail UpdateEntry(IDto sourceDto, IDetail targetEntity);
        IDetail CreateEntry(IDto dto);

    }
}
