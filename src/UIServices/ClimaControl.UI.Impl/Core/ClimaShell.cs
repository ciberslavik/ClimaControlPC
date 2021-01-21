using Castle.Windsor;
using ClimaControl.UI.Impl.Core.Installers;
using ClimaControl.UI.UICore.Views;

namespace ClimaControl.UI.Impl.Core
{
    public class ClimaShell:IShell
    {
        private string _title;
        private IMainView _mainView;
        private IWindsorContainer _iocContainer;
        public ClimaShell()
        {
            _iocContainer = new WindsorContainer();
            _iocContainer.Install(new MVVMInstaller());

            _mainView = _iocContainer.Resolve<IMainView>();


        }


        public string Title
        {
            get => _title;
            set => _title = value;
        }

        public IMainView MainView => _iocContainer.Resolve<IMainView>();
        public T CreateDialog<T>()
        {
            return _iocContainer.Resolve<T>();
        }
    }
}