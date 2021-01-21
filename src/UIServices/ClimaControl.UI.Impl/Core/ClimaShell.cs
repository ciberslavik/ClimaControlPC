using Castle.Windsor;
using ClimaControl.Data.Security.Exceptions;
using ClimaControl.UI.Impl.Core.Installers;
using ClimaControl.UI.Services;
using ClimaControl.UI.UICore.Dialogs.Models.Security;
using ClimaControl.UI.UICore.Views;

namespace ClimaControl.UI.Impl.Core
{
    public class ClimaShell:IShell
    {
        private string _title;
        private IMainView _mainView;
        private IWindsorContainer _iocContainer;

        private bool _isLogin;
        public ClimaShell()
        {
            _iocContainer = new WindsorContainer();
            _iocContainer.Install(new RepositoryInstaller());
            _iocContainer.Install(new GenericInstaller());
            _iocContainer.Install(new MVVMInstaller());

            _mainView = _iocContainer.Resolve<IMainView>();
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
                if (_isLogin)
                    return _iocContainer.Resolve<IMainView>();
                else
                {
                    throw new SecurityException("System not login before MainWindow resolve");
                }
            }
        } 
        public T CreateDialog<T>()
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
    }
}