using System;

using Demo5.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Demo5.Views
{
    public sealed partial class ExtraPage : Page
    {
        public ExtraViewModel ViewModel { get; } = new ExtraViewModel();

        public ExtraPage()
        {
            InitializeComponent();
        }
    }
}
