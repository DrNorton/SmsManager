using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using Phone7.Fx.Mvvm;
using SmsManager.DataLayer.Dto;
using SmsManager.Services.Models;

namespace SmsManager.Visual.ViewModels.DesignViewModel
{
    public class DesignTelephoneKindChooseViewModel:ViewModelBase,ITelephoneKindChooseViewModel
    {
        private ContactDto _selectedDto;
       
        
        public DesignTelephoneKindChooseViewModel(){
            BitmapSource bSource = new BitmapImage(new Uri(@"C:\Users\ПРОГРАММИСТ-2\Pictures\1.jpg"));
            var numberList = new List<ContactDto>();
      
           // _selectedDto=new ContactDto(){DisplayName = "Дима Иванов",Id=0,HomeTelephone = "89169637210",MobileTelephone = "89166728879"};
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
