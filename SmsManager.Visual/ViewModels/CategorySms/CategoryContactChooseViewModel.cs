using Phone7.Fx.Ioc;
using Phone7.Fx.Mvvm;
using Phone7.Fx.Navigation;
using SmsManager.DataLayer.Repositories.Base;
using SmsManager.Visual.ViewModels.Base;
using SmsManager.Visual.ViewModels.Contracts;
using SmsManager.Visual.Views;

namespace SmsManager.Visual.ViewModels.CategorySms
{
   
    public class CategoryContactChooseViewModel:BaseContactChooseViewModel, IContactChooseViewModel
    {
        public string ChoosedMessageText { get; set; }


        [Injection]
        public CategoryContactChooseViewModel(IContactRepository contactRepository,INavigationService navigationService)
           :base(contactRepository,navigationService){
        
        }

        protected override void OnContactSelected()
        {
            _navigationService.UriFor<CategoryTelephoneKindChooseViewModel>().WithParam(x => x.SelectedContactId, this.SelectedContact.Id).WithParam(y => y.ChoosedMessageText, ChoosedMessageText).Navigate();
        }
    }
}
