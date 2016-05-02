using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using jcFUS.PCL.Handlers;
using jcFUS.PCL.Transports.Auth;

namespace jcFUS.UWP.ViewModels {
    public class LoginPageModel : INotifyPropertyChanged {
        private string _emailAddress;

        public string EmailAddress {
            get { return _emailAddress; }
            set { _emailAddress = value; OnPropertyChanged(); }
        }

        private string _password;

        public string Password {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }

        public async Task<AuthResponseItem> AttemptLogin() {
            var authHandler = new AuthHandler();

            var result = await authHandler.CheckAuthAsync(new AuthRequestItem {
                Username = EmailAddress,
                Password = this.Password
            });

            return result;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}