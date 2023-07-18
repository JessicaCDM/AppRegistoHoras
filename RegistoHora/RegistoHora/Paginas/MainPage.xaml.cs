using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RegistoHora
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void Login(object sender, EventArgs e)
        {
            DisplayAlert("Login", "Login feito com sucesso", "OK");
        }

        private void Registo(object sender, EventArgs e)
        {
            var registo = new Paginas.Registo();
            Navigation.PushModalAsync(registo);
        }
    }
}
