using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace jcFUS.UWP {

    sealed partial class App : Application {
        public App() {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        private void LoadTheme() {
            var mainColor = Color.FromArgb(0xFF, 0x2e, 0x2e, 0x2e);
            var actionColor = Color.FromArgb(0xFF, 0x4e, 0x4e, 0x4e);
            
            var AppView = ApplicationView.GetForCurrentView();

            AppView.TitleBar.ButtonInactiveBackgroundColor = mainColor;
            AppView.TitleBar.ButtonInactiveForegroundColor = mainColor;
            AppView.TitleBar.ButtonBackgroundColor = actionColor;
            AppView.TitleBar.ButtonForegroundColor = mainColor;

            AppView.TitleBar.ButtonHoverBackgroundColor = mainColor;
            AppView.TitleBar.ButtonHoverForegroundColor = actionColor;

            AppView.TitleBar.ButtonPressedBackgroundColor = actionColor;
            AppView.TitleBar.ButtonPressedForegroundColor = mainColor;

            AppView.TitleBar.BackgroundColor = mainColor;
            AppView.TitleBar.ForegroundColor = actionColor;
        }
        
        protected override void OnLaunched(LaunchActivatedEventArgs e) {
            var rootFrame = Window.Current.Content as Frame;
            
            LoadTheme();

            if (rootFrame == null) {
                rootFrame = new Frame();
                
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false) {
                if (rootFrame.Content == null) {
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }

                Window.Current.Activate();
            }
        }

        private void OnSuspending(object sender, SuspendingEventArgs e) {
            var deferral = e.SuspendingOperation.GetDeferral();

            deferral.Complete();
        }
    }
}