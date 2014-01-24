using System.Collections.Generic;
using System.Linq;
using Phone7.Fx.Ioc;
using Phone7.Fx.Mvvm;
using Phone7.Fx.Navigation;
using SmsManager.DataLayer.Dto;
using SmsManager.Services;
using SmsManager.Visual.Views;

namespace SmsManager.Visual.ViewModels
{
    [ViewModel(typeof(MainView))]
    public class MainViewModel:ViewModelBase
    {
        private IDatabaseService _dataservice;
        private INavigationService _navigationService;

        private CategoryDto _selectedCategory;

        [Injection]
        public MainViewModel(IDatabaseService dataService,INavigationService navigationService){
            _dataservice = dataService;
            _navigationService = navigationService;
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

        private void NavigateToCategoryViewModel(){
            _navigationService.UriFor<CategoryViewModel>().WithParam(m => m.CurrentCategoryId, SelectedCategory.Id).Navigate();
        }


    }
}
