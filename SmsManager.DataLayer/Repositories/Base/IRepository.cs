using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmsManager.DataLayer.Entities;

namespace SmsManager.DataLayer.Repositories.Base
{
    public interface IRepository<Detail, Dto>
        where Detail : class,IDetail, new()
        where Dto : IDto, new()
    {
        IEnumerable<Dto> GetAll();
        Dto GetItem(long id);
        void InsertOrUpdateRange(IEnumerable<Dto> items);
        void InsertOrUpdate(Dto dto);
        void Insert(Dto dto);
        IEnumerable<Dto> Search(string pattern);
        void Delete(Dto dto);
        Detail UpdateEntry(Dto sourceDto, Detail targetEntity);
        Detail CreateEntry(Dto dto);

    }
}
