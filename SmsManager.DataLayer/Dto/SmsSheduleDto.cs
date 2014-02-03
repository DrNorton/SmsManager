using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmsManager.DataLayer.Entities;
using SmsManager.Infrastructure.Entities.Dto;

namespace SmsManager.DataLayer.Dto
{
    public class SmsSheduleDto:IDto
    {
        private long _id;
        private ContactDto _contact;
        private DateTime? _lastExecuted;
        private string _name;
        private PeriodicDto _periodic;
        private IList<SmsTaskDto> _smsTasks;
        private long _contactId;

        public SmsSheduleDto(SmsShedule shedule)
        {
            _contact=new ContactDto(shedule.Contact);
            _id=shedule.Id;
            _lastExecuted=shedule.LastExecuted;
            _name=shedule.Name;
            _contactId=shedule.ContactId;
            _periodic=new PeriodicDto(shedule.Periodic);
            _smsTasks=new List<SmsTaskDto>();
            foreach (var task in shedule.SmsTasks)
            {
                _smsTasks.Add(new SmsTaskDto(task));
            }
        }

        public SmsSheduleDto()
        {
            
        }

        public long ContactId
        {
            get { return _contactId; }
            set { _contactId = value; }
        }

        public IList<SmsTaskDto> SmsTasks
        {
            get { return _smsTasks; }
            set { _smsTasks = value; }
        }

        public PeriodicDto Periodic
        {
            get { return _periodic; }
            set { _periodic = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public DateTime? LastExecuted
        {
            get { return _lastExecuted; }
            set { _lastExecuted = value; }
        }

        public ContactDto Contact
        {
            get { return _contact; }
            set { _contact = value; }
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


    }
}
