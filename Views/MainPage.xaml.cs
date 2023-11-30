using _06CorePlayer.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Controls;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;
using System.Diagnostics;
using Windows.Storage.Streams;
using Windows.UI;
using Microsoft.UI.Xaml.Media;
using Microsoft.Xaml.Interactivity;
using Windows.UI.Composition;
using Windows.Media.Devices;
using Microsoft.Toolkit.Uwp.UI;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace _06CorePlayer.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            this.InitializeComponent();
            MainPage_Loaded();
        }

        public void MainPage_Loaded()
        {

        }

    }
}
