using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using SmsManager.DataLayer.Entities;
using SmsManager.Infrastructure.IRepositories;
using SmsManager.Infrastructure.Entities;

namespace SmsManager.DataLayer
{
    public class SmsDataContext:DataContext, ISmsDataContext{

        public SmsDataContext(string connectionString)
            :base(connectionString){
          
        }


        public Table<Category> Categories
        {
            get { return this.GetTable<Category>(); }
        }

        public Table<Message> Messages
        {
            get { return this.GetTable<Message>(); }
        }
        public Table<ContactFromBase> Contacts
        {
            get { return this.GetTable<ContactFromBase>(); }
        }
    }
}
