using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if (consult.ToString() == "")
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
            var concult = (await User.Child("Users")
                .OnceAsync<Users>())
                .Where(u => u.Object.Email == email)
                .Where(u => u.Object.Password == password)
                .FirstOrDefault();

            return concult != null;
        }
    }
}
