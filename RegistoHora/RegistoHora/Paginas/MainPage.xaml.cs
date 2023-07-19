using RegistoHora.Classes;
using RegistoHora.Paginas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RegistoHora
{
    public partial class MainPage : ContentPage
    {
        bool carregando;
        public MainPage()
        {
            InitializeComponent();
        }
        public void TelaCrregamento()
        {
            if (carregando)
            {
                standbyScreen.IsVisible = false;
                wheel.IsVisible = false;
                wheel.IsRunning = false;

                carregando = false;
            }
            else
            {
                standbyScreen.IsVisible = true;
                wheel.IsVisible = true;
                wheel.IsRunning = true;

                carregando = true;
            }
        }
        private async void Login(object sender, EventArgs e)
        {
            try
            {
                TelaCrregamento();

                var log = new serviceUser();
                bool loginverify = await log.CheckLogin(user.Text, Int32.Parse(password.Text));

                if(loginverify)
                {
                    await DisplayAlert("Sucesso", "Login feito com sucesso", "Ok");
                    await Navigation.PushAsync(new Principal(user.Text));

                    TelaCrregamento();
                }
                else
                {
                    await DisplayAlert("Falha", "Usuário e senha não correspondem", "Ok");

                    TelaCrregamento();
                }
            }
            catch
            {
                await DisplayAlert("Falha", "Ocorreu um erro", "Ok");

                TelaCrregamento();
            }
            user.Text = string.Empty;
            password.Text = string.Empty;
        }

        private void Registo(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registo());
        }
    }
}
