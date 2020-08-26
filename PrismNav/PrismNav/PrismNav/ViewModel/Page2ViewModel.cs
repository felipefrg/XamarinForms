using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismNav.ViewModel
{
    public class Page2ViewModel : ViewModelBase
    {
        public DelegateCommand MainPageCommand { get; private set; }

        public Page2ViewModel(INavigationService navigationService) : base(navigationService)
        {
            MainPageCommand = new DelegateCommand(MainPage);
        }

        void MainPage()
        {
            NavigationService.NavigateAsync("/MainPage");
        }
    }
}
