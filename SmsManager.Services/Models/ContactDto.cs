using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace SmsManager.Services.Models
{
    public class ContactDto
    {
        public long Id { get; set; }
        public string DisplayName { get; set; }
        public IEnumerable<TelephoneDto> Telephones { get; set; }
        public BitmapSource Photo { get; set; }

        public ContactDto(){
            Telephones=new Collection<TelephoneDto>();
        }
    }

    public class TelephoneDto
    {
      
        public string TelephoneNumber { get; set; }
        public string Kind { get; set; }
       
    }
}
