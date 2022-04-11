using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.OpenWhatsApp;

namespace appNotificacionesPush
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            txtToken.Text = Preferences.Get("TokenFirebase", "");
        }

        private void btnWhatsApp_Clicked(object sender, EventArgs e)
        {
            Chat.Open("524778476227", Preferences.Get("TokenFirebase", ""));
        }
    }
}
