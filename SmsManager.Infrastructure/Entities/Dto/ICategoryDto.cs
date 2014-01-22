namespace SmsManager.Infrastructure.Entities.Dto
{
    public interface ICategoryDto:IDto
    {
        int Name { get; set; }
        byte[] Image { get; set; }
    }
}