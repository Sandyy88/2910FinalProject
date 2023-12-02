using System;

using Demo5.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Demo5.Views
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
