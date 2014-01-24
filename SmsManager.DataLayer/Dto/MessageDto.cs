using System.Data.Linq.Mapping;
using SmsManager.Infrastructure.Entities.Dto;

namespace SmsManager.DataLayer.Dto
{
    
    public class MessageDto: IDto
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public long Usages { get; set; }
        public long CategoryId { get; set; }
    }
}
