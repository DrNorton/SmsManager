using System;
using System.Collections.Generic;
using System.Linq;
using Phone7.Fx.Ioc;
using Phone7.Fx.Mvvm;
using SmsManager.DataLayer.Dto;
using SmsManager.DataLayer.Repositories.Base;
using SmsManager.Visual.Views;

namespace SmsManager.Visual.ViewModels
{
      [ViewModel(typeof(CalendarView))]
    public class CalendarViewModel:ViewModelBase
      {
          private readonly IContactRepository _repository;
          private readonly ICelebrityNotificationRepository _celebrityNotificationRepository;
          private Dictionary<DateTime, string> _dateRepository;
          private DateTime _selectedDate;
          private IEnumerable<ContactDto> _contacts;
          private IEnumerable<CelebrityNotificationDto> _notifications;
              
          [Injection]
          public CalendarViewModel(IContactRepository repository,ICelebrityNotificationRepository celebrityNotificationRepository)
          {
              _repository = repository;
              _celebrityNotificationRepository = celebrityNotificationRepository;
              _dateRepository=new Dictionary<DateTime, string>();
          }

          public override void InitalizeData()
          {
             _notifications = _celebrityNotificationRepository.GetAll().ToList();
              var celebrityNotificationDtos = _notifications.Where(x=>x.Contact.BirthdayDate!=null).ToList();
              foreach (var celebrityNotificationDto in celebrityNotificationDtos)
              {
                  DateRepository.Add((DateTime)celebrityNotificationDto.CelebrityTime,celebrityNotificationDto.Contact.DisplayName);
              }
              base.InitalizeData();
          }

          public Dictionary<DateTime, string> DateRepository{
              get { return _dateRepository; }
              set{
                  _dateRepository = value;
                  base.RaisePropertyChanged(()=>DateRepository);
              }
          }

          public DateTime SelectedDate{
              get { return _selectedDate; }
              set{
                  _selectedDate = value;
                  base.RaisePropertyChanged(()=>SelectedDate);
              }
          }
      }
}
