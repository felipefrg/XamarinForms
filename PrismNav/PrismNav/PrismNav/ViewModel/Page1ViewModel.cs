using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismNav.ViewModel
{
    public class Page1ViewModel : ViewModelBase
    {
        public DelegateCommand Page2Command { get; private set; }

        public Page1ViewModel(INavigationService navigationService) : base(navigationService)
        {
            Page2Command = new DelegateCommand(Page2);
        }

        void Page2()
        {
            NavigationService.NavigateAsync("/Page2");
        }
    }
}
