using Xamarin.Forms;

namespace CustomStatusBar_POC
{
    public partial class App : Application
    {
        internal static Page MainPageApp;
        public App()
        {
            InitializeComponent();                        
            MainPage = new NavigationPage(new MainPage());           

            MainPageApp = MainPage;
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
