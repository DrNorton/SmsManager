using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmsManager.Visual.ViewModels.Shedule;

namespace SmsManager.Visual.ViewModels.DesignViewModel
{
    public class DesignAddSheduleViewModel:AddSheduleViewModel
    {
        public DesignAddSheduleViewModel()
            :base(null)
        {
            base.ListBoxItems=new List<ListBoxNavigationItem>();
            base.ListBoxItems.Add(new ListBoxNavigationItem(){Name="Выбрать из списка контактов"});
        }
    }
}
