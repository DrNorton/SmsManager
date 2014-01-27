using SmsManager.Services.Models;

namespace SmsManager.Services.Base
{
    public interface IContactService
    {
        event SmsManager.Services.ContactService.ContactServiceEventHandler OnGetComplete;
        void GetAllContactsAsync();
        void GetOneContactAsync(string displayName);
    }
}