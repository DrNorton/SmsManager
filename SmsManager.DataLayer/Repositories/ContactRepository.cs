using System;
using System.Data.Linq;
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
    public class ContactRepository : BaseRepository<Contact, ContactDto>, IContactRepository
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

        public override Contact UpdateEntry(ContactDto sourceDto, Contact targetEntity)
        {
            targetEntity.Id = sourceDto.Id;
            targetEntity.Photo = sourceDto.Photo;
            targetEntity.BirthdayDate = sourceDto.BirthdayDate;
            targetEntity.DisplayName = sourceDto.DisplayName;
            targetEntity.EmailAddress= sourceDto.EmailAddress;
            foreach (var oldTelephone in targetEntity.Telephones)
            {
                _store.Telephones.DeleteOnSubmit(oldTelephone);
            }
            foreach (var telephone in sourceDto.Telephones)
            {
                var convertedTelephone=ConvertTelephoneDtoToEntity(targetEntity, telephone);
                targetEntity.Telephones.Add(convertedTelephone);
            }

            return targetEntity;
        }

        private static Telephone ConvertTelephoneDtoToEntity(Contact targetEntity, TelephoneDto telephone)
        {
                return new Telephone() {Id=telephone.Id,KindId = telephone.TelephoneKind.Id, TelephoneNumber = telephone.TelephoneNumber,ContactId =telephone.ContactId };
        }

        public override Contact CreateEntry(ContactDto dto)
        {
            return dto.ToEntityContact();
        }

        public override ContactDto Convert(Contact entity)
        {
            return new ContactDto(entity);
        }


       
    }
}
