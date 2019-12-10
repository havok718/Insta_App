using System;
using System.Diagnostics;
using System.Globalization;
using Insta_App.Views;

namespace Insta_App
{
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.Instagram:
                    return new InstagramPageView();
                case ApplicationPage.Telephone:
                    return new TelephonePageView();
                case ApplicationPage.Calendar:
                    return new CalendarPageView();

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
