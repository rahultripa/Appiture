using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Appitecture.Core.Models;

namespace Appitecture.Core.Requests
{
    public class GetAssistantsRequest
    {
        public GetAssistantsRequest()
        {
        }
        public async Task<List<Myassistant>> GetAssistants(double lat, double lng)
        {

            RestClient<Myassistant> restClient = new RestClient<Myassistant>();

            Myassistant obj = new Myassistant();
            obj.lat = lat;
            obj.lng = lng;
            // Will pass actual Lat /Lag
            var result = await restClient.GetAsync("api/Myassistants");
            try
            {

                return result;

            }
            catch
            {
                return null;
            }
        }
    }
}
