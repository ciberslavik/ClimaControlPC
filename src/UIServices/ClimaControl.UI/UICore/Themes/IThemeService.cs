using System.Collections.Generic;

namespace ClimaControl.UI.UICore.Themes
{
    public interface IThemeService
    {
        IEnumerable<Theme> InstalledThemes { get; }
        void LoadTheme(Theme theme);
        Theme CurrentTheme { get; }
    }
}