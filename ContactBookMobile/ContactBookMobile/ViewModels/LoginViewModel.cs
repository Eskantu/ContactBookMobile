using ContactBook.Core.Auth.Modelos;
using ContactBook.Core.COMMON.Interfaces;

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

using Xamarin.Forms;

namespace ContactBookMobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IUsuarioManager usuarioManager;

        public LoginViewModel(IUsuarioManager usuarioManager)
        {
            this.usuarioManager = usuarioManager;
            LoginCommand = new Command(() => OnLogin());
        }
        public ICommand LoginCommand { get; set; }

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
            if (usuarioManager.Login(new LoginRequest() { Password = Password, UserName = Password }) != null)
                Console.WriteLine("Login succes");
            else
                Console.WriteLine($"Login faild: {usuarioManager.Errror}");
        }

    }
}
