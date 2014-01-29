using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Phone7.Fx.Mvvm;
using ScaryStories.ViewModel.Extensions;
using SmsManager.DataLayer.Dto;
using SmsManager.Services.Models;
using SmsManager.Visual.ViewModels.Contracts;

namespace SmsManager.Visual.ViewModels.DesignViewModel
{
    public class DesignContactChooseViewModel:ViewModelBase,IContactChooseViewModel
    {



        public List<AlphaKeyGroup<ContactDto>> Contacts
        {
            get{
                return null;
            }
            set
            {
                
            }
        }
    }
}
