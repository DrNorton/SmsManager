using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Linq;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SmsManager.DataLayer.Entities;
using SmsManager.Infrastructure.Entities.Dto;

namespace SmsManager.DataLayer.Dto
{
    public class ContactDto:IDto
    {
        private string _displayName;
        public long Id { get; set; }

        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; }
        }

        public DateTime? BirthdayDate { get; set; }
        public string EmailAddress { get; set; }
        public byte[] Photo { get; set; }
        public IList<TelephoneDto> Telephones { get; set; }

        public ContactDto(Contact contact)
        {
            Id = contact.Id;
            DisplayName = contact.DisplayName;
            BirthdayDate = contact.BirthdayDate;
            EmailAddress = contact.EmailAddress;
            if (contact.Photo != null)
            {
                Photo = contact.Photo.ToArray();
            }
            Telephones=new List<TelephoneDto>();
            foreach (var telephone in contact.Telephones)
            {
                Telephones.Add(new TelephoneDto(telephone));
            }
        }

        public ContactDto()
        {
            Telephones=new List<TelephoneDto>();
            
        }
        

        public BitmapSource BitmapImage{
            get{
                if (Photo != null){
                    try
                    {
                        if (Photo.Count() == 0)
                        {
                            return GetUnknownPersonImage();
                        }
                        using (MemoryStream stream = new MemoryStream(Photo))
                        {
                            BitmapImage image = new BitmapImage();
                            image.SetSource(stream);
                            return image;
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e);
                        return null;
                    }
                }
                else{
                    return GetUnknownPersonImage();
                }
            }
        }

        private BitmapSource GetUnknownPersonImage()
        {
            BitmapImage tn = new BitmapImage();
            tn.SetSource(Application.GetResourceStream(new Uri(@"Content/Images/unknown.png", UriKind.Relative)).Stream);
            return tn;
        }

        public Contact ToEntityContact()
        {
            var contact = new Contact();
            contact.Id = this.Id;
            contact.DisplayName = this.DisplayName;
            contact.BirthdayDate = this.BirthdayDate;
            contact.EmailAddress = this.EmailAddress;
            contact.Photo = this.Photo;
            contact.Telephones=new EntitySet<Telephone>();
            foreach (var telephone in Telephones)
            {
                ConvertTelephoneDtoToEntity(contact,telephone);
            }
            return contact;
        }

        private static void ConvertTelephoneDtoToEntity(Contact targetEntity, TelephoneDto telephone)
        {
            targetEntity.Telephones.Add(new Telephone() { KindId = telephone.TelephoneKind.Id, TelephoneNumber = telephone.TelephoneNumber });
        }

    }
}
