using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace jcFUS.UWP.ViewModels {
    public class RegisterModel : INotifyPropertyChanged {
        private string _displayName;

        public string DisplayName {
            get { return _displayName; }

            set {
                _displayName = value;
                OnPropertyChanged();
                RegisterEnabled = formValidated();
            }
        }

        private string _emailAddress;

        public string EmailAddress {
            get { return _emailAddress; }
            set {
                _emailAddress = value;
                OnPropertyChanged();
                RegisterEnabled = formValidated();
            }
        }

        private string _password;

        public string Password {
            get { return _password; }
            set {
                _password = value;
                OnPropertyChanged();
                RegisterEnabled = formValidated();
            }
        }

        private bool _registerEnabled;

        public bool RegisterEnabled {  get { return _registerEnabled; } set { _registerEnabled = value; OnPropertyChanged(); } }

        private bool formValidated()
            =>
                !string.IsNullOrEmpty(EmailAddress) && !string.IsNullOrEmpty(Password) &&
                !string.IsNullOrEmpty(DisplayName);

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}