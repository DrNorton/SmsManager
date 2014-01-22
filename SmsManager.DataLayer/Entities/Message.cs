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
using SmsManager.Infrastructure.Entities;

namespace SmsManager.DataLayer.Entities
{
  

    [Table]
    public class Message : IMessageDetail{
        private long _id;
        private string _text;
        private long _usages;
        private long _categoryId;

        [Column]
        public long Id{
            get { return _id; }
            set { _id = value; }
        }

        [Column]
        public string Text{
            get { return _text; }
            set { _text = value; }
        }

        [Column]
        public long Usages{
            get { return _usages; }
            set { _usages = value; }
        }

        [Column]
        public long CategoryId{
            get { return _categoryId; }
            set { _categoryId = value; }
        }
    }
}
