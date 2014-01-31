using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Phone7.Fx.Ioc;
using Phone7.Fx.Mvvm;
using Phone7.Fx.Navigation;
using ScaryStories.ViewModel.Extensions;
using SmsManager.DataLayer.Dto;
using SmsManager.DataLayer.Repositories.Base;
using SmsManager.Services.Base;
using SmsManager.Visual.ViewModels.Contracts;
using SmsManager.Visual.Views;

namespace SmsManager.Visual.ViewModels
{
    [ViewModel(typeof(ContactChooseView))]
    public class ContactChooseViewModel:ViewModelBase, IContactChooseViewModel
    {
        public string ChoosedMessageText { get; set; }

        private List<AlphaKeyGroup<ContactDto>> _contacts;
        private ContactDto _selectedContact;

        private readonly IContactRepository _contactRepository;
        private readonly INavigationService _navigationService;
        private readonly ISmsSenderService _smsSenderService;


        [Injection]
        public ContactChooseViewModel(IContactRepository contactRepository,INavigationService navigationService){
            _contactRepository = contactRepository;
            _navigationService = navigationService;
        }


        private List<AlphaKeyGroup<ContactDto>> ConvertToGroupedList(IEnumerable<ContactDto> contacts)
        {
           var  alphaContact = AlphaKeyGroup<ContactDto>.CreateGroups(
           contacts,
           CultureInfo.CurrentCulture,
           (ContactDto s) => { return s.DisplayName.ElementAt(0).ToString().ToLower(); }, true);
            return alphaContact;
        }

        public override void InitalizeData(){
           var contacts=_contactRepository.GetAll().ToList();
            Contacts=ConvertToGroupedList(contacts);
            base.InitalizeData();
        }

        public List<AlphaKeyGroup<ContactDto>> Contacts
        {
            get { return _contacts; }
            set
            {
                _contacts = value;
                base.RaisePropertyChanged(() => Contacts);
            }
        }

        public ContactDto SelectedContact
        {
            get { return _selectedContact; }
            set
            {
                _selectedContact = value;
                if (value != null)
                {
                    NavigateOnTelephoneKindChooser();
                }
                base.RaisePropertyChanged(()=>SelectedContact);
            }
        }

        private void NavigateOnTelephoneKindChooser()
        {
            _navigationService.UriFor<TelephoneKindChooseViewModel>().WithParam(x=>x.SelectedContactId,this.SelectedContact.Id).WithParam(y=>y.ChoosedMessageText,ChoosedMessageText).Navigate();
        }
    }
}
