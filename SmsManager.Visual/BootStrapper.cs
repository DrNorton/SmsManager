using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Linq;
using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Phone7.Fx;
using Phone7.Fx.Ioc;
using Phone7.Fx.Navigation;
using SmsManager.DataLayer;
using SmsManager.DataLayer.Entities;
using SmsManager.DataLayer.Repositories;
using SmsManager.Infrastructure.IRepositories;
using SmsManager.Services;
using System.Windows.Navigation;

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
            Container.Current.RegisterType<IDatabaseService, DatabaseService>();
          
        }

        private SmsDataContext CreateDataBaseAndFillTestData(SmsDataContext db)
        {
            if (db.DatabaseExists() == false)
            {
                // Create the local database.
                db.CreateDatabase();

                // Prepopulate the categories.
                db.Categories.InsertOnSubmit(new Category() {Id=0, Image = new byte[5], Name = "1 категория" });
                db.Categories.InsertOnSubmit(new Category() { Id = 1, Image = new byte[5], Name = "2 категория" });
                db.Categories.InsertOnSubmit(new Category() { Id = 2, Image = new byte[5], Name = "3 категория" });
                db.Categories.InsertOnSubmit(new Category() { Id = 3, Image = new byte[5], Name = "4 категория" });
                db.Categories.InsertOnSubmit(new Category() { Id = 4, Image = new byte[5], Name = "5 категория" });
               
                long messageId = 0;
                for (int i = 0; i < 5; i++){
                    db.Messages.InsertOnSubmit(new Message() { Id = messageId, CategoryId = i, Text = String.Format("текстовое сообщение для категории {0}", i) });
                    messageId++;
                }
                   
                
                // Save categories to the database.
                db.SubmitChanges();
            }
            return db;
        }

     

    }
}
