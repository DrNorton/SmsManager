using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace SmsManager.Infrastructure.Entities
{
    public interface ICategoryDetail:IDetail
    {
        int Name { get; set; }
        byte[] Image { get; set; }
    }
}
