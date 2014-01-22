namespace SmsManager.Infrastructure.Entities.Dto
{
    public interface IMessageDto:IDto
    {
        string Text { get; set; }
        long Usages { get; set; }
        long CategoryId { get; set; }
    }
}