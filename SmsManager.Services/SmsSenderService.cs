using Microsoft.Phone.Tasks;
using Phone7.Fx.Ioc;
using SmsManager.Services.Base;
using SmsManager.Services.Models;

namespace SmsManager.Services
{
    public class SmsSenderService:ISmsSenderService
    {
        [Injection]
        public SmsSenderService()
        {
            
        }

        public void SendSms(SmsMessage message){
            SmsComposeTask newSms=new SmsComposeTask();
            newSms.Body = message.MessageText;
            newSms.To = message.Telephone;
            newSms.Show();
        }
    }
}
