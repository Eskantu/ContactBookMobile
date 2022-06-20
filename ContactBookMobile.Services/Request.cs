using ContactBook.Core.Auth.Modelos;
using ContactBookMobile.Services.Intarfaces;
using ContactBookMobile.Services.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ContactBookMobile.Services
{
    public class Request<T> : IRequest<T> where T : class
    {
        private readonly HttpClient client;
        private readonly string _endPoint;
        public Request(string token, string endPoint)
        {
            _endPoint = endPoint;
            client = new HttpClient();
            client.BaseAddress = new Uri(Config.ServerAPIAddress);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public string Error { get; private set; }

        public async Task<bool> Delete(int id)
        {
            HttpResponseMessage message = await client.DeleteAsync($"{_endPoint}/{id}");
            return message.IsSuccessStatusCode;
        }

        public List<T> Get()
        {
            try
            {
                HttpResponseMessage message = client.GetAsync(_endPoint).Result;
                if (message.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<List<T>>(message.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    Error = message.ReasonPhrase;
                    return new List<T>();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<T> GetById(int id)
        {
            HttpResponseMessage message = await client.GetAsync($"{_endPoint}/{id}");
            if (message.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(await message.Content.ReadAsStringAsync());
            }
            else
            {
                Error = message.ReasonPhrase;
                return null;
            }
        }

        public async Task<string> Login(LoginRequest request)
        {
            HttpResponseMessage message = client.PostAsync("Authentication/requestToken", new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json")).Result;
            if (message.IsSuccessStatusCode)
            {
                return await message.Content.ReadAsStringAsync();

            }
            else 
            {
                Error = message.ReasonPhrase;
                return "";
            }
        }

        public async Task<bool> Post(string entidad)
        {
            HttpResponseMessage message = await client.PostAsync($"{_endPoint}", new StringContent(entidad));
            return message.IsSuccessStatusCode;
        }

        public async Task<bool> Put(string entidad)
        {
            HttpResponseMessage message = await client.PutAsync($"{_endPoint}", new StringContent(entidad));
            return message.IsSuccessStatusCode;
        }
    }
}
