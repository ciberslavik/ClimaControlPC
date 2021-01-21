using System;

namespace ClimaControl.UI.UICore.Themes
{
    public abstract class Theme
    {
        public Theme()
        {
        }
        public abstract Uri GetResourceUri();
    }
}