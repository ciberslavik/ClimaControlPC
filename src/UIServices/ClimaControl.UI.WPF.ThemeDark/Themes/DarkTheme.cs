using System;
using ClimaControl.UI.UICore.Themes;

namespace ClimaControl.UI.WPF.ThemeDark.Themes
{
    public class DarkTheme:Theme
    {
        public override Uri GetResourceUri()
        {
            string uri = "ClimaControl.UI.WPF.ThemeDark";

            return new Uri("/" + uri + ";component/Themes/DarkTheme.xaml", UriKind.Relative);
        }
    }
}