using System;
using System.Threading.Tasks;
using Appitecture.Core.Models;

namespace Appitecture.Core.Requests
{
    public class GetBookAssistantsRequest
    {
        public GetBookAssistantsRequest()
        {
        }
        public async Task<bool> PostAssistant(assistantBooking AssistantBooking)
        {

            RestClient<assistantBooking> restClient = new RestClient<assistantBooking>();

           
            var result = await restClient.PostAsync(AssistantBooking,"api/assistantBookings");
            try
            {

                return result;

            }
            catch
            {
                return false;
            }
        }
    }
}
