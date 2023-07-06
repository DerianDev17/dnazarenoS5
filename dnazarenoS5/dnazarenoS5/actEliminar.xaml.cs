using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dnazarenoS5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class actEliminar : ContentPage
    {
        public actEliminar(Datos datos)
        {
            InitializeComponent();
            txtcodigo.Text = datos.codigo.ToString();
            txtNombre.Text = datos.nombre.ToString();
            txtApellido.Text = datos.apellido.ToString();
            txtEdad.Text = datos.edad.ToString();
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {

            try
            {
                WebClient cliente = new WebClient();

                string URL = "http://10.2.13.197/ws_uisrael/post.php";

                string codigo = txtcodigo.Text;
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string edad = txtEdad.Text;

                string url = $"{URL}?codigo={codigo}&nombre={nombre}&apellido={apellido}&edad={edad}";

                var parametros = new System.Collections.Specialized.NameValueCollection();


                parametros.Add("codigo", txtcodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);

                cliente.UploadValues(url, "PUT", parametros);
                // mensaje toast
                var mensaje = "dato actualizado";
                DependencyService.Get<mensaje>().LongAlert(mensaje);

                Navigation.PushAsync(new Page1());
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }
        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();

                string URL = "http://10.2.13.197/ws_uisrael/post.php";

                string codigo = txtcodigo.Text;
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string edad = txtEdad.Text;

                string url = $"{URL}?codigo={codigo}";

                var parametros = new System.Collections.Specialized.NameValueCollection();

                parametros.Add("codigo", txtcodigo.Text);

                cliente.UploadValues(url, "DELETE", parametros);
                // mensaje toast
                var mensaje = "dato eliminado";
                DependencyService.Get<mensaje>().LongAlert(mensaje);

                Navigation.PushAsync(new Page1());
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }

        }
    }
}