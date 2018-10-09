using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using QRID.Interfaces;
using QRID.Model;
using Xamarin.Forms;
using ZXing;
using ZXing.Mobile;

namespace QRID
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            string nombreUsuario = App.Current.Properties["nombreUsuario"].ToString();
            lblTitulo.Text = "Hola " + nombreUsuario + "!";

            DependencyService.Get<ITextToSpeech>().Speak(lblTitulo.Text);
        }

        public async void OnClickStart(object sender, EventArgs e)
        {
            var options = new ZXing.Mobile.MobileBarcodeScanningOptions();
            options.PossibleFormats = new List<ZXing.BarcodeFormat>() {
                ZXing.BarcodeFormat.QR_CODE
            };

            var scanner = new ZXing.Mobile.MobileBarcodeScanner();

            var result = await scanner.Scan(options);

            if (result != null)
            {
                ProfileData profileData = JsonConvert.DeserializeObject<ProfileData>(result.Text);
                await Navigation.PushAsync(new ProfilePage(profileData));
            }
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage(new ProfileData(){
                Nombre = string.Empty,
                Empresa = string.Empty
            }));
        }
    }
}
