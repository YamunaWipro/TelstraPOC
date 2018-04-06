using Xamarin.Forms;
using App5.View;
using App5.ViewModels;

namespace App5
{
    public partial class MainPage : ContentPage
	{
		public MainPage()
		{
            


            InitializeComponent();
            Login viewmodel = new Login();
            BindingContext = viewmodel;
            ((Login)this.BindingContext).name = usernameEntry.Text;
                
            viewmodel._navigation = this.Navigation;
        }
        void Handle_Clear_Clicked(object sender, System.EventArgs e)
        {
            usernameEntry.Text = string.Empty;
            passwordEntry.Text = string.Empty;
        }
      
    }
}
