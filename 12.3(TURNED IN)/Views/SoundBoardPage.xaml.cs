using System;

using Demo5.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.Media.Playback;
using Windows.Media.Core;
using Demo5.Helpers;
using Windows.UI.Xaml.Navigation;

namespace Demo5.Views
{
    public sealed partial class SoundBoardPage : Page
    {
        public SoundBoardViewModel ViewModel { get; } = new SoundBoardViewModel();

        public Music Music;

        MediaPlayer player;
        public SoundBoardPage()
        {
            InitializeComponent();
            player = new MediaPlayer();
        }

        private async void PlaySound(string soundFileName)
        {
            Windows.Storage.StorageFolder folder = await
                Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets\SoundBoardStuff");
            Windows.Storage.StorageFile file = await folder.GetFileAsync(soundFileName);

            player.Source = MediaSource.CreateFromStorageFile(file);
            player.Play();
            player.AutoPlay = false;
            player.IsLoopingEnabled = false;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var app = (App)App.Current;
            Music = app.GetMusic();
            Music.player.Pause();
            base.OnNavigatedTo(e);
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            var app = (App)App.Current;
            Music = app.GetMusic();
            Music.player.Play();
            base.OnNavigatedFrom(e);
        }

        private void Button1_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            PlaySound("DialUp.mp3");
        }

        private void Button2_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            PlaySound("Classic Old Walt Disney Castle Intro.mp3");
        }

        private void Button3_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            PlaySound("Disney DVD Title with Tinkerbell intro.mp3");
        }

        private void Button4_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            PlaySound("Disneys Fast Play 2006.mp3");
        }

        private void Button5_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            PlaySound("The fitness gram pacer test sound effect.mp3");
        }

        private void Button6_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            PlaySound("Microsoft Windows XP Startup Sound.mp3");
        }
        private void Button7_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            PlaySound("Wii Sports  Groan Sound Effect.mp3");
        }
        private void Button8_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            PlaySound("Wii Sports Baseball  Foul Ball Sound Effect.mp3");
        }
    }
}
