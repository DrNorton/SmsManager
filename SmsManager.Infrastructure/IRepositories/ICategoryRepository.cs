using SmsManager.Infrastructure.Entities;
using SmsManager.Infrastructure.Entities.Dto;

namespace SmsManager.Infrastructure.IRepositories
{
    public interface ICategoryRepository
    {
        //IEnumerable<CategoryDto> Search(string pattern);
        //ICategoryDetail UpdateEntry(CategoryDto sourceDto, ICategoryDetail targetEntity);
        //ICategoryDetail CreateEntry(CategoryDto dto);
        IDto Convert(ICategoryDetail entity);
        
        //IEnumerable<CategoryDto> GetAll();
        //CategoryDto GetItem(long id);
        //void InsertOrUpdateRange(IEnumerable<CategoryDto> items);
        //void InsertOrUpdate(CategoryDto dto);
        //void Delete(CategoryDto dto);
        //void Insert(CategoryDto dto);

    }
}
