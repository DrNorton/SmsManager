using SmsManager.Services.Models;

namespace SmsManager.Visual.ViewModels
{
    public interface ITelephoneKindChooseViewModel
    {
        ContactDto SelectedContact { get; set; }
    }
}