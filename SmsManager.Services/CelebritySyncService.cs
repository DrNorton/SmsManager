using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Phone.UserData;
using Phone7.Fx.Ioc;
using SmsManager.DataLayer.Dto;
using SmsManager.DataLayer.Repositories.Base;
using SmsManager.Services.Base;

namespace SmsManager.Services
{
    public class CelebritySyncService : ICelebritySyncService
    {
        private readonly ICelebrityNotificationRepository _celebrityNotificationRepository;

        [Injection]
        public CelebritySyncService(ICelebrityNotificationRepository celebrityNotificationRepository)
        {
            _celebrityNotificationRepository = celebrityNotificationRepository;
        }

        public IEnumerable<CelebrityNotificationDto> StartSync(IEnumerable<ContactDto> contacts )
        {
            var celebrityNotifications = _celebrityNotificationRepository.GetAll().ToList();
            foreach (var contactDto in contacts)
            {
                var findedCelebrity=celebrityNotifications.FirstOrDefault(x => x.Contact.Id == contactDto.Id);
                if (findedCelebrity == null)
                {
                    InsertNewCelebrityNotification(contactDto);
                }
                else
                {
                    UpdateBirthdayDateIfNeeded(contactDto,findedCelebrity);
                }
            }
            return _celebrityNotificationRepository.GetAll().ToList();
        }

        private void UpdateBirthdayDateIfNeeded(ContactDto contactDto, CelebrityNotificationDto findedCelebrity)
        {
            if (contactDto.BirthdayDate != findedCelebrity.CelebrityTime)
            {
                findedCelebrity.CelebrityTime = contactDto.BirthdayDate;
                _celebrityNotificationRepository.InsertOrUpdate(findedCelebrity);
            }
        }

        private void InsertNewCelebrityNotification(ContactDto contactDto)
        {
            _celebrityNotificationRepository.Insert(new CelebrityNotificationDto(){CelebrityTime = contactDto.BirthdayDate,Contact = contactDto,IsNotify = true});
        }
    }
}
