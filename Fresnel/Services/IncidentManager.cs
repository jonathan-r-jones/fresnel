using Fresnel.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Fresnel.Services
{
    public class IncidentManager
    {
        const string Url = "http://xam150.azurewebsites.net/api/books/";
        //private string authorizationKey;

        private async Task<HttpClient> GetClient()
        {
            HttpClient client = new HttpClient();
            //if (string.IsNullOrEmpty(authorizationKey))
            //{
            //    authorizationKey = await client.GetStringAsync(Url + "login");
            //    authorizationKey = JsonConvert.DeserializeObject<string>(authorizationKey);
            //}
            //client.DefaultRequestHeaders.Add("Authorization", authorizationKey);
            await client.GetStringAsync(Url);
            client.DefaultRequestHeaders.Add("zumo-api-version", "2.0.0");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public async Task<IEnumerable<Incident>> GetAll()
        {
            // TODO: use GET to retrieve books
            HttpClient client = await GetClient();
            string result = await client.GetStringAsync(Url);
            return JsonConvert.DeserializeObject<IEnumerable<Incident>>(result);
        }

        public async Task<Incident> Add(string name, int count)
        {
            // TODO: use POST to add a book
            Incident incident = new Incident()
            {
                Name = name,
                Count = count
            };

            HttpClient client = await GetClient();
            var response = await client.PostAsync(Url,
                new StringContent(
                    JsonConvert.SerializeObject(incident),
                    Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Incident>(
                await response.Content.ReadAsStringAsync());
        }

        public async Task Update(Incident incident)
        {
            // TODO: use PUT to update a book
            HttpClient client = await GetClient();
            await client.PutAsync(Url + "/" + incident.Id,
                new StringContent(
                    JsonConvert.SerializeObject(incident),
                    Encoding.UTF8, "application/json"));
        }

        public async Task Delete(string id)
        {
            // TODO: use DELETE to delete a book
            HttpClient client = await GetClient();
            await client.DeleteAsync(Url + "/" + id);
        }
    }
}

