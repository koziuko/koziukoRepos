using System;
using System.Collections.Generic;
using QRID.Model;
using Xamarin.Forms;
using ZXing;
using ZXing.Net.Mobile.Forms;
using ZXing.QrCode;

namespace QRID
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage(ProfileData profileData)
        {
            InitializeComponent();

            entryNombre.Text = profileData.Nombre;
            entryEmpresa.Text = profileData.Empresa;
        }

        ZXingBarcodeImageView GenerateQR(string codeValue)
        {
            var qrCode = new ZXingBarcodeImageView
            {
                BarcodeFormat = BarcodeFormat.QR_CODE,
                BarcodeOptions = new QrCodeEncodingOptions
                {
                    Height = 350,
                    Width = 350
                },
                BarcodeValue = codeValue,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            // Workaround for iOS
            qrCode.WidthRequest = 350;
            qrCode.HeightRequest = 350;
            return qrCode;
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            ProfileData profileData = new ProfileData()
            {
                Nombre = entryNombre.Text,
                Empresa = entryEmpresa.Text
            };

            var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(profileData);
            slPerfil.Children.Add(GenerateQR(jsonData));
        }
    }
}
