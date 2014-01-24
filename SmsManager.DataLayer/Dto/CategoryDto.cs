using System.Data.Linq.Mapping;
using SmsManager.Infrastructure.Entities.Dto;


namespace SmsManager.DataLayer.Dto
{
  
    public class CategoryDto:IDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
    }
}
