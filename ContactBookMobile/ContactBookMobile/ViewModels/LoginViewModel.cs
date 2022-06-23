using ContactBook.Core.Auth.Modelos;
using ContactBook.Core.COMMON.Interfaces;

using ContactBookMobile.Services.Navigation;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;

namespace ContactBookMobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IUsuarioManager usuarioManager;
        private readonly INavigationService navigation;

        public LoginViewModel(IUsuarioManager usuarioManager, INavigationService navigation)
        {
            this.usuarioManager = usuarioManager;
            this.navigation = navigation;
            LoginCommand = new Command(() => OnLogin());
            SignInCommand = new Command(async () => await  OnPushSingInView());
        }
        public ICommand LoginCommand { get; set; }
        public ICommand SignInCommand { get; set; }

        private string password;

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }
        private string userName;

        public string UserName
        {
            get => userName;
            set => SetProperty(ref userName, value);
        }



        private void OnLogin()
        {

        }

        private async Task OnPushSingInView() 
        {
           await navigation.NavigateAsync("SignIn", true);
        }

    }
}
