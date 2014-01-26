using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmsManager.Services.Models
{
    public class ContactDto
    {
        public string DisplayName { get; set; }
        public IEnumerable<TelephoneDto> Telephones { get; set; }
    }

    public class TelephoneDto
    {
        public string TelephoneNumber { get; set; }
        public string Kind { get; set; }
    }
}
