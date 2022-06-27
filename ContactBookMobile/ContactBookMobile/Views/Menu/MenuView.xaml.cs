using ContactBookMobile.Views.ContactBook;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactBookMobile.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuView : FlyoutPage
    {
        public MenuView()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<MenuViewFlyout, string>(this, "Detail", (sender, args) =>
             {
                 SetDetail(args);
             });
        }
        private void SetDetail(string detail)
        {
            switch (detail)
            {
                case "UsersView":
                    Detail = new NavigationPage(new UsersView());
                    IsPresented = false;
                    break;
                case "Contactos":
                    Detail = new NavigationPage(new ContactosView());
                    IsPresented = false;
                    break;
                case "EstadoCivil":
                    Detail = new NavigationPage(new EstadoCivilView());
                    IsPresented = false;
                    break;
                case "TipoContacto":
                    Detail = new NavigationPage(new TipoContactoView());
                    IsPresented = false;
                    break;
                case "Dashboard":
                    Detail = new NavigationPage(new DashboardView());
                    IsPresented = false;
                    break;
                case "UploadFile":
                    Detail = new NavigationPage(new UploadFileView());
                    IsPresented = false;
                    break;
                default:
                    break;
            }
        }

    }
}