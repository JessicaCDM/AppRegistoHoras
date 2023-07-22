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
	public partial class RegistoHoras : ContentPage
	{
		public RegistoHoras (string email)
		{
			InitializeComponent();

            emailUser.Text = email;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            hora.Time = DateTime.Now.TimeOfDay;
        }

        private async void Entrada_Clicked(object sender, EventArgs e)
        {
            try
            {
                string status = "Entrada";
                var access = new serviceUser();
                bool createAccess = await access.RegitarHoras(emailUser.Text, date, hora, status);

                if (createAccess)
                {
                    await DisplayAlert("Sucesso", "Registo feito com sucesso", "Ok");
                    return;
                }
                else
                {
                    await DisplayAlert("Falha", "Erro no sistema", "Ok");
                    return;
                }
            }
            catch
            {
                await DisplayAlert("Falha", "Erro", "Ok");
            }
        }

        private async void Saida_Clicked(object sender, EventArgs e)
        {
            try
            {
                string status = "Saida";
                var access = new serviceUser();
                bool createAccess = await access.RegitarHoras(emailUser.Text, date, hora, status);

                if (createAccess)
                {
                    await DisplayAlert("Sucesso", "Registo feito com sucesso", "Ok");
                    return;
                }
                else
                {
                    await DisplayAlert("Falha", "Erro no sistema", "Ok");
                    return;
                }
            }
            catch
            {
                await DisplayAlert("Falha", "Erro", "Ok");
            }
        }

        private async void Salvar_Clicked(object sender, EventArgs e)
        {
            try
            {
                string obs = campoObservacao.Text;
                string status = "Observacao";
                var access = new serviceUser();
                bool createAccess = await access.SalvarObservacao(emailUser.Text, date, obs, status);

                if (createAccess)
                {
                    await DisplayAlert("Sucesso", "Salvo com sucesso", "Ok");
                    return;
                }
                else
                {
                    await DisplayAlert("Falha", "Erro no sistema", "Ok");
                    return;
                }
            }
            catch
            {
                await DisplayAlert("Falha", "Erro", "Ok");
            }
        }
    }
}