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

namespace pguanotasigS5
{
    public partial class MainPage : ContentPage
    {
        public const string Url = "http://192.168.17.33/ws_uisrael/post.php";
        private HttpClient cliente = new HttpClient();
        private ObservableCollection<pguanotasigS5.Datos> post;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnMostrar_Clicked(object sender, EventArgs e)
        {
            var contenido = await cliente.GetStringAsync(Url);
            List<pguanotasigS5.Datos> listPost = JsonConvert.DeserializeObject<List<pguanotasigS5.Datos>>(contenido);
            post = new ObservableCollection<Datos>(listPost);
            listaEstudiantes.ItemsSource = post;
        }
    }
}
