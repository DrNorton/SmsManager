using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmsManager.DataLayer.Entities;
using SmsManager.Infrastructure.Entities.Dto;

namespace SmsManager.DataLayer.Dto
{
    public class TelephoneKindDto:IDto
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public TelephoneKindDto(TelephoneKind kind)
        {
            Id = kind.Id;
            Name = kind.Name;
        }

        public TelephoneKindDto()
        {
            
        }

        public static TelephoneKindDto CreateKind(string type)
        {
            TelephoneKindDto kind = null;
            switch (type)
            {
                case "Мобильный телефон":
                    kind = new TelephoneKindDto() { Id = 1, Name = "Мобильный телефон" };
                    break;

                case "Домашний телефон":
                    kind = new TelephoneKindDto() { Id = 2, Name = "Домашний телефон" };
                    break;

                case "Рабочий телефон":
                    kind = new TelephoneKindDto() { Id = 1, Name = "Рабочий телефон" };
                    break;
            }
            return kind;
        }
    }
}
