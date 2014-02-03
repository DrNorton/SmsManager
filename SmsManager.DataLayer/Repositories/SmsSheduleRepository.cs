using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using Phone7.Fx.Ioc;
using SmsManager.DataLayer.Dto;
using SmsManager.DataLayer.Entities;
using SmsManager.DataLayer.Repositories.Base;

namespace SmsManager.DataLayer.Repositories
{
    public class SmsSheduleRepository: BaseRepository<SmsShedule, SmsSheduleDto>,ISmsSheduleRepository
    {
        [Injection]
        public SmsSheduleRepository(ISmsDataContext context)
            :base(context)
        {
            
        }

        public override IEnumerable<SmsSheduleDto> Search(string pattern)
        {
            throw new NotImplementedException();
        }

        public override SmsShedule UpdateEntry(SmsSheduleDto sourceDto, SmsShedule targetEntity)
        {
            targetEntity.Id = sourceDto.Id;
            targetEntity.ContactId = sourceDto.ContactId;
            targetEntity.LastExecuted= sourceDto.LastExecuted;
            targetEntity.Name= sourceDto.Name;
            var periodic = sourceDto.Periodic;
            targetEntity.Periodic = new Periodic(){Days = periodic.Days,Hours = periodic.Hours,Id=periodic.Id,Minutes = periodic.Minutes,Name = periodic.Name,Seconds = periodic.Seconds};
            return targetEntity;
        }

        public override SmsShedule CreateEntry(SmsSheduleDto dto)
        {
            throw new NotImplementedException();
        }

        public override SmsSheduleDto Convert(SmsShedule entity)
        {
            return new SmsSheduleDto(entity);
        }
    }

   
}
