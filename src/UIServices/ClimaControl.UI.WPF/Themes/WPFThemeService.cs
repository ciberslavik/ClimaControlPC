﻿using System.Collections.Generic;
using System.Windows;
using ClimaControl.UI.UICore.Themes;

namespace ClimaControl.UI.WPF.Themes
{
    public class WPFThemeService:IThemeService
    {
        private readonly Theme[] _themes;

        public WPFThemeService(Theme[] themes)
        {
            _themes = themes;
        }
        public IEnumerable<Theme> InstalledThemes { get; }
        public void LoadTheme(Theme theme)
        {
            var themeDict = Application.LoadComponent(theme.GetResourceUri()) as ResourceDictionary;
            if (themeDict != null)
            {
                // очищаем коллекцию ресурсов приложения
                Application.Current.Resources.Clear();
                // добавляем загруженный словарь ресурсов
                Application.Current.Resources.MergedDictionaries.Add(themeDict);
            }
        }

        public Theme CurrentTheme { get; }
    }
}