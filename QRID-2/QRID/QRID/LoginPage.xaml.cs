using System;
using System.Collections.Generic;
using QRID.Services;
using Xamarin.Forms;

namespace QRID
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            activityLoading.IsVisible = true;

            LoginService loginService = new LoginService();
            bool isValid = await loginService.ValidateUser
                         (entryUsuario.Text, entryClave.Text);
            if (isValid)
            {
                App.Current.Properties["nombreUsuario"] = entryUsuario.Text;
                await App.Current.SavePropertiesAsync();
                await Navigation.PushAsync(new MainPage());
            }
            else{
                await DisplayAlert("Error", "No pudiste ingresar", "OK");
            }

            activityLoading.IsVisible = false;
        }
    }
}
