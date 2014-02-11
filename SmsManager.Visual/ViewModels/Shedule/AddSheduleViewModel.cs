using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using Phone7.Fx.Ioc;
using Phone7.Fx.Mvvm;
using Phone7.Fx.Navigation;
using SmsManager.Infrastructure;
using SmsManager.Visual.Models;
using SmsManager.Visual.ViewModels.CategorySms;
using SmsManager.Visual.Views.Shedule;

namespace SmsManager.Visual.ViewModels.Shedule
{
    [ViewModel(typeof(AddSheduleView))]
    public class AddSheduleViewModel:ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly INewShedule _newShedule;
        private int _selectedId;

        [Injection]
        public AddSheduleViewModel(INavigationService navigationService,INewShedule newShedule){
                _navigationService = navigationService;
                _newShedule = newShedule;
        }

        public ImageSource AccountImage{
            get{
                if (_newShedule.ContactDto != null){
                    return _newShedule.ContactDto.BitmapImage;
                }
                return Extensions.GetUnknownPersonImage();
            }
        }
        public string AccountName{
            get{
                if (_newShedule.ContactDto != null){
                    return _newShedule.ContactDto.DisplayName;
                }
                else{
                    return "Выберите контакт";
                }
            }
        }

        public string Telephone{
            get{
                if (_newShedule.Telephone != null){
                    return _newShedule.Telephone.TelephoneNumber.ToString();
                }
                return "Выберите телефон";
            }
        }

        public int SelectedId{
            get { return _selectedId; }
            set{
                _selectedId = value;
                DoActionForSelectedItem(value);
                base.RaisePropertyChanged(()=>SelectedId);
            }
        }

        private void DoActionForSelectedItem(int value){
            switch (value){
                case 0:
                    GetContact();
                    break;
                   
                case 1:
                    GetTelephoneKind();
                    break;
            }
        }

        private void GetTelephoneKind(){
            if(_newShedule.ContactDto!=null)
                _navigationService.UriFor<NewSheduleTelephoneKindChooserViewModel>().WithParam(x => x.SelectedContactId, _newShedule.ContactDto.Id).Navigate();
        }

        private void GetContact(){
            _navigationService.UriFor<NewSheduleContactChooseViewModel>().Navigate();
        }
    }

}
