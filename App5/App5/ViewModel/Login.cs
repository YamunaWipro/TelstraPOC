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

namespace App5.ViewModels
{
    public class Login : INotifyPropertyChanged
    {
       public String name;
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
       
        public Login()
        {
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
           

        }
        async Task ExecuteLoadItemsCommand()
        {
            //((m.usernameEntry.Text).Equals(string.Empty))
            //  await Application.Current.MainPage.DisplayAlert(MainPage.usernameEntry.Text, "Continue", "OK");
            await _navigation.PushAsync(new NavigationPage(new Page1()));
            //await Application.Current.MainPage.DisplayAlert("Negotiation", "Saved correctly", "OK");

        }
        public Command LoadItemsCommand { get ; set; }


    }
}
    
