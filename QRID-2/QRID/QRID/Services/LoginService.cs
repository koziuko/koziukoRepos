using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace QRID.Services
{

    public class LoginResponse 
    {
        public string msg { get; set; }
    }

    public class LoginService
    {
        HttpClient client;

        public LoginService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<bool> ValidateUser(string username, string password) 
        {
            var uri = new Uri(string.Format("http://demo5619277.mockable.io/validarUsuario", string.Empty));

            var jsonData = "{\"username\" : " + username + ", \"password\" : " + password + "}";

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(uri, content);
            if (response.IsSuccessStatusCode)
            {
                var contentResponse = await response.Content.ReadAsStringAsync();
                LoginResponse responseMsg = JsonConvert.DeserializeObject<LoginResponse>(contentResponse);
                return bool.Parse(responseMsg.msg);
            }

            return false;
        }
    }
}
