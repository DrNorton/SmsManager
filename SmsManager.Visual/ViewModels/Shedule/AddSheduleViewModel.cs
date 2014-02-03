using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Phone7.Fx.Ioc;
using Phone7.Fx.Mvvm;
using Phone7.Fx.Navigation;
using SmsManager.Visual.ViewModels.CategorySms;
using SmsManager.Visual.Views.Shedule;

namespace SmsManager.Visual.ViewModels.Shedule
{
    [ViewModel(typeof(AddSheduleView))]
    public class AddSheduleViewModel:ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private IList<ListBoxNavigationItem> _listBoxItems;
        private ListBoxNavigationItem _selectedListBoxItem;
            
            [Injection]
        public AddSheduleViewModel(INavigationService navigationService)
        {
                _navigationService = navigationService;
                ListBoxItems=new List<ListBoxNavigationItem>();
            ListBoxItems.Add(new ListBoxNavigationItem(){Name = "Выбрать из списка контактов",NavigationAction = new Action(NavigateToGetContactViewModel)});
        }

        private void NavigateToGetContactViewModel()
        {
            _navigationService.UriFor<NewSheduleContactChooseViewModel>().Navigate();
        }

        public IList<ListBoxNavigationItem> ListBoxItems
        {
            get { return _listBoxItems; }
            set
            {
                _listBoxItems = value;
                base.RaisePropertyChanged(()=>ListBoxItems);
            }
        }

        public ListBoxNavigationItem SelectedListBoxItem
        {
            get { return _selectedListBoxItem; }
            set
            {
                _selectedListBoxItem = value;
                SelectedListBoxItemNavigation();
                base.RaisePropertyChanged(()=>SelectedListBoxItem);
            }
        }

        private void SelectedListBoxItemNavigation()
        {
            if (_selectedListBoxItem != null)
            {
                _selectedListBoxItem.NavigationAction.Invoke();
            }
        }

        public override void InitalizeData()
        {
            base.InitalizeData();
        }
    }

    public class ListBoxNavigationItem
    {
        public string Name { get; set; }
        public Action NavigationAction { get; set; }
    }
}
