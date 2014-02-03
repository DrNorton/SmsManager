using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmsManager.DataLayer.Entities;
using SmsManager.Infrastructure.Entities.Dto;

namespace SmsManager.DataLayer.Dto
{
    public class SmsTaskDto:IDto
    {
        private long _id;
        private bool _isExecuted;
        private bool _isGeocoding;
        private MessageDto _message;

        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public bool IsExecuted
        {
            get { return _isExecuted; }
            set { _isExecuted = value; }
        }

        public bool IsGeocoding
        {
            get { return _isGeocoding; }
            set { _isGeocoding = value; }
        }

        public MessageDto Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public SmsTaskDto(SmsTask task)
        {
            _id = task.Id;
            _isExecuted=task.IsExecuted;
            _isGeocoding=task.IsGeocoding;
            if (task.Message != null)
            {
                _message=new MessageDto(task.Message);
            }
        }
    }
}
