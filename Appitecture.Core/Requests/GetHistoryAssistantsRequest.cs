using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Appitecture.Core.Models;

namespace Appitecture.Core.Requests
{
    public class GetHistoryAssistantsRequest
    {
        public GetHistoryAssistantsRequest()
        {
        }

        public async Task<List<assistantBooking>> GetassistantBooking()
        {

            RestClient<assistantBooking> restClient = new RestClient<assistantBooking>();

            var result = await restClient.GetAsync("api/assistantBookings");
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
