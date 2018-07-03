using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Fresnel.Models;

namespace Fresnel.Services
{
	public class FresnelApiDataService : BaseHttpService, IFresnelDataService
	{
		readonly Uri _baseUri;
		readonly IDictionary<string, string> _headers;

		struct IdProviderToken
		{
			[JsonProperty("access_token")]
			public string AccessToken { get; set; }
		}

		public FresnelApiDataService(Uri baseUri)
		{
			_baseUri = baseUri;
            _headers = new Dictionary<string, string>
            {
                { "zumo-api-version", "2.0.0" }
            };
            //_headers.Add("x-zumo-auth", authToken);
        }

		//public async Task<TripLogApiAuthToken> GetAuthTokenAsync(string idProvider, string idProviderToken)
		//{
		//	var token = new IdProviderToken
		//	{
		//		AccessToken = idProviderToken
		//	};

		//	var url = new Uri(_baseUri, string.Format(".auth/login/{0}", idProvider));
			
		//	var response = await SendRequestAsync<TripLogApiAuthToken>(url, HttpMethod.Post, _headers, token);
              
		//	// Update this service with the new auth token
		//	if (response != null)
		//	{
		//		var authToken = response.AuthenticationToken;

		//		_headers["x-zumo-auth"] = authToken;
		//	}

		//	return response;
		//}

		public async Task<IList<Open_Incident>> GetEntriesAsync()
		{
			var url = new Uri(_baseUri, "/tables/Open_Incidents");
			var response = await SendRequestAsync<Open_Incident[]>(url, HttpMethod.Get, _headers);

			return response;
		}

		public async Task<Open_Incident> GetEntryAsync(string id)
		{
			var url = new Uri(_baseUri,	string.Format("/tables/Open_Incidents/{0}", id));
			var response = await SendRequestAsync<Open_Incident>(url, HttpMethod.Get, _headers);

			return response;
		}

		public async Task<Open_Incident> AddEntryAsync(Open_Incident entry)
		{
			var url = new Uri(_baseUri, "/tables/Open_Incidents");
			var response = await SendRequestAsync<Open_Incident>(url, HttpMethod.Post, _headers, entry);

			return response;
		}

		public async Task<Open_Incident> UpdateEntryAsync(Open_Incident entry)
		{
			var url = new Uri(_baseUri,	string.Format("/tables/Open_Incidents/{0}", entry.Id));
			var response = await SendRequestAsync<Open_Incident>(url, new HttpMethod("PATCH"), _headers, entry);

			return response;
		}

		public async Task RemoveEntryAsync(Open_Incident entry)
		{
			var url = new Uri(_baseUri,	string.Format("/tables/Open_Incidents/{0}", entry.Id));
			var response = await SendRequestAsync<Open_Incident>(url, HttpMethod.Delete, _headers);
		}
	}
}
