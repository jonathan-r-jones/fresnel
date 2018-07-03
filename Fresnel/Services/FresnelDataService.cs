using System.Collections.Generic;
using System.Threading.Tasks;
using Fresnel.Models;

namespace Fresnel.Services
{
    public interface IFresnelDataService
    {
		//Task<TripLogApiAuthToken> GetAuthTokenAsync(string idProvider, string idProviderToken);
		Task<IList<Open_Incident>> GetEntriesAsync();
		Task<Open_Incident> GetEntryAsync(string id);
		Task<Open_Incident> AddEntryAsync(Open_Incident entry);
		Task<Open_Incident> UpdateEntryAsync(Open_Incident entry);
		Task RemoveEntryAsync(Open_Incident entry);
	}
}
