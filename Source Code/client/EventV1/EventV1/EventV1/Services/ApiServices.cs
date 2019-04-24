using EventV1.Helpers;
using EventV1.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EventV1.Services
{
    public class ApiServices
    {
       // public string token { get; set; }

        public async Task<bool> RegisterAsync(string email, string password, string confirmPassword)
        {
            var client = new HttpClient();
            var model = new RegisterBindingModel
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword
            };
            var json = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync("http://192.168.1.105:54312/api/Account/Register", content);
            return response.IsSuccessStatusCode;

        }

        public async Task<string> LoginAsync(string userName, string password)
        {
            var keyValues = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("username",userName),
                new KeyValuePair<string, string>("password",password),
                new KeyValuePair<string, string>("grant_type","password")
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "https://backendapi.conveyor.cloud/Token");

            request.Content = new FormUrlEncodedContent(keyValues);

            var client = new HttpClient();
            var response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            JObject jwt = JsonConvert.DeserializeObject<dynamic>(content);
            var accessToken = jwt.Value<string>("access_token");
            var username = jwt.Value<string>("userName");
            DataBindingModel dbm = new DataBindingModel();
            dbm.User = username;
            Debug.WriteLine(content);
            return accessToken;
        }

        public async Task<List<EventUpload>> GetEventsAsync(string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var json = await client.GetStringAsync("https://backendapi.conveyor.cloud/api/EventUpload");
            var content = JsonConvert.DeserializeObject<List<EventUpload>>(json);
            return content;
        }

       // public static string token = 

    }
}
