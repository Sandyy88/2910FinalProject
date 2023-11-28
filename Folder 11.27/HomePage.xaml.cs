using System;

using Windows.System;
using Windows.UI.Xaml;
using Demo4.ViewModels;
using Windows.UI.Xaml.Controls;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;
using Demo4.Helpers;
using Windows.Web.Http;
using Windows.Security.Authentication.Web;


namespace Demo4.Views
{
    public sealed partial class HomePage : Page
    {
        private SpotifyService spotifyService;

        public HomeViewModel ViewModel { get; } = new HomeViewModel();

        public HomePage()
        {
            InitializeComponent();
            spotifyService = new SpotifyService();
            CheckLoginStatus();
        }

        private async void CheckLoginStatus()
        {
            if (IsLoggedIn())
            {
                var email = await spotifyService.GetUserProfileEmail();
                DisplayUserProfile(email);
            }
            else
            {
                DisplayLoginButton();
            }
        }

        private bool IsLoggedIn()
        {
            // Implement your logic to check if the user is logged in
            return !string.IsNullOrEmpty(spotifyService.GetAccessToken());
        }

        private void DisplayLoginButton()
        {
            // Implement UI to display "Login with Spotify" button
            loginButton.Visibility = Visibility.Visible;
        }

        private void DisplayUserProfile(string email)
        {
            // Implement UI to display user profile
            userEmailTextBlock.Text = $"User Email: {email}";
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var authUrl = spotifyService.GetAuthorizationUrl();
            // Open the user's default web browser to authorize the app
            var success = await Windows.System.Launcher.LaunchUriAsync(new Uri(authUrl));

            //string redirectedurl = HttpContext.Current.Request.Url.AbsoluteUri;
            //HandleRedirectUri(redirectedurl);

            if (!success)
            {
                // Handle the case where the browser couldn't be launched
                Console.WriteLine("ERROR: BROWSER COULD NOT BE LAUCHED. PLEASE RESTART THE APP.");
            }

            // Launch the system browser to handle the authentication
            var startUri = new Uri(authUrl);
            var endUri = new Uri(spotifyService.GetRedirectUri());

            try
            {
                var result = await WebAuthenticationBroker.AuthenticateAsync(
                    WebAuthenticationOptions.None,
                    startUri,
                    endUri
                );

                // Check the result
                if (result.ResponseStatus == WebAuthenticationStatus.Success)
                {
                    // Handle the successful authentication
                    HandleRedirectUri(result.ResponseData);
                }
                else if (result.ResponseStatus == WebAuthenticationStatus.ErrorHttp)
                {
                    // Handle HTTP error
                }
                else
                {
                    // Handle other errors
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
            }
        }

        private async void HandleRedirectUri(string redirectUri)
        {
            var uri = new Uri(redirectUri);
            var code = uri.Query.Substring(6); // Assuming the code is in the query string like "?code=xxx"

            if (await spotifyService.ExchangeCodeForToken(code)) 
            {
                CheckLoginStatus();
            }
            else
            {
                // Handle authentication failure
            }
        }
    }
}
