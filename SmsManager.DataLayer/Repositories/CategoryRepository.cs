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
    public class CategoryRepository: BaseRepository<ICategoryDetail, ICategoryDto>, ICategoryRepository
    {
        
        public CategoryRepository(ISmsDataContext store)
            :base(store)
        {
            
        }

        public override IEnumerable<ICategoryDto> Search(string pattern)
        {
            throw new NotImplementedException();
        }

        public override ICategoryDetail UpdateEntry(ICategoryDto sourceDto, ICategoryDetail targetEntity)
        {
            targetEntity.Id = sourceDto.Id;
            targetEntity.Image = sourceDto.Image;
            targetEntity.Name = sourceDto.Name;
            return targetEntity;
        }

        public override ICategoryDetail CreateEntry(ICategoryDto dto)
        {
            return new Category(){Id=dto.Id,Image = dto.Image,Name=dto.Name};
        }

        public override ICategoryDto Convert(ICategoryDetail entity)
        {
            return new CategoryDto(){Id=entity.Id,Image = entity.Image,Name = entity.Name};
        }
    }
}
