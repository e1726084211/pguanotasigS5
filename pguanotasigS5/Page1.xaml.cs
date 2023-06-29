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

namespace pguanotasigS5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public const string Url = "http://192.168.17.33/ws_uisrael/post.php";
        private HttpClient cliente = new HttpClient();
        private ObservableCollection<pguanotasigS5.Datos> post;
        public Page1()
        {
            InitializeComponent();
            obtener();
        }

        private async void obtener()
        {
            var contenido = await cliente.GetStringAsync(Url);
            List<pguanotasigS5.Datos> listPost = JsonConvert.DeserializeObject<List<pguanotasigS5.Datos>>(contenido);
            post = new ObservableCollection<Datos>(listPost);
            listaEstudiantes.ItemsSource = post;
        }
    }
}