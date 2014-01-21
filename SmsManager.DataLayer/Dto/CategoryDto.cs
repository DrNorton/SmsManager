using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Data.Linq.Mapping;

namespace SmsManager.DataLayer.Entities
{
    [Table]
    public class CategoryDto:IDto
    {
        public long Id { get; set; }
        public int Name { get; set; }
        public byte[] Image { get; set; }
    }
}
