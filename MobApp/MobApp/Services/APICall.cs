using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace MobApp.Services
{
   public class APICall
    {
        public async System.Threading.Tasks.Task<string> loginAsync(string Email, string Password)
        {
            try
            {
                var client = new HttpClient();

                var post = new PostLogin { email = Email, password = Password };
                var jsonpost= JsonConvert.SerializeObject(post);
                var response = await client.PostAsync("http://localhost:1245/api/PostLogin", new StringContent(jsonpost,Encoding.UTF8,"application/json"));
                var json = response.Content.ReadAsStringAsync();
                string res = json.Result;
                return res;
            }
            catch(Exception ex)
            { return "0"; }
        }
    }
}
