using ContactBook.Core.Auth.Modelos;
using ContactBook.Core.COMMON.Interfaces;
using ContactBookMobile.Services.Intarfaces;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ContactBookMobile.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel(IUsuarioManager usuarioManager, IAppInfoServices infoServices)
        {
            Title = "About";
            OpenWebCommand = new Command(async () => usuarioManager.ObtenerTodos());
            
        }

        public ICommand OpenWebCommand { get; }
    }
}