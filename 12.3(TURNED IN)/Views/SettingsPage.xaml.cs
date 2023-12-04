using System;

using Demo5.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

using Windows.Media.Playback;
using Windows.Media.Core;
using Demo5.Helpers;
using Windows.Media.Playback;
using Windows.Media.Core;


namespace Demo5.Views
{
    // URL for privacy policy in the Resource File, currently set to https://YourPrivacyUrlGoesHere
    public sealed partial class SettingsPage : Page
    {
        public SettingsViewModel ViewModel { get; } = new SettingsViewModel();
        public Music Music2 { get; set; }
      
        public SettingsPage()
        {
            InitializeComponent();
        }
        
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await ViewModel.InitializeAsync();
        }

        private void Music_Toggled(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var app = (App)App.Current;
            Music2 = app.GetMusic();
            if(MusicSwitch.IsOn == true)
            {
                Music2.player.Play();
            }
            else
            {
                Music2.player.Pause();
            }

        }
    }
}
