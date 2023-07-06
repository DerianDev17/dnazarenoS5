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
	public partial class insertar : ContentPage
	{
		public insertar ()
		{
			InitializeComponent ();
		}

        private void btnInsertar_Clicked(object sender, EventArgs e)
        {
			try
			{
				WebClient cliente = new WebClient ();

				string url = "http://10.2.13.197/ws_uisrael/post.php";
				var parametros = new System.Collections.Specialized.NameValueCollection();

				parametros.Add("codigo", txtcodigo.Text);
				parametros.Add("nombre", txtNombre.Text);
				parametros.Add("apellido", txtApellido.Text);
				parametros.Add("edad", txtEdad.Text);

				cliente.UploadValues(url, "POST" ,parametros);
				// mensaje toast
				var mensaje = "dato ingresado";
				DependencyService.Get<mensaje>().LongAlert(mensaje);

				Navigation.PushAsync(new Page1());
            }
			catch (Exception ex)
			{

                DisplayAlert("alerta", ex.Message, "cerrar");
            }
        }
    }
}