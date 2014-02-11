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
using SmsManager.DataLayer.Dto;
using SmsManager.Infrastructure;

namespace SmsManager.Visual.Models
{
    public interface INewShedule
    {
        ContactDto ContactDto { get; set; }
        TelephoneDto Telephone { get; set; }
    }

    public class NewShedule : INewShedule
    {
        private ContactDto _contactDto;
        private TelephoneDto _telephone;

        public ContactDto ContactDto{
            get { return _contactDto; }
            set { _contactDto = value; }
        }
        public TelephoneDto Telephone{
            get { return _telephone; }
            set { _telephone = value; }
        }

    }
}
