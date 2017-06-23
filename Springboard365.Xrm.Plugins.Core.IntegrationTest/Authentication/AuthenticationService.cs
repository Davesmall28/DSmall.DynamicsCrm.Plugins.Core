namespace Springboard365.Xrm.Authentication
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using log4net;
    using Newtonsoft.Json;

    public class AuthenticationService : IAuthenticationService
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(AuthenticationService));

        public async Task<Token> AcquireTokenAsync(string resource, string tenant, ClientCredentials clientCredentials, UserCredentials userCredentials)
        {
            var requestParams = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("client_id", clientCredentials.ClientId),
                    new KeyValuePair<string, string>("client_secret", clientCredentials.ClientSecret),
                    new KeyValuePair<string, string>("resource", resource),
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", userCredentials.UserName),
                    new KeyValuePair<string, string>("password", userCredentials.Password)
                };

            var url = string.Format("https://login.windows.net/{0}/oauth2/token", tenant);

            LogRequestParams(requestParams);
            logger.DebugFormat("Oauth Token Url: {0}", url);

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Cache-Control", "no-cache");

                using (var httpContent = new FormUrlEncodedContent(requestParams))
                {
                    using (var response = await httpClient.PostAsync(url, httpContent))
                    {
                        logger.DebugFormat("Response Status Code: {0}", response.StatusCode);

                        return response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<Token>(await response.Content.ReadAsStringAsync()) : null;
                    }
                }
            }
        }

        private void LogRequestParams(IEnumerable<KeyValuePair<string, string>> requestParameters)
        {
            foreach (var requestParameter in requestParameters)
            {
                logger.DebugFormat("{0}: {1}", requestParameter.Key, requestParameter.Value);
            }
        }
    }
}