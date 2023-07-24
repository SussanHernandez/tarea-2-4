using AppEje2_4.Models;
using SignaturePad.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppEje2_4.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageFirma : ContentPage
    {
        byte[] ImageBytes;
        public PageFirma()
        {
            InitializeComponent();
        }

        private async void btnagregar_Clicked(object sender, EventArgs e)
        {
            Stream Firma = await firmapadview.GetImageStreamAsync(SignatureImageFormat.Png);
            try
            {
                //obtenemos la firma
                var firma = await firmapadview.GetImageStreamAsync(SignatureImageFormat.Png);


                //Pasamos la firma a imagen a base 64
                var fSream = (MemoryStream)firma;
                byte[] data = fSream.ToArray();
                string base64Value = Convert.ToBase64String(data);
                ImageBytes = Convert.FromBase64String(base64Value);


            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Firma vacia, Porfavor Agregar su firma", "Ok");
            }

            //seteamos los valores
            var firmas = new Firmas
            {
                Descripcion = descripcion_input.Text,
                Imagen = ImageBytes
            };


            //Aviso de los campos vacios.............
            if (String.IsNullOrEmpty(descripcion_input.Text))
            {
                await DisplayAlert("Aviso", "¡¡Todos los campos deben ser llenados!!", "Entendido");
            }

            else
            {
                await DisplayAlert("Aviso", "Firma Agregada Con Exito 👌!!!", "Listo");

                //Guardar firma en la base de datos
                await App.BaseDatos.GuardarFirmas(firmas);

                

                //limpiar datos
                firmapadview.Clear();                
                descripcion_input.Text = "";

            }


        }

        //Ir la pagina de lista de firmas: Navegar a la pagina de lista de firmas
        private async void btnlistview_firmas_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Vistas.PageListFirma());

        }
    }
}