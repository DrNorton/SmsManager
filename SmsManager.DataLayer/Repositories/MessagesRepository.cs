using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using SmsManager.DataLayer.Repositories.Base;
using SmsManager.DataLayer.Entities;

namespace SmsManager.DataLayer.Repositories
{
    public class MessagesRepository:BaseRepository<Message,MessageDto>
    {
        public MessagesRepository(DataContext store)
            :base(store)
        {
            
        }

        public override IEnumerable<MessageDto> Search(string pattern)
        {
            throw new NotImplementedException();
        }

        public override Message UpdateEntry(MessageDto sourceDto, Message targetEntity)
        {
            targetEntity.Id = sourceDto.Id;
            targetEntity.Text = sourceDto.Text;
            targetEntity.Usages = sourceDto.Usages;
            return targetEntity;
        }

        public override Message CreateEntry(MessageDto dto)
        {
            return new Message(){CategoryId = dto.CategoryId,Id=dto.Id,Text=dto.Text,Usages = dto.Usages};
        }

        protected override MessageDto Convert(Message entity)
        {
           return new MessageDto(){CategoryId = entity.Id,Id=entity.Id,Text=entity.Text,Usages = entity.Usages};
        }
    }
}
