using System;

using Demo5.ViewModels;
using Windows.System;
using Windows.UI.Xaml.Controls;

namespace Demo5.Views
{
    public sealed partial class MemoriesPage : Page
    {
        public MemoriesViewModel ViewModel { get; } = new MemoriesViewModel();

        public MemoriesPage()
        {
            InitializeComponent();
        }


        private async void button1_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            string urlToLaunch = "https://myspace.com/signin";

            // Launch the default web browser with the specified URL
            var success = await Launcher.LaunchUriAsync(new Uri(urlToLaunch));

            if (!success)
            {
                Console.WriteLine("ERROR WITH URL.");
            }
        }

        private async void button2_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            string urlToLaunch = "https://www.coolmathgames.com/";

            // Launch the default web browser with the specified URL
            var success = await Launcher.LaunchUriAsync(new Uri(urlToLaunch));

            if (!success)
            {
                Console.WriteLine("ERROR WITH URL.");
            }
        }
        private async void button3_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            string urlToLaunch = "https://www.poptropica.com/haxe/play/";

            // Launch the default web browser with the specified URL
            var success = await Launcher.LaunchUriAsync(new Uri(urlToLaunch));

            if (!success)
            {
                Console.WriteLine("ERROR WITH URL.");
            }
        }

        private async void button4_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            string urlToLaunch = "https://disneynow.com/all-games";

            // Launch the default web browser with the specified URL
            var success = await Launcher.LaunchUriAsync(new Uri(urlToLaunch));

            if (!success)
            {
                Console.WriteLine("ERROR WITH URL.");
            }
        }

        private async void button5_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            string urlToLaunch = "https://www.starfall.com/h/";

            // Launch the default web browser with the specified URL
            var success = await Launcher.LaunchUriAsync(new Uri(urlToLaunch));

            if (!success)
            {
                Console.WriteLine("ERROR WITH URL.");
            }
        }

        private async void button6_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            string urlToLaunch = "https://www.numuki.com/games/my-scene/";

            // Launch the default web browser with the specified URL
            var success = await Launcher.LaunchUriAsync(new Uri(urlToLaunch));

            if (!success)
            {
                Console.WriteLine("ERROR WITH URL.");
            }
        }

        private async void button7_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            string urlToLaunch = "https://www.stardoll.com/en/";

            // Launch the default web browser with the specified URL
            var success = await Launcher.LaunchUriAsync(new Uri(urlToLaunch));

            if (!success)
            {
                Console.WriteLine("ERROR WITH URL.");
            }
        }

        private async void button8_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            string urlToLaunch = "https://www.roblox.com/NewLogin";

            // Launch the default web browser with the specified URL
            var success = await Launcher.LaunchUriAsync(new Uri(urlToLaunch));

            if (!success)
            {
                Console.WriteLine("ERROR WITH URL.");
            }
        }

        private async void button9_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            string urlToLaunch = "https://cpchapter2.com/";

            // Launch the default web browser with the specified URL
            var success = await Launcher.LaunchUriAsync(new Uri(urlToLaunch));

            if (!success)
            {
                Console.WriteLine("ERROR WITH URL.");
            }
        }
    }
}
