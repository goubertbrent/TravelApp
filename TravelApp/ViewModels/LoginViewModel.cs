using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelApp.DTO;

namespace TravelApp.ViewModels
{
    public class LoginViewModel
    {
        private string _statusOk = "OK";

        public LoginViewModel()
        {
        }
        public async Task<Boolean> Login(LoginDTO login)
        {
            var loginJson = JsonConvert.SerializeObject(login);
            HttpClient client = new HttpClient();
            var res = await client.PostAsync("http://localhost:65495/api/account", new StringContent(loginJson, System.Text.Encoding.UTF8, "application/json"));
            return res.StatusCode.ToString() == _statusOk;
        }

        public async Task Register(RegisterDTO registerData)
        {
            var registerJson = JsonConvert.SerializeObject(registerData);
            HttpClient client = new HttpClient();
            var res = await client.PostAsync("http://localhost:65495/api/account/register", new StringContent(registerJson, System.Text.Encoding.UTF8, "application/json"));

        }
    }
}
