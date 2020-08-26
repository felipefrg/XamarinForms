using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TabbedPage_POC.Services;
using TabbedPage_POC.Views;

namespace TabbedPage_POC
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
    }
}
