using System;

using Demo4.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Demo4.Views
{
    public sealed partial class SignInPage : Page
    {
        public SignInViewModel ViewModel { get; } = new SignInViewModel();

        public SignInPage()
        {
            InitializeComponent();
            ViewModel.Initialize(webView);
        }
    }
}
