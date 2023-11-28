using System;

using Demo4.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Demo4.Views
{
    public sealed partial class QueuePage : Page
    {
        public QueueViewModel ViewModel { get; } = new QueueViewModel();

        public QueuePage()
        {
            InitializeComponent();
        }
    }
}
