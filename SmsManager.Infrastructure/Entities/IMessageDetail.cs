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

namespace SmsManager.Infrastructure.Entities
{
    public interface IMessageDetail:IDetail
    {
        string Text { get; set; }
        long Usages { get; set; }
        long CategoryId { get; set; }
    }
}
