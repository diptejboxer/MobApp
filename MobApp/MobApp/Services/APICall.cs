using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace MobApp.Services
{
   public class APICall
    {
        public async void login(string email, string password)
        {
            var client = new HttpClient();
            var response = await client.GetStringAsync("");
        }
    }
}
