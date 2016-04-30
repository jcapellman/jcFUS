using System.Linq;

using Windows.System;
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

        private void UIElement_OnKeyUp(object sender, KeyRoutedEventArgs e) {
            if (e.Key != VirtualKey.Enter) {
                return;
            }

            viewModel.SubmitChat();

            var lastItem = lvChat.Items.LastOrDefault();

            lvChat.ScrollIntoView(lastItem, ScrollIntoViewAlignment.Default);
        }
    }
}