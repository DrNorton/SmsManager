using Phone7.Fx.Ioc;
using Phone7.Fx.Mvvm;
using SmsManager.Services;
using SmsManager.Visual.Views;

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
