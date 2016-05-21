using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace jcFUS.UWP.ViewModels {
    public class RegisterModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}