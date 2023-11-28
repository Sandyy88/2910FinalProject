using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Demo4.Helpers
{
    public class SpotifyService
    {
        private const string ClientId = "451fee1cb11140ce922adde3b11e95c7";
        private const string ClientSecret = "0d24f9ab75794bef8491b00b63e2350e\r\n";
        private const string RedirectUri = "https://www.coolmathgames.com/";

        private const string AuthorizationEndpoint = "https://accounts.spotify.com/authorize";
        private const string TokenEndpoint = "https://accounts.spotify.com/api/token";
        private const string UserProfileEndpoint = "https://api.spotify.com/v1/me";

        private string accessToken;
        private string refreshToken;

        public string GetRedirectUri()
        {
            return RedirectUri;
        }
        public string GetAuthorizationUrl()
        {
            var state = Guid.NewGuid().ToString("N");
            var scope = "user-read-email"; // Add more scopes as needed

            var authUrl = $"{AuthorizationEndpoint}?client_id={ClientId}&response_type=code&redirect_uri={Uri.EscapeDataString(RedirectUri)}&scope={Uri.EscapeDataString(scope)}&state={state}";

            return authUrl;
        }

        public async Task<bool> ExchangeCodeForToken(string code)
        {
            using (var client = new HttpClient())
            {

                var tokenRequest = new
                {
                    code,
                    redirect_uri = RedirectUri,
                    grant_type = "authorization_code",
                    client_id = ClientId,
                    client_secret = ClientSecret
                };

                var content = new StringContent(JsonConvert.SerializeObject(tokenRequest), Encoding.UTF8, "application/json");

                var response = await client.PostAsync(TokenEndpoint, content);

                if (response.IsSuccessStatusCode)
                {
                    var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(await response.Content.ReadAsStringAsync());

                    accessToken = tokenResponse.AccessToken;
                    refreshToken = tokenResponse.RefreshToken;

                    return true;
                }

                return false;
            }
        }

        public string GetAccessToken()
        {
            return accessToken;
        }

        public async Task<string> GetUserProfileEmail()
        {
            if (string.IsNullOrEmpty(accessToken))
                throw new InvalidOperationException("Access token is not available.");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

                var response = await client.GetStringAsync(UserProfileEndpoint);

                Debug.WriteLine($"User Profile Response: {response}");

                var userProfile = JsonConvert.DeserializeObject<UserProfile>(response);

                return userProfile.Email;
            }
        }

        public async Task<bool> RefreshToken()
        {
            if (string.IsNullOrEmpty(refreshToken))
                throw new InvalidOperationException("Refresh token is not available.");

            using (var client = new HttpClient())
            {
                var tokenRequest = new
                {
                    refresh_token = refreshToken,
                    grant_type = "refresh_token",
                    client_id = ClientId,
                    client_secret = ClientSecret
                };

                var content = new StringContent(JsonConvert.SerializeObject(tokenRequest), Encoding.UTF8, "application/json");

                var response = await client.PostAsync(TokenEndpoint, content);

                if (response.IsSuccessStatusCode)
                {
                    var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(await response.Content.ReadAsStringAsync());

                    accessToken = tokenResponse.AccessToken;
                    refreshToken = tokenResponse.RefreshToken;

                    return true;
                }

                return false;
            }
        }
    }
}
