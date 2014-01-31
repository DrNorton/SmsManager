using System.Data.Linq.Mapping;
using SmsManager.DataLayer.Entities;
using SmsManager.Infrastructure.Entities.Dto;

namespace SmsManager.DataLayer.Dto
{
    
    public class MessageDto: IDto
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public System.Nullable<long> Usages { get; set; }
        public long CategoryId { get; set; }

        public MessageDto()
        {
            
        }

        public MessageDto(Message message)
        {
            Id = message.Id;
            Text = message.Text;
            Usages = message.Usages;
            CategoryId = message.CategoryId;
        }

        public Message ToEntityMessage()
        {
            var message = new Message();
            message.Id = this.Id;
            message.Text = this.Text;
            message.CategoryId = this.CategoryId;
            message.Usages = this.Usages;
            return message;
        }
    }
}
