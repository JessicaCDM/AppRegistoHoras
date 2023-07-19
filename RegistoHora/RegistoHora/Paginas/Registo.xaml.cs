using RegistoHora.Classes;
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
        bool carregando;
        public Registo()
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
        private async void Registar_Clicked(object sender, EventArgs e)
        {
            TelaCrregamento();
            if (password.Text != confirmPassword.Text)
            {
                await DisplayAlert("Falha", "As senhas não correspondem", "Ok");

                TelaCrregamento();
                return;
            }
            try
            {
                var access = new serviceUser();
                bool createAccess = await access.RegisterUser(nome.Text, Int32.Parse(password.Text), email.Text, empresa.Text, Int32.Parse(nFuncionario.Text));
                
                if(createAccess)
                {
                    await DisplayAlert("Sucesso", "Registo feito com sucesso", "Ok");
                    nome.Text = string.Empty;
                    password.Text = string.Empty;
                    email.Text = string.Empty;
                    empresa.Text = string.Empty;
                    confirmPassword.Text = string.Empty;
                    nFuncionario.Text = string.Empty;

                    TelaCrregamento();
                    return;
                }
                else
                {
                    await DisplayAlert("Falha", "E-mail já registado", "Ok");

                    TelaCrregamento();
                    return;
                }
            }
            catch
            {
                await DisplayAlert("Falha", "Ocorreu um Erro!", "Ok");

                TelaCrregamento();
            }
        }
    }
}