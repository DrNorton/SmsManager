using ScaryStories.ViewModel.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmsManager.Services.Models;

namespace SmsManager.Visual.ViewModels.Contracts
{
        public interface IContactChooseViewModel
        {
            List<AlphaKeyGroup<ContactDto>> Contacts { get; set; }
        }
}
