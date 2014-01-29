using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace SmsManager.Services.Models
{
    public class ContactFromBook
    {
        public long Id { get; set; }
        public string DisplayName { get; set; }
        public IEnumerable<TelephoneFromBook> Telephones { get; set; }
        public BitmapSource Photo { get; set; }

        public ContactFromBook(){
            Telephones=new Collection<TelephoneFromBook>();
        }
    }

    public class TelephoneFromBook
    {
      
        public string TelephoneNumber { get; set; }
        public string Kind { get; set; }
       
    }
}
