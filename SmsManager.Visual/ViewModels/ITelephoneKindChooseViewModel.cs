using SmsManager.DataLayer.Dto;
using SmsManager.Services.Models;

namespace SmsManager.Visual.ViewModels
{
    public interface ITelephoneKindChooseViewModel
    {
        ContactDto SelectedContact { get; set; }
    }
}