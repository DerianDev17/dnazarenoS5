using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace dnazarenoS5
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://10.2.13.197/ws_uisrael/post.php";
        private HttpClient cliente = new HttpClient();
        private ObservableCollection<dnazarenoS5.Datos> datos;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnMostrar_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new insertar());
        }
    }
}
