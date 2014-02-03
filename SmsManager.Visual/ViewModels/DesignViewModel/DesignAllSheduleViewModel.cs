using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Phone7.Fx.Mvvm;
using SmsManager.DataLayer.Dto;
using SmsManager.DataLayer.Repositories;
using SmsManager.Visual.ViewModels.Shedule;

namespace SmsManager.Visual.ViewModels.DesignViewModel
{
    public class DesignAllSheduleViewModel:AllSheduleViewModel
    {
        public DesignAllSheduleViewModel()
            :base(new SmsSheduleRepository(null),null)
        {
            base.Shedules = new List<SmsSheduleDto>();
            var contactDto = new ContactDto();
            contactDto.BirthdayDate = DateTime.Now;
            contactDto.DisplayName = "Привет";
            contactDto.EmailAddress = "dimaivanov1@mail.ru";
            contactDto.Id = 1;
            contactDto.Telephones = new List<TelephoneDto>();
            var periodic = new PeriodicDto()
            {
                Days = 0,
                Hours = 0,
                Id = 1,
                Minutes = 1,
                Name = "Раз в минуту",
                Seconds = 0
            };

            base.Shedules.Add(new SmsSheduleDto() { Contact = contactDto, Id = 1, LastExecuted = DateTime.Now, Name = "Отправка сообщения", Periodic = periodic });
            base.Shedules.Add(new SmsSheduleDto() { Contact = contactDto, Id = 1, LastExecuted = DateTime.Now, Name = "Отправка сообщения", Periodic = periodic });
            base.Shedules.Add(new SmsSheduleDto() { Contact = contactDto, Id = 1, LastExecuted = DateTime.Now, Name = "Отправка сообщения", Periodic = periodic });
           
        }



        public override void InitalizeData()
        {
        
        }
    }
}
