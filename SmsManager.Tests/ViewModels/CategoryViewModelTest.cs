using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using SmsManager.Services;
using SmsManager.Tests.FakeServices;
using SmsManager.Visual.ViewModels;

namespace SmsManager.Tests.ViewModels
{
    [TestFixture]
    public class CategoryViewModelTest
    {
        public CategoryViewModelTest()
        {
           
        }

        [Test]
        public void InitalizeData_LoadMethod_NotNull()
        {
            var viewModel = new CategoryViewModel(new FakeDatabaseService());
        }
    }
}
