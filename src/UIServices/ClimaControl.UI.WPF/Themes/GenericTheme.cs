using System;
using ClimaControl.UI.UICore.Themes;

namespace ClimaControl.UI.WPF.Themes
{
    public class GenericTheme : Theme
    {
        public override Uri GetResourceUri()
        {
            string uri;
            uri = "ClimaControl.UI.WPF";

            return new Uri("/" + uri + ";component/Themes/generic.xaml", UriKind.Relative);
        }
    }
}