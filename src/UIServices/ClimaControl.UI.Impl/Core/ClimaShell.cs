using System.Collections.Generic;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ClimaControl.Data.Security.Exceptions;
using ClimaControl.UI.Impl.Core.Installers;
using ClimaControl.UI.Services;
using ClimaControl.UI.Services.Configuration;
using ClimaControl.UI.Services.Configuration.Model;
using ClimaControl.UI.UICore.Dialogs;
using ClimaControl.UI.UICore.Dialogs.Models.Security;
using ClimaControl.UI.UICore.Themes;
using ClimaControl.UI.UICore.Views;

namespace ClimaControl.UI.Impl.Core
{
    public class ClimaShell:IShell
    {
        private string _title;
        private IMainView _mainView;
        private IWindsorContainer _iocContainer;

        private bool _isLogin;
        private IEnumerable<Theme> _shellThemes;

        public ClimaShell()
        {
            _iocContainer = new WindsorContainer();
            _iocContainer.Install(new RepositoryInstaller());
            _iocContainer.Install(new GenericInstaller());
            _iocContainer.Install(new MVVMInstaller());

            _iocContainer.Register(Component.For<IShell>().Instance(this).LifestyleSingleton());


            var configService = _iocContainer.Resolve<IConfigurationService>();

           //var item1 = configService.CreateConfiguration<TestConfigItem>();

            //TestConfigItem item1 = new TestConfigItem("TestItem1");
            //TestConfigItem item2 = new TestConfigItem("TestItem2");
            //TestConfigItem item21 = new TestConfigItem("TestItem21");
            //item2.AddChild(item21);

            //configService.
            _isLogin = false;
        }


        public string Title
        {
            get => _title;
            set => _title = value;
        }

        public IMainView MainView
        {
            get
            {
                
                    return _iocContainer.Resolve<IMainView>();
                
            }
        } 
        public T CreateDialog<T>() where T:IDialog
        {
            return _iocContainer.Resolve<T>();
        }

        public T CreateView<T>() where T : IView
        {
            return _iocContainer.Resolve<T>();
        }
        public bool Login()
        {
            var loginDialog = _iocContainer.Resolve<ILoginDialog>();
            bool retval = false;
            if (loginDialog != null)
            {
                if (loginDialog.ShowDialog() == true)
                {
                    var user = loginDialog.User;
                    retval = _iocContainer.Resolve<ISecurityService>().ValidateUser(user);
                    _isLogin = true;
                }
                else
                {
                    retval = false;
                    _isLogin = false;
                }
            }
            return retval;
        }

        public bool IsLogin { get; }

        public IEnumerable<Theme> ShellThemes => _iocContainer.Resolve<IThemeService>().InstalledThemes;
        public void SetShellTheme(Theme theme)
        {
            _iocContainer.Resolve<IThemeService>().LoadTheme(theme);
        }
    }
}