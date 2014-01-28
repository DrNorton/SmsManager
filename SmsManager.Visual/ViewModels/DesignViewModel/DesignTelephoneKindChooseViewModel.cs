using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Phone7.Fx.Mvvm;
using SmsManager.Services.Models;
using SmsManager.Visual.ViewModels.Contracts;

namespace SmsManager.Visual.ViewModels.DesignViewModel
{
    public class DesignTelephoneKindChooseViewModel:ViewModelBase,ITelephoneKindChooseViewModel
    {
        private ContactDto _selectedDto;
        private TelephoneDto _selectedPhone;
        
        public DesignTelephoneKindChooseViewModel(){
            BitmapSource bSource = new BitmapImage(new Uri(@"C:\Users\ПРОГРАММИСТ-2\Pictures\1.jpg"));
            var numberList = new List<TelephoneDto>();
            numberList.Add(new TelephoneDto(){Kind = "Mobile",TelephoneNumber = "89166728879"});
            _selectedDto=new ContactDto(){DisplayName = "Дима Иванов",Id=0,Photo = bSource,Telephones = numberList};
        }




        public ContactDto SelectedContact
        {
            get{
                return _selectedDto;
            }
            set{
                _selectedDto = value;
            }
        }

       
    }
}
