using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using jcFUS.UWP.ViewModels;
using Microsoft.AspNet.SignalR.Client;

namespace jcFUS.UWP.Views {
    public sealed partial class RegisterPage : Page {
        private RegisterModel viewModel => (RegisterModel)DataContext;

        public RegisterPage() {
            this.InitializeComponent();

            DataContext = new RegisterModel();
        }

        private void btnSubmit_OnClick(object sender, RoutedEventArgs e) {
                
        }

        private void btnCancel_OnClick(object sender, RoutedEventArgs e) {
            Frame.GoBack();
        }
    }
}