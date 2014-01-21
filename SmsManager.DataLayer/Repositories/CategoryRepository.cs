using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using SmsManager.DataLayer.Entities;
using SmsManager.DataLayer.Repositories.Base;

namespace SmsManager.DataLayer.Repositories
{
    public class CategoryRepository : BaseRepository<Category, CategoryDto>
    {
        public CategoryRepository(DataContext store)
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

        protected override CategoryDto Convert(Category entity)
        {
            return new CategoryDto(){Id=entity.Id,Image = entity.Image,Name = entity.Name};
        }
    }
}
