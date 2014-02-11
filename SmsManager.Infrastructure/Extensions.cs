using System;
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

namespace SmsManager.Infrastructure
{
    public static class Extensions
    {
        public static BitmapSource GetUnknownPersonImage()
        {
            BitmapImage tn = new BitmapImage();
            tn.SetSource(Application.GetResourceStream(new Uri("SmsManager.Infrastructure;component/Content/Images/unknown.png", UriKind.Relative)).Stream);
            return tn;
        }
    }
}
