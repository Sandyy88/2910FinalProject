using System;

using Demo5.ViewModels;

using Windows.UI.Xaml.Controls;

using Windows.Media.Playback;
using Windows.Media.Core;
using System.ServiceModel;
using Demo5.Helpers;
using Windows.UI.Xaml.Navigation;

namespace Demo5.Views
{
    public sealed partial class TubePage : Page
    {
        public TubeViewModel ViewModel { get; } = new TubeViewModel();

        public Music Music;

        public TubePage()
        {
            InitializeComponent();
            ViewModel.Initialize(webView);
            
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
    }
}
