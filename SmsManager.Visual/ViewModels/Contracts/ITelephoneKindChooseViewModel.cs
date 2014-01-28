using SmsManager.Services.Models;

namespace SmsManager.Visual.ViewModels.Contracts
{
    public interface ITelephoneKindChooseViewModel
    {
        ContactDto SelectedContact { get; set; }
    }
}