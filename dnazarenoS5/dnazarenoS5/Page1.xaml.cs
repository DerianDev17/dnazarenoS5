using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dnazarenoS5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {

        private const string Url = "http://192.168.200.142/ws_uisrael/post.php";
        private HttpClient cliente = new HttpClient();
        private ObservableCollection<dnazarenoS5.Datos> datos;
        public Page1()
        {
            InitializeComponent();
            obtner();

        }

        public async void obtner()
        {
            var contenido = await cliente.GetStringAsync(Url);
            List<dnazarenoS5.Datos> listPost = JsonConvert.DeserializeObject<List<dnazarenoS5.Datos>>(contenido);
            datos = new ObservableCollection<Datos>(listPost);
            listaEstudiantes.ItemsSource = datos;
        }

        private void listaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var objetoEstudiante = (Datos)e.SelectedItem;
            /*
            int codigo = Convert.ToInt32(objetoEstudiante.codigo.ToString());
            string nombre = objetoEstudiante.nombre.ToString();
            string apellido = objetoEstudiante.apellido.ToString();
            int edad = Convert.ToInt32 (objetoEstudiante.edad.ToString());
            */
            Navigation.PushAsync(new actEliminar(objetoEstudiante));
        }

        private void btnInsertar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new insertar());
        }
    }
}