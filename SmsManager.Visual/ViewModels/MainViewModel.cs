using Phone7.Fx.Ioc;
using Phone7.Fx.Mvvm;
using SmsManager.Infrastructure.Services.Contracts;
using SmsManager.Visual.Views;
using SmsManager.Visual.Views.Contracts;

namespace SmsManager.Visual.ViewModels
{
    [ViewModel(typeof(MainView))]
    public class MainViewModel:ViewModelBase{
        [Injection]
        public MainViewModel(IDatabaseService service){
            string sd = "dada";
             
        }
    }
}
