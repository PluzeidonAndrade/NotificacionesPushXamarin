using appNotificacionesPush.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace appNotificacionesPush.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            var vm = new LoginViewModel();
            this.BindingContext = vm;
            vm.DisplayInvalidLoginPrompt += () => DisplayAlert("Error", "Login invalido, intente de nuevo", "OK");
            vm.DisplayValidLoginPrompt += () => DisplayAlert("Aviso", "Login Verificado", "OK");
            InitializeComponent();

            Email.Completed += (object sender, EventArgs e) =>
            {
                Password.Focus();
            };

            Password.Completed += (object sender, EventArgs e) =>
            {
                vm.SubmitCommand.Execute(null);
            };
        }
    }
}