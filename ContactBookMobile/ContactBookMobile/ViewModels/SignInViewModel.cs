using ContactBookMobile.Services.Navigation;

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

using Xamarin.Forms;

namespace ContactBookMobile.ViewModels
{
   public class SignInViewModel:BaseViewModel
    {
        public ICommand BackLoginCommand { get; set; }
        public SignInViewModel(INavigationService navigation)
        {
            BackLoginCommand = new Command(async () => await navigation.GoBack());
        }
    }
}
