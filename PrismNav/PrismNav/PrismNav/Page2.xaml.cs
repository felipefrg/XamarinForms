using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrismNav
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        INavigationService navigationService;
        public Page2(INavigationService navigationService)
        {
            InitializeComponent();
        //    this.navigationService = navigationService;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //this.navigationService.NavigateAsync("/MainPage");
        }
    }
}