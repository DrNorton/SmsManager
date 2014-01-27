using SmsManager.Services.Models;

namespace SmsManager.Services.Base
{
    public interface ISmsSenderService
    {
        void SendSms(SmsMessage message);
    }
}