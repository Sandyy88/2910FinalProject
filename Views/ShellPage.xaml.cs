using _06CorePlayer.ViewModels;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace _06CorePlayer.Views
{
        /// <summary>
        /// An empty page that can be used on its own or navigated to within a Frame.
        /// </summary>
        // TODO: Change the icons and titles for all NavigationViewItems in ShellPage.xaml.
        public sealed partial class ShellPage : Page
        {
            public ShellViewModel ViewModel { get; } = new ShellViewModel();

            public ShellPage()
            {
                this.InitializeComponent();
                DataContext = ViewModel;
                ViewModel.Initialize(shellFrame, navigationView, KeyboardAccelerators);
            }
        }
}
