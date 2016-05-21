using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using jcFUS.UWP.ViewModels;

namespace jcFUS.UWP {
    public sealed partial class RegisterPage : Page {
        private RegisterModel viewModel => (RegisterModel)DataContext;

        public RegisterPage() {
            this.InitializeComponent();
        }

        private void btnSubmit_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnCancel_OnClick(object sender, RoutedEventArgs e) {
            Frame.GoBack();
        }
    }
}