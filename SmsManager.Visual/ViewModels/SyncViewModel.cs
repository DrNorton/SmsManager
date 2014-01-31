using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Phone7.Fx.Ioc;
using Phone7.Fx.Mvvm;
using SmsManager.DataLayer.Dto;
using SmsManager.Services;
using SmsManager.Services.Base;
using SmsManager.Visual.Views;

namespace SmsManager.Visual.ViewModels
{
    [ViewModel(typeof(SyncView))]
    public class SyncViewModel:ViewModelBase
    {
        private readonly IContactSyncService _syncService;
        private IEnumerable<ContactDto> _contacts; 

        [Injection]
        public SyncViewModel(IContactSyncService syncService)
        {
            _syncService = syncService;
            _syncService.OnSyncComplete += CompleteSync;
        }

        private void CompleteSync(object o, SyncContactServiceEventArgs e)
        {
            Contacts = e.Contacts;
        }

        public override void InitalizeData()
        {
            
            _syncService.StartSyncronizationAsync();
            base.InitalizeData();
        }

        public IEnumerable<ContactDto> Contacts
        {
            get { return _contacts; }
            set
            {
                _contacts = value;
                base.RaisePropertyChanged(() => Contacts);
            }
        }


    }
}
