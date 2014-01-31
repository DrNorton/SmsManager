using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Phone7.Fx.Ioc;
using SmsManager.DataLayer.Dto;
using SmsManager.DataLayer.Entities;
using SmsManager.DataLayer.Repositories.Base;

namespace SmsManager.DataLayer.Repositories
{
    public class CelebrityNotificationRepository : BaseRepository<CelebrityNotification, CelebrityNotificationDto>, ICelebrityNotificationRepository
    {

        [Injection]
        public CelebrityNotificationRepository(ISmsDataContext dataContext)
            :base(dataContext)
        {
            
        }

        public override IEnumerable<CelebrityNotificationDto> Search(string pattern)
        {
            throw new NotImplementedException();
        }

        public override CelebrityNotification UpdateEntry(CelebrityNotificationDto sourceDto, CelebrityNotification targetEntity)
        {
            targetEntity.Id = sourceDto.Id;
            targetEntity.IsNotify = sourceDto.IsNotify;
            targetEntity.Message = sourceDto.Message.ToEntityMessage();
            targetEntity.Contact = sourceDto.Contact.ToEntityContact();
            return targetEntity;
        }

        public override CelebrityNotification CreateEntry(CelebrityNotificationDto dto)
        {
            return dto.ToEntityCelebrityNotification();
        }

        public override CelebrityNotificationDto Convert(CelebrityNotification entity)
        {
            return new CelebrityNotificationDto(entity);
        }
    }
}
