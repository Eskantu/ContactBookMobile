using ContactBookMobile.Helpers.UIModels;
using ContactBookMobile.Services.Navigation;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ContactBookMobile.ViewModels.Menu
{
    public class MenuViewFlyoutViewModel : BaseViewModel
    {
        private readonly INavigationService navigation;

        public MenuViewFlyoutViewModel(INavigationService navigation)
        {
            this.navigation = navigation;
            menuItems = new ObservableCollection<MenuItemModel>(new[]
            {
                    new MenuItemModel(){ Page="Dashboard", HasChildrens=false, Modulo="Dashboard", Icon="\ue871" },
                    new MenuItemModel(){Page="UsersView", HasChildrens=false, Modulo="Usuarios", Icon="\ue853" },
                    new MenuItemModel(){ HasChildrens=true, Modulo="Contact Book", Icon="\uf22e" },
                    new MenuItemModel(){Page="UploadFile", HasChildrens=false, Modulo="Upload file", Icon="\ue2c6" },
                });
        }

        private ObservableCollection<MenuItemModel> menuItems;

        public ObservableCollection<MenuItemModel> MenuItems
        {
            get { return menuItems; }
            set { SetProperty(ref menuItems, value); }
        }
        public async Task NavigateToPage(string page) => await navigation.NavigateAsync(page);
    }
}
