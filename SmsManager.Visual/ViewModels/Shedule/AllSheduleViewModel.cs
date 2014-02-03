using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Phone7.Fx.Commands;
using Phone7.Fx.Ioc;
using Phone7.Fx.Mvvm;
using Phone7.Fx.Navigation;
using SmsManager.DataLayer.Dto;
using SmsManager.DataLayer.Repositories.Base;
using SmsManager.Visual.Views.Shedule;

namespace SmsManager.Visual.ViewModels.Shedule
{
    [ViewModel(typeof(AllSheduleView))]
    public class AllSheduleViewModel:ViewModelBase
    {
        private readonly ISmsSheduleRepository _sheduleRepository;
        private readonly INavigationService _navigationService;
        private List<SmsSheduleDto> _shedules;
        private SmsSheduleDto _selectedShedule;
        public DelegateCommand<object> AddSheduleCommand { get; set; }
        public DelegateCommand<object> DeleteSheduleCommand { get; set; }

        [Injection]
        public AllSheduleViewModel(ISmsSheduleRepository sheduleRepository,INavigationService navigationService)
        {
            _sheduleRepository = sheduleRepository;
            _navigationService = navigationService;
            AddSheduleCommand=new DelegateCommand<object>(AddNewShedule);
            DeleteSheduleCommand=new DelegateCommand<object>(DeleteShedule);
        }

        private void DeleteShedule(object obj)
        {
            throw new NotImplementedException();
        }

        private void AddNewShedule(object obj)
        {
          _navigationService.UriFor<AddSheduleViewModel>().Navigate();
        }

        public List<SmsSheduleDto> Shedules
        {
            get { return _shedules; }
            set
            {
                _shedules = value;
                base.RaisePropertyChanged(()=>Shedules);
            }
        }

        public SmsSheduleDto SelectedShedule
        {
            get { return _selectedShedule; }
            set
            {
                _selectedShedule = value;
                base.RaisePropertyChanged(()=>SelectedShedule);
            }
        }

        public override void InitalizeData()
        {
            Shedules = _sheduleRepository.GetAll().ToList();
            base.InitalizeData();
        }
    }
}
