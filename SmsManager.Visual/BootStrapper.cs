using Phone7.Fx;
using Phone7.Fx.Ioc;
using SmsManager.DataLayer;
using SmsManager.DataLayer.Repositories;
using SmsManager.Infrastructure.IRepositories;
using SmsManager.Services;

namespace SmsManager.Visual
{
    public class BootStrapper : PhoneBootstrapper
    {
        public BootStrapper(){
            
        }

        protected override void Configure(){
            var context = new SmsDataContext("");
            Container.Current.RegisterInstance<ISmsDataContext>(context);
            Container.Current.RegisterType<ICategoryRepository, CategoryRepository>();
            Container.Current.RegisterType<IMessagesRepository, MessagesRepository>();
            Container.Current.RegisterType<IDatabaseService, DatabaseService>();
        }
    }
}
