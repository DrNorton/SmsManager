using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Phone7.Fx.Ioc;
using SmsManager.DataLayer.Dto;
using SmsManager.DataLayer.Entities;
using SmsManager.DataLayer.Repositories.Base;

namespace SmsManager.DataLayer.Repositories
{
    public class ContactRepository : BaseRepository<ContactFromBase, ContactDto>, IContactRepository
    {
        [Injection]
        public ContactRepository(ISmsDataContext store)
            :base(store)
        {
            
        }

        public override System.Collections.Generic.IEnumerable<ContactDto> Search(string pattern)
        {
            throw new NotImplementedException();
        }

        public override ContactFromBase UpdateEntry(ContactDto sourceDto, ContactFromBase targetEntity)
        {
            targetEntity.Id = sourceDto.Id;
            targetEntity.Photo = sourceDto.Photo;
            targetEntity.BirthdayDate = sourceDto.BirthdayDate;
            targetEntity.DisplayName = sourceDto.DisplayName;
            targetEntity.EmailAddress= sourceDto.EmailAddress;
            targetEntity.HomeTelephone = sourceDto.HomeTelephone;
            targetEntity.MobileTelephone = sourceDto.MobileTelephone;
            targetEntity.WorkTelephone = sourceDto.WorkTelephone;
            return targetEntity;
        }

        public override ContactFromBase CreateEntry(ContactDto dto)
        {
            return new ContactFromBase(){BirthdayDate = dto.BirthdayDate,DisplayName = dto.DisplayName,EmailAddress = dto.EmailAddress,Id=dto.Id,Photo = dto.Photo,HomeTelephone = dto.HomeTelephone,MobileTelephone = dto.MobileTelephone,WorkTelephone = dto.WorkTelephone};
        }

        public override ContactDto Convert(ContactFromBase entity)
        {
            return new ContactDto(){
                BirthdayDate = entity.BirthdayDate, DisplayName = entity.DisplayName, EmailAddress = entity.EmailAddress, Id = entity.Id, Photo = entity.Photo,
                HomeTelephone = entity.HomeTelephone,MobileTelephone = entity.MobileTelephone,WorkTelephone = entity.WorkTelephone
            };
        }


       
    }
}
