using System;
using System.Collections.Generic;
using System.Linq;
using Phone7.Fx.Ioc;
using Phone7.Fx.Mvvm;
using Phone7.Fx.Navigation;
using SmsManager.DataLayer.Dto;
using SmsManager.Services;
using SmsManager.Services.Base;
using SmsManager.Visual.Models;
using SmsManager.Visual.Views;

namespace SmsManager.Visual.ViewModels
{
    [ViewModel(typeof(MainView))]
    public class MainViewModel:ViewModelBase
    {
        private IDatabaseService _dataservice;
        private INavigationService _navigationService;
        private List<MainMenuItem> _menuItems; 

        private CategoryDto _selectedCategory;
        private MainMenuItem _selectedMenuItem;

        [Injection]
        public MainViewModel(IDatabaseService dataService,INavigationService navigationService){
            _dataservice = dataService;
            _navigationService = navigationService;
            CreateMenu();
        }

        private void CreateMenu(){
            _menuItems=new List<MainMenuItem>();
            //_menuItems.Add(new MainMenuItem(){MenuItemName = "Расписание"});
            _menuItems.Add(new MainMenuItem(){MenuItemName = "Расписание праздников"});
        }

        public IEnumerable<CategoryDto> Categories{
            get{
                if (_dataservice != null){
                    return _dataservice.CategoryRepository.GetAll().ToList();
                }
                return null;
            }
        }

        public CategoryDto SelectedCategory{
            get { return _selectedCategory; }
            set{
                _selectedCategory = value;
                base.RaisePropertyChanged(() => SelectedCategory);
                NavigateToCategoryViewModel();
            }
        }

        public List<MainMenuItem> MenuItems{
            get { return _menuItems; }
            set{
                _menuItems = value;
                base.RaisePropertyChanged(()=>MenuItems);
            }
        }

        public MainMenuItem SelectedMenuItem{
            get { return _selectedMenuItem; }
            set{
                _selectedMenuItem = value;
                NavigateBySelectedMenuItem();
                base.RaisePropertyChanged(()=>SelectedMenuItem);
            }
        }

        private void NavigateBySelectedMenuItem(){
            //To:DO заменить на рефлексию
            switch (SelectedMenuItem.MenuItemName){
                case "Расписание праздников":
                    _navigationService.UriFor<CalendarViewModel>().Navigate();
                    break;
            }
        }

        private void NavigateToCategoryViewModel(){
            _navigationService.UriFor<CategoryViewModel>().WithParam(m => m.CurrentCategoryId, SelectedCategory.Id).Navigate();
        }


    }
}
