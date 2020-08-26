using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismNav.ViewModel
{
    public class MainPageViewModel : ViewModelBase
    {
        public DelegateCommand Page1Command { get; private set; }

        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Page1Command = new DelegateCommand(Page1);
        }

        void Page1()
        {
            NavigationService.NavigateAsync("/Page1");
        }

    }
}
