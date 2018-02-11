using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Appitecture.Core.Requests
{
    public class RestClient<T>
    {
       
        public async Task<List<T>> GetAsync(string subURL)
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(Constants.BaseUrl + subURL);

            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);

            return taskModels;
        }
        public async Task<T> GetAsync(string subURL,int id)
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(Constants.BaseUrl + subURL+"/"+id);

            var taskModels = JsonConvert.DeserializeObject<T>(json);

            return taskModels;
        }

        public async Task<T> PostLoginAsync(T t, string subURL)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(Constants.BaseUrl + subURL, httpContent);
            var taskModels = JsonConvert.DeserializeObject<T>(result.ToString());

            return taskModels;
           
        }

        public async Task<bool> PostAsync(T t, string subURL)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(Constants.BaseUrl + subURL, httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> PutAsync(int id, T t, string subURL)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PutAsync(Constants.BaseUrl + subURL + id, httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id, T t, string subURL)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(Constants.BaseUrl + subURL + id);

            return response.IsSuccessStatusCode;
        }
    }
}
