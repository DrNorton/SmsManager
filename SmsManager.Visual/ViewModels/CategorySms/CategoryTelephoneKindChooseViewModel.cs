using Phone7.Fx.Ioc;
using Phone7.Fx.Mvvm;
using Phone7.Fx.Navigation;
using SmsManager.DataLayer.Repositories.Base;
using SmsManager.Services.Base;
using SmsManager.Services.Models;
using SmsManager.Visual.ViewModels.Base;
using SmsManager.Visual.ViewModels.Contracts;
using SmsManager.Visual.Views;

namespace SmsManager.Visual.ViewModels.CategorySms
{
    [ViewModel(typeof(TelephoneKindChooseView))]
    public class CategoryTelephoneKindChooseViewModel : BaseTelephoneKindChooseViewModel, ITelephoneKindChooseViewModel
    {

        private readonly ISmsSenderService _smsSenderService;

        public string ChoosedMessageText { get; set; }
       
        [Injection]
        public CategoryTelephoneKindChooseViewModel(INavigationService navigationService, ISmsSenderService smsSenderService,IContactRepository contactRepository)
            :base(navigationService,contactRepository)
        {
            _smsSenderService = smsSenderService;
        }



        protected override void OnSelectedPhoneAction()
        {
            _smsSenderService.SendSms(new SmsMessage() { MessageText = ChoosedMessageText, Telephone = SelectedPhone.TelephoneNumber });
        }
    }
}
