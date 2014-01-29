using System;
using System.IO;
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
using SmsManager.Infrastructure.Entities.Dto;

namespace SmsManager.DataLayer.Dto
{
    public class ContactDto:IDto
    {
        public long Id { get; set; }
        public string DisplayName { get; set; }
        public DateTime BirthdayDate { get; set; }
        public string EmailAddress { get; set; }
        public byte[] Photo { get; set; }
        public string HomeTelephone { get; set; }
        public string MobileTelephone { get; set; }
        public string WorkTelephone { get; set; }


        public BitmapSource BitmapImage{
            get{
                if (Photo != null){
                    using (MemoryStream stream = new MemoryStream(Photo)){
                        BitmapImage image = new BitmapImage();
                        image.SetSource(stream);
                        return image;
                    }
                }
                else{
                    return null;
                }
            }
        }
    }
}
