using System;
using System.Data.Linq;
using Phone7.Fx;
using Phone7.Fx.Ioc;
using SmsManager.DataLayer;
using SmsManager.DataLayer.Entities;
using SmsManager.DataLayer.Repositories;
using SmsManager.DataLayer.Repositories.Base;
using SmsManager.Infrastructure.IRepositories;
using SmsManager.Services;
using SmsManager.Services.Base;

namespace SmsManager.Visual
{
    public class BootStrapper : PhoneBootstrapper
    {
        private string _connectionString;

        protected override void Configure()
        {
            _connectionString = "Data Source=isostore:/db.sdf";
            var db = new SmsDataContext(_connectionString);
            var context = CreateDataBaseAndFillTestData(db);
            Container.Current.RegisterInstance<ISmsDataContext>(context);
            Container.Current.RegisterType<ICategoryRepository, CategoryRepository>();
            Container.Current.RegisterType<IMessagesRepository, MessagesRepository>();
            Container.Current.RegisterType<IContactRepository, ContactRepository>();
            Container.Current.RegisterType<IDatabaseService, DatabaseService>();
            Container.Current.RegisterType<ICelebrityNotificationRepository, CelebrityNotificationRepository>();
            Container.Current.RegisterType<IContactSyncService, ContactSyncService>();
            Container.Current.RegisterType<ISmsSenderService, SmsSenderService>();
            Container.Current.RegisterType<ICelebritySyncService, CelebritySyncService>();
        }

        private SmsDataContext CreateDataBaseAndFillTestData(SmsDataContext db)
        {
            if (db.DatabaseExists() == false)
            {
                // Create the local database.
                db.CreateDatabase();

                // Prepopulate the categories.
                db.Categories.InsertOnSubmit(new Category() {Id=0, Image = new byte[5], Name = "1 категория",Messages = new EntitySet<Message>(){new Message(){Text = "12"}}});
               
                db.TelephoneKinds.InsertOnSubmit(new TelephoneKind() { Id = 1, Name = "Мобильный телефон"});
                db.TelephoneKinds.InsertOnSubmit(new TelephoneKind() { Id = 2, Name = "Домашний телефон" });
                db.TelephoneKinds.InsertOnSubmit(new TelephoneKind() { Id = 3, Name = "Рабочий телефон" });
                
                // Save categories to the database.
                db.SubmitChanges();
            }
            return db;
        }

     

    }
}
