using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmsManager.Services.Base
{
    public interface IContactSyncService
    {
        event ContactSyncService.SyncContactServiceEventHandler OnSyncComplete;
        void StartSyncronizationAsync();
    }
}
