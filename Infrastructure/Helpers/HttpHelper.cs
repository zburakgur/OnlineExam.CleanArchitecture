using System.Net.Http.Headers;
using System.Net;
using System.Text;
using Infrastructure.Settings;
using Newtonsoft.Json;
using Infrastructure.Auth;

namespace Infrastructure.Helpers
{
    public class HttpHelper
    {
        private readonly string CONTENT_TYPE = "application/json";
        private string token = null;
        private readonly HttpSettings httpSettings;

        public HttpHelper(HttpSettings httpSettings)
        {
            this.httpSettings = httpSettings;
        }

        public async Task<T> GetAsync<T>(string methodName, HttpStatusCode successStatusCode = HttpStatusCode.OK) where T : class
        {
            using (HttpClient httpClient = await GetCustomerClient())
            {
                return await ValidateResponse<T>(await httpClient.GetAsync(methodName), successStatusCode);
            }
        }

        public async Task<HttpStatusCode> Post<T>(string methodName, T model, HttpStatusCode successStatusCode = HttpStatusCode.OK)
        {
            var requestBody = JsonConvert.SerializeObject(model);
            using (HttpClient httpClient = await GetCustomerClient())
            {
                HttpRequestMessage request = new(HttpMethod.Post, methodName);
                request.Content = new StringContent(requestBody, Encoding.UTF8, CONTENT_TYPE);

                return (await httpClient.SendAsync(request)).StatusCode;
            }
        }

        public async Task<TReponse> Post<TRequest, TReponse>(string methodName, TRequest model, HttpStatusCode successStatusCode = HttpStatusCode.OK)
        {
            var requestBody = JsonConvert.SerializeObject(model);

            using (HttpClient httpClient = await GetCustomerClient())
            {
                return await ValidateResponse<TReponse>(await httpClient.PostAsync(methodName, new StringContent(requestBody, Encoding.UTF8, CONTENT_TYPE)), successStatusCode);
            }
        }

        private HttpClient GetClient()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient httpClient = new HttpClient(clientHandler);
            httpClient.BaseAddress = new Uri(httpSettings.ApiUri);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(CONTENT_TYPE));

            return httpClient;
        }

        private async Task<HttpClient> GetCustomerClient()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient httpClient = new(clientHandler);
            try
            {
                httpClient.BaseAddress = new Uri(httpSettings.ApiUri);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(CONTENT_TYPE));
                //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await GetToken());
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
            return httpClient;
        }

        private async Task<string> GetToken()
        {
            if (string.IsNullOrEmpty(token))
            {
                return await LoginBaseApi();
            }

            try
            {
                return token;
            }
            catch (Exception)
            {
                return await LoginBaseApi();
            }
        }

        private async Task<string> LoginBaseApi()
        {
            var requestBody = JsonConvert.SerializeObject(
                new TokenInput() 
                { 
                    Username = httpSettings.Username,
                    Password = httpSettings.Password,
                });

            using (HttpClient httpClient = GetClient())
            {
                token = (await ValidateResponse<TokenOutput>(await httpClient.PostAsync("Auth/Token",
                                                                                        new StringContent(requestBody, Encoding.UTF8, CONTENT_TYPE)
                                                                                        ), HttpStatusCode.OK)).Token;

                return token;
            }
        }

        private async Task<T> ValidateResponse<T>(HttpResponseMessage response, HttpStatusCode successStatusCode = HttpStatusCode.OK)
        {
            if (response.StatusCode == successStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }

            throw new Exception(await response.Content.ReadAsStringAsync());
        }
    }
}
