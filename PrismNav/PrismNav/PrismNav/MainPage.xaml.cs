using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PrismNav
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        INavigationService navigationService;
        public MainPage(INavigationService navigationService)
        {
            InitializeComponent();
            //this.navigationService = navigationService;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //navigationService.NavigateAsync("/Page1");
        }
    }
}
