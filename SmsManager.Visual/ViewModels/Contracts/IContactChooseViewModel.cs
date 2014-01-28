using System.Collections.Generic;
using ScaryStories.ViewModel.Extensions;
using SmsManager.Services.Models;

namespace SmsManager.Visual.ViewModels.Contracts
{
    public interface IContactChooseViewModel
    {
        List<AlphaKeyGroup<ContactDto>> Contacts { get; set; }
    }
}