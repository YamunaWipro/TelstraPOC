//using Android.Content.Res;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using App5.View;
using App5.Model;
using System.IO;

namespace App5.ViewModels
{
    public class Login : INotifyPropertyChanged
    {
        DatabaseHelper dh;
       
       public String name;
        public string username, password;
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public INavigation _navigation;
        public string pathName;
        
        public Login()
        {
           

            dh = new DatabaseHelper();
           
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
           

        }
        private LoginModel loginModel = new LoginModel();

        public LoginModel LoginModel
        {
            get { return loginModel; }
            set
            {
                loginModel = value;
                OnPropertyChanged();
            }
        }
        async Task ExecuteLoadItemsCommand()
        {
            username = loginModel.Username;
            password = loginModel.Password;
            //((m.usernameEntry.Text).Equals(string.Empty))
            //   await Application.Current.MainPage.DisplayAlert(MainPage.usernameEntry.Text, "Continue", "OK")
            if (username.Equals(string.Empty) || password.Equals(string.Empty))
            {

                await Application.Current.MainPage.DisplayAlert("Username or Password is empty", "Continue", "OK");
            }
            else

            {


                string pass = dh.GetPassword(username);
                if (pass.Equals(""))
                {
                    await Application.Current.MainPage.DisplayAlert("Username is incorrect", "Continue", "OK");
                }
                else
                {
                    if (pass.Equals(password))
                        //  await Application.Current.MainPage.DisplayAlert(n, "Continue", "OK");
                        // else
                        //  await Application.Current.MainPage.DisplayAlert("No", "Continue", "OK");
                        await _navigation.PushAsync(new NavigationPage(new Page1()));
                    else
                        await Application.Current.MainPage.DisplayAlert("Password is incorrect", "Continue", "OK");
                }
            }
            //await Application.Current.MainPage.DisplayAlert("Negotiation", "Saved correctly", "OK");

        }
        public Command LoadItemsCommand { get ; set; }

        ~Login()
        {
            dh.DeleteTable();
        }
    }
}
    
