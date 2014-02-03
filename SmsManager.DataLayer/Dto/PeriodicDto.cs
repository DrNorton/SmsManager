using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmsManager.DataLayer.Entities;
using SmsManager.Infrastructure.Entities.Dto;

namespace SmsManager.DataLayer.Dto
{
    public class PeriodicDto:IDto
    {
        private long _id;
        private int _days;
        private int _hours;
        private int _minutes;
        private int _seconds;
        private string _name;

        public PeriodicDto(Periodic period)
        {
            _days=period.Days;
            _hours = period.Hours;
            _minutes = period.Minutes;
            _seconds = period.Seconds;
            _name=period.Name;
            _id = period.Id;
        }

        public PeriodicDto()
        {
            
        }

        public long Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public int Days
        {
            get { return _days; }
            set { _days = value; }
        }

        public int Hours
        {
            get { return _hours; }
            set { _hours = value; }
        }

        public int Minutes
        {
            get { return _minutes; }
            set { _minutes = value; }
        }

        public int Seconds
        {
            get { return _seconds; }
            set { _seconds = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
