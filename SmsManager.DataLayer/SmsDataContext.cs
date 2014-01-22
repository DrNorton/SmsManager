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
        private IEnumerable<ICategoryDetail> _categories;
        private IEnumerable<IMessageDetail> _messages;

        public SmsDataContext(string connectionString)
            :base(connectionString){
            
        }


        public IEnumerable<ICategoryDetail> Categories
        {
            get { return _categories; }
        }

        public IEnumerable<IMessageDetail> Messages
        {
            get { return _messages; }
        }
    }
}
