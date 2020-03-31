using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppTheme_POC.Services;
using AppTheme_POC.Views;
using Xamarin.Essentials;
using AppThemePOC.Views.Themes;
using System.Collections.Generic;

namespace AppTheme_POC
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public static void ApplyTheme()
        {
            ICollection<ResourceDictionary> mergedDictionary = App.Current.Resources.MergedDictionaries;
            if (mergedDictionary != null)
            {
                mergedDictionary.Clear();

                if (AppInfo.RequestedTheme == AppTheme.Dark)
                {
                    //App.Current.Resources = new DarkTheme();
                    mergedDictionary.Add(new DarkTheme());
                }
                else
                {
                    //App.Current.Resources = new LightTheme();
                    mergedDictionary.Add(new LightTheme());
                }
            }
        }
    }
}
