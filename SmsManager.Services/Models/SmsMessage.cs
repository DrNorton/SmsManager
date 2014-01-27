using SmsManager.DataLayer.Dto;

namespace SmsManager.Services.Models
{
    public class SmsMessage
    {
        public string Telephone { get; set; }
        public string MessageText { get; set; }
    }
}
