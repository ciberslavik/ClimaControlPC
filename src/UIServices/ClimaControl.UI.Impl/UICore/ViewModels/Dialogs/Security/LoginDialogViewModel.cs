using System.Data;
using System.Security.Cryptography;
using System.Text;
using ClimaControl.Data;
using ClimaControl.Data.Security;
using ClimaControl.UI.Services;
using ClimaControl.UI.UICore;
using ClimaControl.UI.UICore.Dialogs;
using ClimaControl.UI.UICore.Dialogs.ViewModels.Security;

namespace ClimaControl.UI.Impl.UICore.ViewModels.Dialogs.Security
{
    public class LoginDialogViewModel:ObservableObject,ILoginDialogViewModel
    {
        private readonly ISecurityService _securityService;
        private User _user;
        private string _title;
        private string _errorString;
        public LoginDialogViewModel(ISecurityService securityService)
        {
            _securityService = securityService;
            AcceptDialogCommand = new RelayCommand((e) =>
            {
                var dialog = e as IDialogView;
                if (dialog != null)
                {
                    byte[] bytes = Encoding.ASCII.GetBytes(Password);
                    var md5 = new MD5CryptoServiceProvider();
                    var md5data = md5.ComputeHash(bytes);
                    User.PasswordHash = Encoding.ASCII.GetString(md5data);
                    if (_securityService.ValidateUser(User))
                    {
                        ErrorString = "Неверный Логин или Пароль!";
                        dialog.DialogResult = true;
                        dialog.Close();
                    }
                    else
                    {
                        ErrorString = "Неверный Логин или Пароль!";
                    }
                }
            });
        }
        public User User { get=>_user; set=>Update(ref _user,value); }
        public RelayCommand AcceptDialogCommand { get; }

        public string Password { get; set; }
        public string ErrorString { get=>_errorString; set=>Update(ref _errorString,value); }

        public string Title
        {
            get => _title;
            set => Update(ref _title, value);
        }

    }
}