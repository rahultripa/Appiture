using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Appitecture.Core.Models;

namespace Appitecture.Core.Requests
{
    public class GetAssistantRequest
    {
        public GetAssistantRequest()
        {
        }
        public async Task<Myassistant> GetAssistants(int id)
        {

            RestClient<Myassistant> restClient = new RestClient<Myassistant>();

           

            var result = await restClient.GetAsync("api/Myassistants",id);

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
