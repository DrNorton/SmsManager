using System.Collections.Generic;
using SmsManager.DataLayer.Dto;

namespace SmsManager.Services.Base
{
    public interface ICelebritySyncService
    {
        IEnumerable<CelebrityNotificationDto> StartSync(IEnumerable<ContactDto> contacts );
    }
}