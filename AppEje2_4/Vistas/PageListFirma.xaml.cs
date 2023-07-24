using AppEje2_4.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppEje2_4.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageListFirma : ContentPage
    {
        ObservableCollection<Firmas> observableCollectionFirmas;
        public PageListFirma()
        {
            InitializeComponent();
            observableCollectionFirmas = new ObservableCollection<Firmas>();
            listview_firmas.ItemsSource = observableCollectionFirmas;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var listviewfirmas = await App.BaseDatos.ListViewFirmas();
            observableCollectionFirmas.Clear(); // Clear the collection before adding new items

            foreach (Firmas firma in listviewfirmas)
            {
                observableCollectionFirmas.Add(firma);
            }
        }
    }
}