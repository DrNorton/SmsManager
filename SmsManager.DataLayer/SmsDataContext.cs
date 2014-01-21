using System;
using System.Data.Linq;
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

namespace SmsManager.DataLayer
{
    public class SmsDataContext:DataContext{
        public Table<Category> Categories;
        public Table<Message> Messages; 

        public SmsDataContext(string connectionString)
            :base(connectionString){
            
        }
    }
}
