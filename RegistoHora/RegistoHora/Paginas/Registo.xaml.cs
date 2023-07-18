using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RegistoHora.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registo : ContentPage
    {
        public Registo()
        {
            InitializeComponent();
        }

        private void Voltar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void Registar_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Registo", "Registo feito com sucesso!", "Ok");
        }
    }
}