using System;
using System.Linq;

using Windows.System;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

using jcFUS.UWP.ViewModels;

namespace jcFUS.UWP {
    public sealed partial class MainPage : Page {
        private MainPageModel viewModel => (MainPageModel)DataContext;

        public MainPage() {
            this.InitializeComponent();

            DataContext = new MainPageModel();
        }

        private async void UIElement_OnKeyUp(object sender, KeyRoutedEventArgs e) {
            if (e.Key != VirtualKey.Enter) {
                return;
            }

            var result = await viewModel.SubmitChat();

            if (!result) {
                await new MessageDialog("Message was not sent").ShowAsync();
            }

            var lastItem = lvChat.Items.LastOrDefault();

            lvChat.ScrollIntoView(lastItem, ScrollIntoViewAlignment.Default);
        }
    }
}