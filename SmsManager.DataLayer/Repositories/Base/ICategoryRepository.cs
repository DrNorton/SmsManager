using System.Collections.Generic;
using SmsManager.DataLayer.Dto;
using SmsManager.DataLayer.Entities;
using SmsManager.DataLayer.Repositories.Base;
using SmsManager.Infrastructure.Entities;
using SmsManager.Infrastructure.Entities.Dto;

namespace SmsManager.Infrastructure.IRepositories
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryDto> Search(string pattern);
        Category UpdateEntry(CategoryDto sourceDto, Category targetEntity);
        Category CreateEntry(CategoryDto dto);
        CategoryDto Convert(Category entity);
        event BaseRepository<Category, CategoryDto>.ChangeHandler OnChange;
        IEnumerable<CategoryDto> GetAll();
        CategoryDto GetItem(long id);
        void InsertOrUpdateRange(IEnumerable<CategoryDto> items);
        void InsertOrUpdate(CategoryDto dto);
        void Delete(CategoryDto dto);
        void Insert(CategoryDto dto);

    }
}
