using System;
using System.Collections.Generic;
using Phone7.Fx.Ioc;
using Phone7.Fx.Mvvm;
using SmsManager.Visual.Views;

namespace SmsManager.Visual.ViewModels
{
      [ViewModel(typeof(CalendarView))]
    public class CalendarViewModel:ViewModelBase
      {
          private Dictionary<DateTime, string> _dateRepository;
          private DateTime _selectedDate;

          [Injection]
          public CalendarViewModel(){
              _dateRepository=new Dictionary<DateTime, string>();
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
