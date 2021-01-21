using System;

namespace ClimaControl.UI.UICore.Themes
{
    public class GenericTheme : Theme
    {
        public override Uri GetResourceUri()
        {
            string uri;
            uri = "Xceed.Wpf.AvalonDock";

            return new Uri("/" + uri + ";component/Themes/generic.xaml", UriKind.Relative);
        }
    }
}