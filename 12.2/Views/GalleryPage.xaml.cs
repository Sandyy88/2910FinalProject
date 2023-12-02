using System;

using Demo5.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Demo5.Views
{
    public sealed partial class GalleryPage : Page
    {
        public GalleryViewModel ViewModel { get; } = new GalleryViewModel();

        public GalleryPage()
        {
            InitializeComponent();
        }
    }
}
