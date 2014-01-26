using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phone7.Fx.Navigation;

namespace SmsManager.Tests.FakeServices
{
    public class FakeNavigationService:INavigationService
    {
        public void Navigate(string pageName)
        {
            throw new NotImplementedException();
        }

        public System.Windows.Navigation.JournalEntry RemoveBackEntry()
        {
            throw new NotImplementedException();
        }

        public void GoBack()
        {
            throw new NotImplementedException();
        }

        public void GoForward()
        {
            throw new NotImplementedException();
        }

        public bool CanGoBack
        {
            get { throw new NotImplementedException(); }
        }

        public bool CanGoForward
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<JournalEntry> BackStack
        {
            get { throw new NotImplementedException(); }
        }
    }
}
