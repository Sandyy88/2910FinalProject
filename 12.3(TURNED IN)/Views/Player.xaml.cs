using Demo5.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Enumeration.Pnp;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Storage.Pickers;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Demo5.Helpers;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Demo5.Views
{
    public sealed partial class Player : Page
    {
        public MemoriesViewModel ViewModel { get; } = new MemoriesViewModel();

        private int likes = 0;

        public Music Music;

        public Player()
        {
            this.InitializeComponent();

            //This following line is setting the source for the MediaPlayerElement
            
        }

        private async void CustomMTC_Liked(object sender, EventArgs e)
        {
            var messageDialog = new MessageDialog("You liked this video " + (++likes) + " times.");
            await messageDialog.ShowAsync();
        }

        private async void PickFile(object sender, EventArgs e)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
            {
                FileOpenPicker filePicker = new FileOpenPicker();

                filePicker.FileTypeFilter.Add(".mp4");
                filePicker.FileTypeFilter.Add(".wav");
                filePicker.FileTypeFilter.Add(".mp3");
                filePicker.SuggestedStartLocation = PickerLocationId.MusicLibrary;

                StorageFile file = await filePicker.PickSingleFileAsync();
                MediaSource source;

                if (file != null)
                {
                    source = MediaSource.CreateFromStorageFile(file);
                    MainMPE.Source = source;
                }
            });
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
            if (MainMPE.Source != null)
            {
                MainMPE.MediaPlayer.Pause();
            }
            var app = (App)App.Current;
            Music = app.GetMusic();
            Music.player.Play();
            base.OnNavigatedFrom(e);
        }


    }
}
