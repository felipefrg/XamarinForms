using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content.Res;
using Android.Util;

namespace Effects_POC.Droid
{
    [Activity(Label = "Effects_POC", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            var config = Resources.Configuration;

           // AdjustFontScale(config, 1.0f);


            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            
            
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        void AdjustFontScale(Configuration configuration, float scale)
        {
            System.Diagnostics.Debug.WriteLine("fontScale=" + configuration.FontScale);
            if (configuration.FontScale > scale)
            {                
                System.Diagnostics.Debug.WriteLine("fontScale is too big. Scale down.");
                configuration.FontScale = scale;

                DisplayMetrics metrics = Resources.DisplayMetrics;                
                metrics.ScaledDensity = configuration.FontScale * metrics.Density;
                BaseContext.Resources.UpdateConfiguration(configuration, metrics);
            }            
        }
    }
}