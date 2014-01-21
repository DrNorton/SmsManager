using System;
using System.Data.Linq.Mapping;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SmsManager.DataLayer.Entities
{
    [Table]
    public class MessageDto:IDto
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public long Usages { get; set; }
        public long CategoryId { get; set; }
    }
}
