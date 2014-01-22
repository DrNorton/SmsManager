using System.Collections.Generic;
using SmsManager.Infrastructure.Entities;
using SmsManager.Infrastructure.Entities.Dto;

namespace SmsManager.Infrastructure.IRepositories
{
    public interface ICategoryRepository
    {
        IEnumerable<ICategoryDto> Search(string pattern);
        ICategoryDetail UpdateEntry(ICategoryDto sourceDto, ICategoryDetail targetEntity);
        ICategoryDetail CreateEntry(ICategoryDto dto);
        ICategoryDto Convert(ICategoryDetail entity);
        IEnumerable<ICategoryDto> GetAll();
        ICategoryDto GetItem(long id);
        void InsertOrUpdateRange(IEnumerable<ICategoryDto> items);
        void InsertOrUpdate(ICategoryDto dto);
        void Delete(ICategoryDto dto);
        void Insert(ICategoryDto dto);

    }
}
