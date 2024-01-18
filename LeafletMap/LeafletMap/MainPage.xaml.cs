using LeafletMap.CustomRender;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LeafletMap
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            CargarMapa();
        }

        public void CargarMapa()
        {
            var source = new HtmlWebViewSource();
            source.BaseUrl = DependencyService.Get<IBaseUrl>().Get();
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("LeafletMap.index.html");
            StreamReader reader = null;
            if (stream != null)
            {
                try
                {
                    reader = new StreamReader(stream);
                    source.Html = reader.ReadToEnd();
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Dispose();
                    }
                }
                webView.Source = source;
            }
            else
            {
                DisplayAlert("Aviso!", "error al cargar el mapa...", "entendido");
            }
        }

        public void SetItemMuestra()
        {
            //-2.14003,-79.9312967 marker
            newMarker("-2.14003", "-79.9312967", "Soy un marker");

            //-2.1407283,-79.9286524 circulo
            newCircle("-2.1407283", "-79.9286524", "red", "#07", 0.5, 50);

            //-2.14003,-79.9312967 / -2.1407283,-79.9286524 Linea
            newLine("-2.14003", "-79.9312967", "-2.1407283", "-79.9286524", "blue");

            //mostrar objetos
            Show();

            //centrar el mapa
            //CentrarMapa("10.6222200", "-66.5735300");
        }

        /*
         Crear marcador
         lat = latitud
         lon = longitud
         */
        public void newMarker(string lat, string lon, string texto = "")
        {
            if (string.IsNullOrEmpty(lat) || string.IsNullOrEmpty(lon))
            {
                Console.Write("Verifique los campos lat lon");
                return;
            }

            webView.Eval(string.Format("newMarker({0}, {1}, {2})", "\""+lat+ "\"", "\""+lon+ "\"", "\""+texto+"\""));
        }

        /*
         Crear Linea
         latFrom = latitud de comienzo
         lonFrom = longitud de comienzo
         latTo = latitud final
         lonTo = longitud final
         color = color de la linea
         */
        public void newLine(string latFrom, string lonFrom, string latTo, string lonTo, string color = "blue")
        {
            if (string.IsNullOrEmpty(latFrom) || string.IsNullOrEmpty(lonFrom) || string.IsNullOrEmpty(latTo) || string.IsNullOrEmpty(lonTo))
            {
                Console.Write("Verifique los campos lat lon");
                return;
            }
            webView.Eval($@"newLine(""{latFrom}"",""{lonFrom}"",""{latTo}"",""{lonTo}"",""{color}"")");
        }

        /*
         Crear Circulo
         lat = latutud
         lon = longitud
         color = color de linea
         fillcolor = color de relleno
         fillopacity = transparencia de relleno
         raidus = radio
         */
        public void newCircle(string lat, string lon, string color = "blue", string fillcolor = "#07", double fillopacity = 0.5, int radius = 500)
        {
            if (string.IsNullOrEmpty(lat) || string.IsNullOrEmpty(lon))
            {
                Console.Write("Verifique los campos lat lon");
                return;
            }
            webView.Eval(string.Format("newCircle({0},{1},{2},{3},{4},{5})", "\""+lat+ "\"", "\""+lon+ "\"", "\""+color+ "\"", "\""+fillcolor+ "\"", "\""+fillopacity+ "\"", "\""+radius+ "\""));
        }

        /*
         Centrar mapa
         lat = latitud
         lon = longitud
         */
        public void CentrarMapa(string lat, string lon)
        {
            if (string.IsNullOrEmpty(lat) || string.IsNullOrEmpty(lon))
            {
                Console.Write("Verifique los campos lat lon");
                return;
            }
            webView.Eval(string.Format("centerMap({0},{1})", "\""+lat+ "\"", "\""+lon+ "\""));
        }

        /*
         Mostrar grupo
         */
         public void Show()
        {
            webView.Eval(@"show()");
        }

        /*
         Eliminar objetos
         */
         public void Destruir()
        {
            webView.Eval(@"delMarket()");
        }

        private void Send_Clicked(object sender, EventArgs e)
        {
            SetItemMuestra();
        }
    }
}
