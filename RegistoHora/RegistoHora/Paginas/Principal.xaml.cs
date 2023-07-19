using RegistoHora.Classes;
using RegistoHora.Paginas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RegistoHora.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Principal : ContentPage
    {
        public Principal(string email)
        {
            InitializeComponent();

            PrincipalAsync(email);

        }
        public async void PrincipalAsync(string email)
        {

            var access = new serviceUser();
            var model = await access.GetUser(email);
            if (model != null)
            {
                nome.Text = "Bem vindo, " + model.UserName;
            }
        }
    }
}