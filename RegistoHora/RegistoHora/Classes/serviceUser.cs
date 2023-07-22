using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RegistoHora.Classes
{
    public class serviceUser
    {
        public static string PasswordFirebase = "TfdPlI4EqFyGU2E1aozVMwN3u7d4HirO6UZzULgz";
        FirebaseClient User = new FirebaseClient("https://registohoras-890a6-default-rtdb.europe-west1.firebasedatabase.app/", new FirebaseOptions { AuthTokenAsyncFactory = () => Task.FromResult(PasswordFirebase) });
    
        public async Task<bool> RegisterUser (string username, int password, string email, string company, int numberemployee)
        {
            var consult = (await User.Child("Users")
                .OnceAsync<Users>())
                .Where(u => u.Object.Email == email)
                .FirstOrDefault();

            try
            {
                if (consult == null)
                {
                    await User.Child("Users")
                    .PostAsync(new Users()
                    {
                        UserName = username,
                        Password = password,
                        Email = email,
                        Company = company,
                        NumerEmployee = numberemployee
                    });
                    return true;
                }
                return false;
            }
            catch 
            {
                return false;
            }
        }

        public async Task<bool> CheckLogin(string email, int password)
        { 
            var consult = (await User.Child("Users")
                .OnceAsync<Users>())
                .Where(u => u.Object.Email == email)
                .Where(u => u.Object.Password == password)
                .FirstOrDefault();

            return consult != null;
        }

        public async Task<List<Users>> GetAll()
        {
            try
            {
                var userlist = (await User.Child("Users")
                    .OnceAsync<Users>())
                    .Select(item => new Users
                    {
                        Email = item.Object.Email,
                        Password = item.Object.Password,
                        Company = item.Object.Company,
                        UserName = item.Object.UserName,
                        NumerEmployee = item.Object.NumerEmployee
                    }).ToList();
                return userlist;
            }
            catch { return null; }
        }

        public async Task<Users> GetUser(string email)
        {
            try
            {
                var model = await GetAll();

                await User.Child("Users")
                    .OnceAsync<Users>();

                return model.Where(x => x.Email == email).FirstOrDefault();
            }
            catch { return null; }
        }

        public async Task<bool> RegitarHoras(string email, DatePicker date, TimePicker hora, string status)
        {
            var consult = await GetUser(email);
     
            try
            {
                if (consult != null)
                {
                    DateTime dateTime = date.Date + hora.Time;

                    await User.Child("Horas")
                        .PostAsync(new Horas()
                        {
                            Status = status,
                            Email= email,
                            Date = dateTime.ToString("yyyy-MM-dd"),
                            Hora = dateTime.ToString("hh:mm"),
                        });
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> SalvarObservacao(string email, DatePicker date, string observacao, string status)
        {
            var consult = await GetUser(email);

            try
            {
                if(consult != null)
                {
                    DateTime dateTime = date.Date;

                    await User.Child("Horas")
                        .PostAsync(new Horas()
                        {
                            Email = email,
                            Date = dateTime.ToString("yyyy-MM-dd"),
                            Observacao = observacao,
                            Status = status
                        });
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
