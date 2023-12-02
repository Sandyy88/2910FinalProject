using System;

using Demo5.ViewModels;

using Windows.UI.Xaml.Controls;

using Windows.Media.Playback;
using Windows.Media.Core;
using System.ServiceModel;

namespace Demo5.Views
{
    public sealed partial class TubePage : Page
    {
        public TubeViewModel ViewModel { get; } = new TubeViewModel();

        public TubePage()
        {
            InitializeComponent();
            ViewModel.Initialize(webView);
            
        }
    }
}
