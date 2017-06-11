namespace Springboard365.Xrm.Authentication
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public class AuthenticationService : IAuthenticationService
    {
        private string url;
        private List<KeyValuePair<string, string>> requestParams;

        public async Task<Token> AcquireTokenAsync(string resource, string tenant, ClientCredentials clientCredentials, UserCredentials userCredentials)
        {
            requestParams = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("client_id", clientCredentials.ClientId),
                    new KeyValuePair<string, string>("client_secret", clientCredentials.ClientSecret),
                    new KeyValuePair<string, string>("resource", resource),
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", userCredentials.UserName),
                    new KeyValuePair<string, string>("password", userCredentials.Password)
                };

            url = string.Format("https://login.windows.net/{0}/oauth2/token", tenant);

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Cache-Control", "no-cache");

                using (var httpContent = new FormUrlEncodedContent(requestParams))
                {
                    using (var response = await httpClient.PostAsync(url, httpContent))
                    {
                        if (!response.IsSuccessStatusCode)
                        {
                            return null;
                        }

                        return JsonConvert.DeserializeObject<Token>(await response.Content.ReadAsStringAsync());
                    }
                }
            }
        }
    }
}