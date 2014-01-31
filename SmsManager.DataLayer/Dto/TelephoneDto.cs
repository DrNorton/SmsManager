using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmsManager.DataLayer.Entities;
using SmsManager.Infrastructure.Entities.Dto;

namespace SmsManager.DataLayer.Dto
{
    public class TelephoneDto:IDto
    {
        public long Id { get; set; }
        public long ContactId { get; set; }
        public string TelephoneNumber { get; set; }
        public TelephoneKindDto TelephoneKind { get; set; }

        public TelephoneDto(Telephone telephone)
        {
            Id = telephone.Id;
            ContactId = telephone.ContactId;
            TelephoneNumber = telephone.TelephoneNumber;
            TelephoneKind=new TelephoneKindDto(telephone.TelephoneKind);
        }

        public TelephoneDto()
        {
            
        }
    }
}
