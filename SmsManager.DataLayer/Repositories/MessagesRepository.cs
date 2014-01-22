using System;
using System.Collections.Generic;
using SmsManager.DataLayer.Dto;
using SmsManager.DataLayer.Repositories.Base;
using SmsManager.DataLayer.Entities;
using Phone7.Fx.Ioc;
using SmsManager.Infrastructure.Entities;
using SmsManager.Infrastructure.IRepositories;
using MessageDto = SmsManager.DataLayer.Dto.MessageDto;
using SmsManager.Infrastructure.Entities.Dto;

namespace SmsManager.DataLayer.Repositories
{
    public class MessagesRepository:BaseRepository<IMessageDetail,IMessageDto>, IMessagesRepository
    {
        [Injection]
        public MessagesRepository(ISmsDataContext store)
            :base(store)
        {
            
        }

        public override IMessageDetail UpdateEntry(IMessageDto sourceDto, IMessageDetail targetEntity)
        {
            targetEntity.Id = sourceDto.Id;
            targetEntity.Text = sourceDto.Text;
            targetEntity.Usages = sourceDto.Usages;
            return targetEntity;
        }

        public override IMessageDetail CreateEntry(IMessageDto dto)
        {
            return new Message() { CategoryId = dto.CategoryId, Id = dto.Id, Text = dto.Text, Usages = dto.Usages };
        }

        public override IMessageDto Convert(IMessageDetail entity)
        {
            return new MessageDto() { CategoryId = entity.Id, Id = entity.Id, Text = entity.Text, Usages = entity.Usages };
        }

        public override IEnumerable<IMessageDto> Search(string pattern)
        {
            throw new NotImplementedException();
        }
    }
}
