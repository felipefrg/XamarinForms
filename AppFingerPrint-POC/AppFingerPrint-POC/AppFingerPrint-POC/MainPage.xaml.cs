using Plugin.Fingerprint.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppFingerPrint_POC
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Teste ","Teste","OK");
        }

        private async void OnAuthenticate(object sender, EventArgs e)
        {
            await AuthenticationAsync("TesteReason", "TesteCancel", "TesteFallback", "TesteTooFast");
        }

        private CancellationTokenSource _cancel;

        private async Task AuthenticationAsync
        (string reason, string cancel = null, string fallback = null, string tooFast = null)
        {
            _cancel = this.swAutoCancel.IsToggled ? new CancellationTokenSource
                      (TimeSpan.FromSeconds(10)) : new CancellationTokenSource();

            var dialogConfig = new AuthenticationRequestConfiguration("Teste",reason)
            {
                CancelTitle = cancel,
                FallbackTitle = fallback                
            };

            var result = await Plugin.Fingerprint.CrossFingerprint.Current.AuthenticateAsync
                         (dialogConfig, _cancel.Token);

            await SetResultAsync(result);
        }

        private async Task SetResultAsync(FingerprintAuthenticationResult result)
        {
            if (result.Authenticated)
            {
                await DisplayAlert("FingerPrint Sample", "Success", "Ok");
            }
            else
            {
                await DisplayAlert("FingerPrint Sample", result.ErrorMessage, "Ok");
            }
        }
    }
}
