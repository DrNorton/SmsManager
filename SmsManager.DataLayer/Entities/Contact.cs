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
    [Table(Name = "Contact")]
    public class ContactFromBase : IDetail
    {
        private long _id;
        private string _displayName;
        private DateTime _birthdayDate;
        private string _emailAddress;
        private byte[] _photo;
        private string _homeTelephone;
        private string _mobileTelephone;
        private string _workTelephone;

            [Column]
        public string HomeTelephone{
            get { return _homeTelephone; }
            set { _homeTelephone = value; }
        }
            [Column]
        public string WorkTelephone{
            get { return _workTelephone; }
            set { _workTelephone = value; }
        }

            [Column]
        public string MobileTelephone{
            get { return _mobileTelephone; }
            set { _mobileTelephone = value; }
        }

        [Column]
        public DateTime BirthdayDate{
            get { return _birthdayDate; }
            set { _birthdayDate = value; }
        }

        [Column]
        public string DisplayName{
            get { return _displayName; }
            set { _displayName = value; }
        }

        [Column]
        public string EmailAddress{
            get { return _emailAddress; }
            set { _emailAddress = value; }
        }

        [Column]
        public byte[] Photo{
            get { return _photo; }
            set { _photo = value; }
        }

        [Column(IsPrimaryKey = true)]
        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
