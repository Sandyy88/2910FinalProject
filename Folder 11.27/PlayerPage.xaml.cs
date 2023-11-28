using System;

using Demo4.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Demo4.Views
{
    public sealed partial class PlayerPage : Page
    {
        public PlayerViewModel ViewModel { get; } = new PlayerViewModel();

        public PlayerPage()
        {
            InitializeComponent();
        }
    }
}
