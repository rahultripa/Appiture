
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Appitecture.Core.Models;

namespace Appitecture.Core.Requests
{
   public class GetLoginRequests
    {
       
        public async Task<assistantUser> GetLogin(string uid, string password)
        {

            RestClient<assistantUser> restClient = new RestClient<assistantUser>();

            assistantUser obj = new assistantUser();
            obj.UserId = uid;
            obj.Password = password;

            var result = await restClient.GetAsync("api/assistantUsers");
            try{

                return result.Where(c=>c.UserId.ToLower() == uid.ToLower()).Where(c=>c.Password.ToLower() == password.ToLower()).FirstOrDefault();
       
            }catch
            {
                return null;
            }
         }
    }
}
