using System;

using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using jcFUS.UWP.ViewModels;

namespace jcFUS.UWP {
    public sealed partial class LoginPage : Page {
        private LoginPageModel viewModel => (LoginPageModel) DataContext;

        public LoginPage() {
            this.InitializeComponent();

            DataContext = new LoginPageModel();
        }

        private async void btnLogin_Clicked(object sender, RoutedEventArgs e) {
            var result = await viewModel.AttemptLogin();

            if (result == null) {
                await new MessageDialog("Invalid username or password").ShowAsync();

                return;
            }

            App.CURRENT_USER = result;

            Frame.Navigate(typeof (MainPage));
        }
    }
}