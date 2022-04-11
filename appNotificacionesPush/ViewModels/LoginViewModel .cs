using appNotificacionesPush.Models;
using appNotificacionesPush.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace appNotificacionesPush.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;
        public Action DisplayValidLoginPrompt;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public ICommand SubmitCommand { protected set; get; }
        public LoginViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }
        public async void OnSubmit()
        {
            var request = new HttpRequestMessage();
            User resultado = new User();
            string uri = "http://188.166.119.155/api/User/" + Email + "/" + Password + "/" + Preferences.Get("TokenFirebase", "");
            request.RequestUri = new Uri(uri);
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept","application/json");
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                resultado = JsonConvert.DeserializeObject<User>(content);
            }

            if (resultado.userid==0)
            {
                DisplayInvalidLoginPrompt();
            }
            else
            {
                DisplayValidLoginPrompt();
            }
        }

        

        
    }
}