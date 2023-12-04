using System;

using Demo5.Services;

using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using System.Threading.Tasks;
using Demo5.Helpers;
using Windows.Media.Playback;
using Windows.Media.Core;

namespace Demo5
{
    public sealed partial class App : Application
    {
        private Lazy<ActivationService> _activationService;
        public Music Music2 { get; set; } = new Music(new MediaPlayer());
        private ActivationService ActivationService
        {
            get { return _activationService.Value; }
        }

        public App()
        {
            InitializeComponent();
            UnhandledException += OnAppUnhandledException;

            // Deferred execution until used. Check https://docs.microsoft.com/dotnet/api/system.lazy-1 for further info on Lazy<T> class.
            _activationService = new Lazy<ActivationService>(CreateActivationService);
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            if (!args.PrelaunchActivated)
            {
                await ActivationService.ActivateAsync(args);
            }

            //Sound
            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
            Windows.Storage.StorageFile file = await folder.GetFileAsync("Good Attitude Driving Guitar ClubPen.mp3");
            
            Music2.player.Source = MediaSource.CreateFromStorageFile(file);
            Music2.player.Play();
            Music2.player.AutoPlay = true;
            Music2.player.IsLoopingEnabled = true;
        }

        public Music GetMusic()
        {
            return Music2;
        }
        protected override async void OnActivated(IActivatedEventArgs args)
        {
            await ActivationService.ActivateAsync(args);
        }

        private void OnAppUnhandledException(object sender, Windows.UI.Xaml.UnhandledExceptionEventArgs e)
        {
            // For more info see https://docs.microsoft.com/uwp/api/windows.ui.xaml.application.unhandledexception
        }

        private ActivationService CreateActivationService()
        {
            return new ActivationService(this, typeof(Views.Gallery), new Lazy<UIElement>(CreateShell));
        }

        private UIElement CreateShell()
        {
            return new Views.ShellPage();
        }
    }
}
