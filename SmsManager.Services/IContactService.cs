namespace SmsManager.Services
{
    public interface IContactService
    {
        event SmsManager.Services.ContactService.ContactServiceEventHandler OnGetComplete;
        void GetAllContactsAsync();
    }
}