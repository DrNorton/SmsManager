using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmsManager.DataLayer.Entities;
using SmsManager.Infrastructure.Entities.Dto;

namespace SmsManager.DataLayer.Dto
{
    public class CelebrityNotificationDto:IDto
    {
        public long Id { get; set; }
        public bool IsNotify { get; set; }
        public ContactDto Contact { get; set; }
        public MessageDto Message { get; set; }
        public DateTime? CelebrityTime { get; set; }

        public CelebrityNotificationDto()
        {
            
        }

        public CelebrityNotificationDto(CelebrityNotification celebrityNotification)
        {
            Id = celebrityNotification.Id;
            IsNotify = celebrityNotification.IsNotify;
            Contact = new ContactDto(celebrityNotification.Contact);
            if (celebrityNotification.Message != null)
            {
                Message = new MessageDto(celebrityNotification.Message);
            }
            CelebrityTime = celebrityNotification.CelebrityTime;

        }

        public CelebrityNotification ToEntityCelebrityNotification()
        {
            var entity = new CelebrityNotification();
            entity.Id = this.Id;
            entity.IsNotify = this.IsNotify;
            entity.Contact = this.Contact.ToEntityContact();
            if (this.Message != null)
            {
                entity.Message = this.Message.ToEntityMessage();
            }
            entity.CelebrityTime = this.CelebrityTime;
            return entity;
        }
    }
}
