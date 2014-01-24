using System;
using System.Collections.Generic;
using SmsManager.DataLayer.Entities;
using SmsManager.DataLayer.Repositories.Base;
using Phone7.Fx.Ioc;
using SmsManager.Infrastructure.Entities;
using SmsManager.Infrastructure.Entities.Dto;
using SmsManager.Infrastructure.IRepositories;
using CategoryDto = SmsManager.DataLayer.Dto.CategoryDto;

namespace SmsManager.DataLayer.Repositories
{
 
    public class CategoryRepository: BaseRepository<Category, CategoryDto>, ICategoryRepository
    {
        [Injection]
        public CategoryRepository(ISmsDataContext store)
            :base(store)
        {
            
        }

        public override IEnumerable<CategoryDto> Search(string pattern)
        {
            throw new NotImplementedException();
        }

        public override Category UpdateEntry(CategoryDto sourceDto, Category targetEntity)
        {
            targetEntity.Id = sourceDto.Id;
            targetEntity.Image = sourceDto.Image;
            targetEntity.Name = sourceDto.Name;
            return targetEntity;
        }

        public override Category CreateEntry(CategoryDto dto)
        {
            return new Category(){Id=dto.Id,Image = dto.Image,Name=dto.Name};
        }

        public override CategoryDto Convert(Category entity)
        {
            return new CategoryDto(){Id=entity.Id,Image = entity.Image,Name = entity.Name};
        }
    }
}
