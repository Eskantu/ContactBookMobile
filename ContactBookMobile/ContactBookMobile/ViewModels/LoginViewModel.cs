using ContactBook.Core.Auth.Modelos;
using ContactBook.Core.COMMON.Interfaces;
using ContactBook.Core.COMMON.Models;

using ContactBookMobile.Helpers;
using ContactBookMobile.Services.Intarfaces;
using ContactBookMobile.Services.Modelos;
using ContactBookMobile.Services.Navigation;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;

namespace ContactBookMobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IUsuarioManager usuarioManager;
        private readonly INavigationService navigation;
        private readonly IError error;
        private readonly IAlert alert;

        public LoginViewModel(IUsuarioManager usuarioManager, INavigationService navigation, IError error, IAlert alert)
        {
            this.usuarioManager = usuarioManager;
            this.navigation = navigation;
            this.error = error;
            this.alert = alert;
            LoginCommand = new Command(async () => await OnLogin());
            SignInCommand = new Command(async () => await OnPushSingInView());
            this.error.SendError += Error_SendError;
        }

        private void Error_SendError(object sender, RequestException e)
        {

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



        private async Task OnLogin()
        {
            IsBusy = true;
                await navigation.NavigateAsync("MenuView");
            //if (usuarioManager.Login(new LoginRequest() { Password = password, UserName = UserName }) is Usuario)
            //if (usuarioManager.Errror.ToLower().Contains("Unauthorized".ToLower()))
            //    alert.ShowAlert("Credenciales invalidas");
            //Password = "";
            //UserName = "";
            error.SendError -= Error_SendError;
            IsBusy = false;
        }

        private async Task OnPushSingInView()
        {
            await navigation.NavigateAsync("SignIn");
        }

    }
}
